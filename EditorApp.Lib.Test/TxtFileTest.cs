using System.Threading.Tasks;
using EditorApp.Lib.Txt;
using Xunit;
using File = System.IO.File;

namespace EditorApp.Lib.Test
{
    public class TxtFileTest
    {
        private const string Str = "first\r\nвторая строка\r\n";
        
        [Fact]
        public void Create_Test()
        {
            var expected = typeof(string);

            var txt = new TxtFile();
            txt.Create("");
            var actual = txt.content.GetType();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Open_Test()
        {
            var expected = Str;

            var txt = new TxtFile();
            await txt.Open("test.txt");
            var actual = txt.content;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Save_Test()
        {
            var txt = new TxtFile();
            txt.content = Str;
            await txt.SaveAs("_test.txt");

            var expected = Str;
            var actual = await File.ReadAllTextAsync("_test.txt");
            
            Assert.Equal(expected, actual);
        }
    }
}