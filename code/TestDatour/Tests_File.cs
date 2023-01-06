using Datour;

namespace TestDatour
{
    public partial class Tests_File
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

    }
}