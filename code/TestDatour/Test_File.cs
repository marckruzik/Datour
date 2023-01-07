using Datour;

namespace TestDatour
{
    public partial class Test_File
    {
        const string FILENAME = "filename.ext";

        public static string file_create(int year, int month, int day)
        {
            DateTime datetime = new DateTime(year, month, day);
            File.Delete(FILENAME);
            File.Create(FILENAME).Close();
            File.SetLastWriteTime(FILENAME, datetime);
            return Path.GetFullPath(FILENAME);
        }

        [SetUp]
        public void Setup()
        {
            File.Delete(FILENAME);
        }

        [Test]
        public void Filepath_Exist()
        {
            File.Create(FILENAME).Close();
            Assert.That(File.Exists(FILENAME), Is.True);
        }

        [Test]
        public void Filepath_ExistNot()
        {
            Assert.That(File.Exists(FILENAME), Is.False);
        }
        
        [Test]
        public void from_filepath_get_dateonly_modification()
        {
            DateTime datetime = new DateTime(2022, 1, 2);
            File.Create(FILENAME).Close();
            File.SetLastWriteTime(FILENAME, datetime);
            string filepath = Path.GetFullPath(FILENAME);

            DateOnly dateonly_modification = Datour.IO.from_filepath_get_dateonly_modification(filepath);
            Assert.That(dateonly_modification.ToDateTime(TimeOnly.MinValue), Is.EqualTo(datetime));
        }


        [TestCase(2022, 1, 2, "2022_01_02-")]
        [TestCase(2022, 12, 31, "2022_12_31-")]
        public void from_filepath_get_prefix(int year, int month, int day, string expected_prefix)
        {
            string filepath = file_create(year, month, day);
            string prefix = Datour.IO.from_filepath_get_prefix(filepath);
            Assert.That(prefix, Is.EqualTo(expected_prefix));
        }


        [TestCase(2022, 1, 2)]
        [TestCase(2022, 12, 31)]
        public void from_filepath_set_prefix(int year, int month, int day)
        {
            string filepath = file_create(year, month, day);
            string expected_filepath_with_prefix = Datour.IO.from_filepath_get_filepath_with_prefix(filepath);
            File.Delete(expected_filepath_with_prefix);
            string filepath_with_prefix = Datour.IO.from_filepath_set_filepath_with_prefix(filepath);

            Assert.That(filepath_with_prefix, Is.EqualTo(expected_filepath_with_prefix));
        }
    }
}
