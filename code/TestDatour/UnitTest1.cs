using Datour;

namespace TestDatour
{
    public class Tests
    {
        const string FILENAME = "filename.ext";

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
        
        [TestCase(2022, 1, 1, "2022_01_01")]
        [TestCase(2022, 12, 31, "2022_12_31")]
        [TestCase(2022, 1, 31, "2022_01_31")]
        [TestCase(2022, 12, 1, "2022_12_01")]
        public void from_dateonly_get_ymd(int year, int month, int day, string expected_ymd)
        {
            DateOnly dateonly = new DateOnly(year, month, day);
            string ymd = Datour.Namer.from_dateonly_get_ymd(dateonly);
            Assert.That(ymd, Is.EqualTo(expected_ymd));
        }

        [TestCase(2022, 1, 2, "2022_01_02-")]
        public void from_dateonly_get_prefix(int year, int month, int day, string expected_prefix)
        {
            DateOnly dateonly = new DateOnly(year, month, day);
            string prefix = Datour.Namer.from_dateonly_get_prefix(dateonly);
            Assert.That(prefix, Is.EqualTo(expected_prefix));
        }


        [TestCase("2022_01_02-filename.ext", "2022_01_02-")]
        public void from_filename_get_prefix(string filename, string expected_prefix)
        {
            string prefix = Datour.Namer.from_filename_get_prefix(filename);
            Assert.That(prefix, Is.EqualTo(expected_prefix));
        }
        
        [TestCase("2022_01_02-filename.ext")]
        public void from_filename_has_prefix(string filename)
        {
            bool has_prefix = Datour.Namer.from_filename_has_prefix(filename);
            Assert.That(has_prefix, Is.True);
        }
        
        [TestCase("filename.ext")]
        [TestCase("2022-filename.ext")]
        [TestCase("2022_01-filename.ext")]
        [TestCase("2022_01_02filename.ext")]
        [TestCase("2022_01_02_filename.ext")]
        [TestCase("2022_01_02.ext")]
        [TestCase("2022-01-02-filename.ext")]
        [TestCase("2022_01_2-filename.ext")]
        [TestCase("2022_1_02-filename.ext")]
        [TestCase("2022_1_2-filename.ext")]
        [TestCase("2022_01_002-filename.ext")]
        public void from_filename_has_prefix_false(string filename)
        {
            bool has_prefix = Datour.Namer.from_filename_has_prefix(filename);
            Assert.That(has_prefix, Is.False);
        }
    }
}