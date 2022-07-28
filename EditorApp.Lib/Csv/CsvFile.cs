﻿using System.IO;
using System.Threading.Tasks;
using File = EditorApp.Lib.Abstract.File;

namespace EditorApp.Lib.Csv
{
    public class CsvFile : File
    {
        public CsvFile() : base() { }
        public CsvFile(string path, object content) : base(path, content) { }

        public override async Task Save()
        {
            await using var file = new StreamWriter(Path, false);
            await file.WriteAsync(Content.ToString());
        }

        public override async Task SaveAs(string path)
        {
            this.Path = path;
            await Save();
        }

        public override async Task Open(string path)
        {
            this.Path = path;
            using var file = new StreamReader(path);
            var temp = await file.ReadToEndAsync();
            var tempContent = new CsvContent();
            tempContent.Parser(temp);
            Content = tempContent;
        }

        public override void Create(string path)
        {
            this.Path = path;
            Content = new CsvContent();
        }
    }
}
