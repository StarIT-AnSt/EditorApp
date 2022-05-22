using System.IO;
using System.Threading.Tasks;
using EditorApp.Lib.Abstract;
using File = EditorApp.Lib.Abstract.File;

namespace EditorApp.Lib.Txt
{
    public class TxtFile : File, IFile
    {
        public TxtFile() : base() {}
        public TxtFile(string path, string content) : base(path, content) { }

        public async Task Save()
        {
            await using var file = new StreamWriter(path, append: false);
            await file.WriteAsync((string)content);
        }

        public async Task SaveAs(string path)
        {
            this.path = path;
            await Save();
        }

        public async Task Open(string path)
        {
            this.path = path;
            using var file = new StreamReader(path);
            content = await file.ReadToEndAsync();
        }

        public void Create(string path)
        {
            this.path = path;
            content = string.Empty;
        }
    }
}