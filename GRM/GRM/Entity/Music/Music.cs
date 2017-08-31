using System;
using System.Collections.Generic;

namespace GRM.Entity.Music
{
    public class Music
    {
        public Music()
        {
            Usage = new List<string>();
        }
        public string Artist { get; set; }
        public string Title { get; set; }
        public List<string> Usage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
