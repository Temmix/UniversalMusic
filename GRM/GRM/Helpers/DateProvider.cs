using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRM.Helpers
{
    public static class Provider
    {
        public static DateTime ProvideDate(string[] input)
        {
            DateTime date;
            var builder = new StringBuilder();
            input.Skip(1).Take(3).ToList()
                     .ForEach(x => builder.Append(x));

            var strDate = builder.ToString().RemoveSuffix();
            DateTime.TryParse(strDate, out date);
            return date;
        }
    }
}
