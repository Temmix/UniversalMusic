using GRM.Entity.Music;
using System;

namespace GRM.Interface
{
    public interface IMusicFactory
    {
         Music GetMusicInstance(string artist, string title, string usages, string startDate, string endDate);
    }
}
