using ReactiveUI;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace HelloAvaloniaWorld.ViewModels
{
    public class MainWindowViewModel :
        // ViewModelBase
        INotifyPropertyChanged

    {
        private string _currentPath = Directory.GetCurrentDirectory();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            UpCommand = ReactiveCommand.Create(Up);
        }

        public List<Entry> ItemCollection =>
            Directory.EnumerateFileSystemEntries(_currentPath)
            .Select(path => new Entry(path))
            .ToList();

        private void Up()
        {
            var info = Directory.GetParent(_currentPath);
            _currentPath = info.FullName;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemCollection)));
        }

        public ReactiveCommand UpCommand { get; }
    }

    public class Entry
    {
        public Entry(string fullPath)
        {
            FullPath = fullPath;

            Name = Path.GetFileName(fullPath);
            if ((File.GetAttributes(fullPath) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                IsDIrectory = true;
            }
        }

        public string FullPath { get; }

        public string Name { get; }

        public bool IsDIrectory { get; }
    }
}
