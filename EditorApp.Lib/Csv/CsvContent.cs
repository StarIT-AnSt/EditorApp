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

            for (int i = 0; i < _header.Count; i++)
            {
                temp.Append(i == _header.Count - 1 ? $"{_header[i]}" : $"{_header[i]};");
            }
            temp.Append("\r\n");

            for (int i = 0; i < _content.Count; i++)
            {
                for (int j = 0; j < _content[i].Count; j++)
                {
                    temp.Append(j == _content[i].Count - 1 ? $"{_content[i][j]}" : $"{_content[i][j]};");
                }
                temp.Append(i == _content.Count - 1 ? "" : "\r\n");
            }

            return temp.ToString();
        }
    }
}