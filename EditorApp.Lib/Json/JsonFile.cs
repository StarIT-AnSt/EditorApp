using System.IO;
using System.Threading.Tasks;
using EditorApp.Lib.Abstract;
using EditorApp.Lib.Csv;
using File = EditorApp.Lib.Abstract.File;

namespace EditorApp.Lib.Json
{
    public class JsonFile : File, IFile
    {
        public JsonFile() : base() { }
        public JsonFile(string path, object content) : base(path, content) { }

        public async Task Save()
        {
            await using var file = new StreamWriter(path, false);
            await file.WriteAsync(content.ToString());
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
            var temp = await file.ReadToEndAsync();
            var tempContent = new JsonContent();
            tempContent.Parser(temp);
            content = tempContent;
        }

        public void Create(string path)
        {
            this.path = path;
            content = new JsonContent();
        }
    }
}
