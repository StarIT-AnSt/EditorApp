using System.IO;
using System.Threading.Tasks;
using EditorApp.Lib.Abstract;
using File = EditorApp.Lib.Abstract.File;

namespace EditorApp.Lib.Json
{
    public class JsonFile : File, IFile
    {
        public JsonFile() : base() {}
        public JsonFile(string path, object content) : base(path, content) {}

        public async Task Save()
        {
            await using var file = new StreamWriter(path, append: false);
            await file.WriteAsync(content.ToString());
        }

        public async Task SaveAs(string path)
        {
            this.path = path;
            await Save();
        }

        public Task Open(string path)
        {
            throw new System.NotImplementedException();
        }

        public void Create(string path)
        {
            this.path = path;
            content = new JsonContent();
        }
    }
}