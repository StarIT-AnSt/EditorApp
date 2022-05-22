namespace EditorApp.Lib.Abstract
{
    public abstract class File
    {
        protected string path;
        public object content;

        protected File() {}
        protected File(string path, object content)
        {
            this.path = path;
            this.content = content;
        }
    }
}