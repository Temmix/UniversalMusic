using GRM.DTO;
using GRM.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using GRM.Helpers;

namespace GRM.Helpers
{
    public class DTOConverter
    {
        public static IEnumerable<MusicDTO> Convert(IEnumerable<Music> list,string usage)
        {
            foreach (var music in list)
            {
                yield return new MusicDTO
                {
                    Artist = music.Artist,
                    Title = music.Title,
                    Usage = music.Usage.Where(s => s == usage).FirstOrDefault(),
                    StartDate = String.Format("{0:d MMM yyyy}", music.StartDate).AddSuffix(),
                    EndDate = String.Format("{0:d MMM yyyy}", music.EndDate).AddSuffix()
                };
            }
        }
    }
}
