using System.IO;
using System.Threading.Tasks;
using EditorApp.Lib.Csv;
using Xunit;

namespace EditorApp.Lib.Test
{
    public class CsvFileTest
    {
        [Fact]
        public void Create_Test()
        {
            var csv = new CsvFile();
            csv.Create("");

            Assert.IsType<CsvContent>(csv.content);
        }

        [Fact]
        public async Task Open_Test()
        {
            var expected = "first;second;last\r\n1;2;3\r\n1;2;3";

            var temp = new CsvFile();
            await temp.Open("test.csv");

            var actual = temp.content.ToString();
            
            Assert.Equal(expected, actual);
        }
    }
}