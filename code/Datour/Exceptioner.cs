﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datour
{
    public partial class Exceptioner
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

        public static void from_input_check_filepath_other_with_prefix(string input)
        {
            string filepath_with_prefix = Datour.IO.from_filepath_get_filepath_with_prefix(input);
            if (File.Exists(filepath_with_prefix) == true)
            {
                throw new Exception_Filepath_Other_With_Prefix();
            }
        }
    }

    public partial class Exceptioner
    {
        public static string from_args_get_message(string[] args)
        {
            try
            {
                from_args_check_zero(args);
                from_args_check_multiple(args);
                string input = args[0];
                from_input_check_prefix(input);
                from_input_check_folderpath(input);
                from_input_check_filepath_missing(input);
                from_input_check_filepath_other_with_prefix(input);
            }
            catch(Exception e)
            {
                return $"Failure because of {e.GetType()}";
            }

            return "";
        }

    }


    public class Exception_Zero : Exception {}
    public class Exception_Multiple : Exception {}
    public class Exception_Prefix : Exception {}
    public class Exception_Folderpath : Exception {}
    public class Exception_Filepath_Missing : Exception {}
    public class Exception_Filepath_Other_With_Prefix : Exception {}

}
