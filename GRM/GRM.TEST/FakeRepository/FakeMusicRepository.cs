using GRM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRM.Entity.Music;

namespace GRM.TEST.FakeRepository
{
    public class FakeMusicRepository : IMusicRepository
    {
        public IEnumerable<Music> GetAll()
        {
            return this.ProvideMusic();
        }
        public IEnumerable<Music> Get(string usage, DateTime date)
        {
            return this.GetAll().Where(x => x.Usage.Any(s => s.Contains(usage)) && date >= x.StartDate)
                     .OrderBy(x => x.Artist).ThenBy(x => x.Title);
        }
        
        private IEnumerable<Music> ProvideMusic()
        {
            var list = new List<Music>();
            var one = new Music { Artist = "Claw", Title = "Black Mountain", StartDate = new DateTime(2012, 7, 12) };
            one.Usage.Add("streaming");
            list.Add(one);

            var two = new Music { Artist = "Claw", Title = "Motor Mouth", StartDate = new DateTime(2011, 12, 11) };
            two.Usage.AddRange(new List<string> { "digital download", "streaming" });
            list.Add(two);

            var three = new Music { Artist = "Tinie", Title = "Miami 2 Ibiza", StartDate = new DateTime(2011, 12, 5) };
            three.Usage.Add("digital download");
            list.Add(three);

            var four = new Music {  Artist = "Tinie", Title = "Frisky", StartDate = new DateTime(2012, 9, 22) };
            four.Usage.AddRange(new List<string> { "digital download", "streaming" });
            list.Add(four);

            return list;
        }
    }
}
