namespace EditorApp.Lib.Abstract
{
    public abstract class File
    {
        protected string path;
        protected object content;

        protected File(string path, object content)
        {
            this.path = path;
            this.content = content;
        }
    }
}