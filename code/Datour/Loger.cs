using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datour
{
    public partial class Loger
    {

        public static string from_system_get_log_folderpath()
        {
            string log_folderpath = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
               @"Datour\log");
            return log_folderpath;
        }

        public static string from_dateonly_get_log_filename(DateOnly dateonly)
        {
            string ymd = Namer.from_dateonly_get_ymd(dateonly);
            string log_filename = $"{ymd}-log.txt";
            return log_filename;
        }
        
        public static DateOnly from_system_get_dateonly()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }

        public static string from_system_get_log_filepath()
        {
            string log_folderpath = from_system_get_log_folderpath();
            DateOnly dateonly = from_system_get_dateonly();
            string log_filename = from_dateonly_get_log_filename(dateonly);
            string log_filepath = Path.Join(log_folderpath, log_filename);
            return log_filepath;
        }


    }


    public partial class Loger
    {
        public static void from_log_folderpath_create_folder(string log_folderpath)
        {
            if (Directory.Exists(log_folderpath) == true)
            {
                return;
            }
            Directory.CreateDirectory(log_folderpath);
        }

        
        public static void from_log_filepath_and_message_create_log(string log_filepath, string message)
        {
            if (File.Exists(log_filepath) == false)
            {
                File.Create(log_filepath).Close();
            }
            string line = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")};{message}";
            File.AppendAllLines(log_filepath, new List<string> { line });
        }
    }
}
