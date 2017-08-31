using GRM.Entity.Music;
using GRM.Interface;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace GRM.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IMusicFactory factory;
        private const int propertyCount = 5;
        public MusicRepository(IMusicFactory _factory)
        {
            this.factory = _factory;
        }
        public IEnumerable<Music> GetAll()
        {
            var musicList = new List<Music>();
            var fullPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var fullFileName = Path.Combine(fullPath, @"Files\MusicContracts.txt");
            using (StreamReader reader = new StreamReader(fullFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var lineArr = line.Split('|');
                    if (lineArr.Length == propertyCount)
                    {
                        var musicInstance = factory.GetMusicInstance(lineArr[0], lineArr[1], lineArr[2], lineArr[3], lineArr[4]);
                        if (musicInstance != null)
                            musicList.Add(musicInstance);
                    }
                }
            }
            return musicList;
        }

        public IEnumerable<Music> Get(string usage, DateTime date)
        { 
            return this.GetAll().Where(x => x.Usage.Any(s => s.Contains(usage)) && date >= x.StartDate)
                       .OrderBy(x => x.Artist).ThenBy(x => x.Title); 
        }
    }
}
