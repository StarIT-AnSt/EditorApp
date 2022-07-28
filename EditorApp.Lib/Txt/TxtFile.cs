using System.IO;
using System.Threading.Tasks;
using File = EditorApp.Lib.Abstract.File;

namespace EditorApp.Lib.Txt
{
    public class TxtFile : File
    {
        public TxtFile() : base() { }
        public TxtFile(string path, string content) : base(path, content) { }

        public override async Task Save()
        {
            await using var file = new StreamWriter(Path, false);
            await file.WriteAsync((string)Content);
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
            Content = await file.ReadToEndAsync();
        }

        public override void Create(string path)
        {
            this.Path = path;
            Content = string.Empty;
        }
    }
}
