using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datour
{
    public class IO
    {
        public static DateOnly from_filepath_get_dateonly_modification(string filepath)
        {
            return DateOnly.FromDateTime(File.GetLastWriteTime(filepath));
        }

        public static string from_filepath_get_prefix(string filepath)
        {
            DateOnly dateonly_modification = from_filepath_get_dateonly_modification(filepath);
            string prefix = Namer.from_dateonly_get_prefix(dateonly_modification);
            return prefix;
        }

        public static string from_filepath_get_filepath_with_prefix(string filepath)
        {
            string filename = Path.GetFileName(filepath);
            DateOnly dateonly = from_filepath_get_dateonly_modification(filepath);
            string filename_with_prefix = Namer.from_filename_and_dateonly_get_filename_with_prefix(filename, dateonly);
            string folderpath = Path.GetDirectoryName(filepath) ?? "";
            string filepath_with_prefix = Path.Join(folderpath, filename_with_prefix);
            return filepath_with_prefix;
        }

        public static string from_filepath_set_filepath_with_prefix(string filepath)
        {
            string filepath_with_prefix = from_filepath_get_filepath_with_prefix(filepath);
            File.Move(filepath, filepath_with_prefix);
            return filepath_with_prefix;
        }
    }
}
