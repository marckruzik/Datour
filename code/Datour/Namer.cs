using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datour
{
    public class Namer
    {
        const string PREFIX_INVALID = "";

        public static string from_dateonly_get_ymd(DateOnly dateonly)
        {
            return $"{dateonly.Year}_{dateonly.Month:D2}_{dateonly.Day:D2}";
        }

        public static string from_dateonly_get_prefix(DateOnly dateonly)
        {
            string ymd = from_dateonly_get_ymd(dateonly);
            return $"{ymd}-";
        }

        public static string from_filename_get_prefix(string filename)
        {
            Regex regex = new Regex(@"^\d\d\d\d_\d\d_\d\d-");
            Match m = regex.Match(filename);
            if (m.Success == false)
            {
                return PREFIX_INVALID;
            }
            return m.Groups[0].Value;
        }

        public static bool from_filename_has_prefix(string filename)
        {
            string prefix = from_filename_get_prefix(filename);
            return prefix != PREFIX_INVALID;
        }
    }
}
