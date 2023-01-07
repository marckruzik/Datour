using Datour;

namespace TestDatour
{

    public class Test_Log
    {
        /*
        from_system_get_log_folderpath
        from_log_folderpath_create_folder
        from_system_get_dateonly
        from_dateonly_get_log_filename
        from_system_and_dateonly_get_log_filepath
        from_exceptioner_get_message
        from_runner_get_message
        from_log_filepath_and_message_create_log
        */
        
        const string FILENAME = "filename.ext";
        const string FOLDERNAME = "log";

        [SetUp]
        public void Setup()
        {
            File.Delete(FILENAME);
            if (Directory.Exists(FOLDERNAME) == true)
            {
                Directory.Delete(FOLDERNAME, true);
            }
        }

        [TestCase(2022, 1, 2, "2022_01_02-log.txt")]
        public static void from_dateonly_get_log_filename(int year, int month, int day, string expected_log_filename)
        {
            DateOnly dateonly = new DateOnly(year, month, day);
            string log_filename = Datour.Loger.from_dateonly_get_log_filename(dateonly);
            Assert.That(log_filename, Is.EqualTo(expected_log_filename));
        }


    }
}
