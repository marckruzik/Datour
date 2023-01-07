using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datour
{
    public class Exceptioner
    {
        public static void from_args_check_zero(string[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception_Zero();
            }
        }

        public static void from_args_check_multiple(string[] args)
        {
            if (args.Length >= 2)
            {
                throw new Exception_Multiple();
            }
        }

        public static void from_input_check_prefix(string input)
        {
            bool has_prefix = Namer.from_filename_has_prefix(Path.GetFileName(input));
            if (has_prefix == true)
            {
                throw new Exception_Prefix();
            }
        }

        public static void from_input_check_folderpath(string input)
        {
            if (Directory.Exists(input) == true)
            {
                throw new Exception_Folderpath();
            }
        }

        public static void from_input_check_filepath_missing(string input)
        {
            if (File.Exists(input) == false)
            {
                throw new Exception_Filepath_Missing();
            }
        }
    }

    public class Exception_Zero : Exception {}
    public class Exception_Multiple : Exception {}
    public class Exception_Prefix : Exception {}
    public class Exception_Folderpath : Exception {}
    public class Exception_Filepath_Missing : Exception {}

}
