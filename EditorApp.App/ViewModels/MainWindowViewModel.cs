using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using EditorApp.Lib.Abstract;
using EditorApp.Lib.Txt;
using ReactiveUI;

namespace EditorApp.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private File _file;

        private object _content;

        public object Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public ReactiveCommand<Unit, Task> CreateFileCommand { get; }
        public Window WindowOwner { get; init; }

        private string _output;

        public string Output
        {
            get => _output;
            set => this.RaiseAndSetIfChanged(ref _output, value);
        }

        public MainWindowViewModel()
        {
            CreateFileCommand = ReactiveCommand.Create(CreateFile);
        }

        private async Task CreateFile()
        {
            var dialog = new SaveFileDialog();
            dialog.Filters.Add(new FileDialogFilter { Name = "Text", Extensions = new List<string> { "txt" } });
            dialog.Filters.Add(new FileDialogFilter { Name = "CSV", Extensions = new List<string> { "csv" } });
            dialog.Filters.Add(new FileDialogFilter { Name = "Json", Extensions = new List<string> { "json" } });

            var result = await dialog.ShowAsync(WindowOwner);
            Output = result;

            var pos = result.LastIndexOf('/');
            var fileName = result[pos..];
            var temp = fileName.Split('.');
            var extensions = temp[1];
            switch (extensions)
            {
                case "txt":
                    _file = new TxtFile();
                    _file.Create(result);
                    Content = _file.Content;
                    break;
                case "csv":
                    break;
            }
        }
    }
}
