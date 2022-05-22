using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorApp.Lib.Csv
{
    public class CsvContent
    {
        private List<string> _header;
        private List<List<string>> _content;

        public CsvContent()
        {
            _header = new List<string>();
            _content = new List<List<string>>();
        }

        public void Parser(string str)
        {
            var lines = str.Split("\r\n");

            _header = lines[0].Split(';').ToList();
            
            for (int i = 1; i < lines.Length; i++)
            {
                _content.Add(lines[i].Split(';').ToList());
            }
        }

        public override string ToString()
        {
            var temp = new StringBuilder();

            foreach (var str in _header)
            {
                temp.Append($"{str};");
            }
            temp.Append("\r\n");

            foreach (var str in _content)
            {
                foreach (var item in str)
                {
                    temp.Append($"{item};");
                }
                temp.Append("\r\n");
            }

            return temp.ToString();
        }
    }
}