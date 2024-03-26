using TestApp.Mocking;

namespace TestApp.UnitTests.Mocking
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
