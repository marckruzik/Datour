using Datour;

namespace TestDatour
{
    [TestFixture]
    public class Test_Exception
    {
        /*
        It uses one filepath as an input parameter.

        If several input parameters are specified, It does nothing.
        If no input parameter is specified, It does nothing.
        If It is missing the rights to modify a filepath, It does nothing. (canceled, too complicated, if It does not work we just see it)
        If a file has already a date prefix, It does nothing.
        If the input parameter is a folderpath, It does nothing.
        If the filepath is inexistant, It does nothing.
        */
        
        const string FILENAME = "filename.ext";
        const string FOLDERNAME = "foldername";

        [SetUp]
        public void Setup()
        {
            File.Delete(FILENAME);
            if (Directory.Exists(FOLDERNAME) == true)
            {
                Directory.Delete(FOLDERNAME, true);
            }
        }

        [TestCase("a")]
        public static void from_args_check_one(params string[] args)
        {
            Assert.That(args.Length, Is.EqualTo(1));
        }

        [TestCase()]
        public static void from_args_check_zero(params string[] args)
        {
            Assert.Throws<Exception_Zero>(() => Datour.Exceptioner.from_args_check_zero(args));
        }

        [TestCase("a", "b")]
        [TestCase("a", "b", "c")]
        public static void from_args_check_multiple(params string[] args)
        {
            Assert.Throws<Exception_Multiple>(() => Datour.Exceptioner.from_args_check_multiple(args));
        }

        [TestCase(@"C:\2022_01_01-filename.ext")]
        [TestCase(@"C:\2022_12_31-filename.ext")]
        public static void from_input_check_prefix_true(string input)
        {
            input = input.Replace(@"\", Path.DirectorySeparatorChar.ToString());
            Assert.Throws<Exception_Prefix>(() => Datour.Exceptioner.from_input_check_prefix(input));
        }

        [TestCase(@"C:\filename.ext")]
        [TestCase(@"C:\20221231-filename.ext")]
        [TestCase(@"C:\2022-12-31-filename.ext")]
        [TestCase(@"C:\2022_1-2-filename.ext")]
        public static void from_input_check_prefix_false(string input)
        {
            Assert.DoesNotThrow(() => Datour.Exceptioner.from_input_check_prefix(input));
        }
        
        [TestCase(FOLDERNAME)]
        public static void from_input_check_folderpath_true(string input)
        {
            Directory.CreateDirectory(input);
            Assert.Throws<Exception_Folderpath>(() => Datour.Exceptioner.from_input_check_folderpath(input));
        }

        [TestCase(FILENAME)]
        public static void from_input_check_folderpath_false(string input)
        {
            File.Create(input).Close();
            Assert.DoesNotThrow(() => Datour.Exceptioner.from_input_check_folderpath(input));
        }

        [TestCase(FILENAME)]
        public static void from_input_check_filepath_missing(string input)
        {
            Assert.Throws<Exception_Filepath_Missing>(() => Datour.Exceptioner.from_input_check_filepath_missing(input));
        }

        [Test]
        public static void from_input_check_filepath_other_with_prefix()
        {
            DateTime datetime = new DateTime(2022, 1, 2);

            // We create a file with prefix
            string filepath = Path.GetFullPath(FILENAME);
            File.Create(filepath).Close();
            File.SetLastWriteTime(filepath, datetime);
            string filepath_with_prefix = Datour.IO.from_filepath_get_filepath_with_prefix(filepath);
            if (File.Exists(filepath_with_prefix) == true) 
            { 
                File.Delete(filepath_with_prefix); 
            }
            Datour.IO.from_filepath_set_filepath_with_prefix(filepath);

            // We create a file without prefix
            File.Create(filepath).Close();
            File.SetLastWriteTime(filepath, datetime);

            Assert.Throws<Exception_Filepath_Other_With_Prefix>(() => Datour.Exceptioner.from_input_check_filepath_other_with_prefix(filepath));
        }


    }
}
