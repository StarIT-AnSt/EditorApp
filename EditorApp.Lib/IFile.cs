using System.Threading.Tasks;

namespace EditorApp.Lib
{
    public interface IFile
    {
        public Task Save();
        public Task SaveAs(string path);
        public Task Open(string path);
        public void Create(string path);
    }
}