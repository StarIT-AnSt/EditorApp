using System.Threading.Tasks;

namespace EditorApp.Lib.Abstract
{
    public abstract class File : IFile
    {
        protected string Path;
        public object Content;

        protected File() { }

        protected File(string path, object content)
        {
            this.Path = path;
            this.Content = content;
        }

        public abstract Task Save();

        public abstract Task SaveAs(string path);

        public abstract Task Open(string path);

        public abstract void Create(string path);
    }
}
