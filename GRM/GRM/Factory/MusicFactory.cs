using GRM.Interface;
using System;
using GRM.Helpers;
using GRM.Entity.Music;

namespace GRM.Factory
{
    public class MusicFactory : IMusicFactory
    {
        public Music GetMusicInstance(string artist, string title, string usages, string startDate, string endDate)
        {
            Music music = null;
            startDate = startDate.RemoveSuffix();
            endDate = endDate.RemoveSuffix();

            DateTime StartDate, 
                     EndDate;
            if (DateTime.TryParse(startDate, out StartDate))
            {
                music = new Music { Artist = artist, Title = title, StartDate = StartDate }; 
                music.Usage.AddRange(usages.Split(new string[] { ", " }, StringSplitOptions.None)); 
                music.EndDate = DateTime.TryParse(endDate, out EndDate) ? (DateTime?)EndDate : null ;
            }
            return music;
        }
    }
}
