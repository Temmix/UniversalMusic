using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRM.Helpers
{
    public static class Extensions
    {
        public static string RemoveSuffix(this string @this)
        {
            string response = null;
            if (!string.IsNullOrWhiteSpace(@this))
            {
               response = @this.Replace("nd", "")
                                .Replace("th", "")
                                .Replace("rd", "")
                                .Replace("st", ""); 
            }
            return response;
        }
 
        public static string AddSuffix(this string @this)
        {
            if (!string.IsNullOrWhiteSpace(@this))
            {
                var suffix = string.Empty;
               var date = @this.Split(' ');
                switch (date[0])
                {
                    case "1":
                    case "21":
                    case "31":
                        suffix = "st";
                        break;
                    case "2":
                    case "22":
                        suffix = "nd";
                        break;
                    case "3":
                    case "23":
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
               date[0] = date.FirstOrDefault() + suffix;
               return string.Join(" ", date);
            }
            return null;

        }
    }
}
