using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Avalonia.Media.Imaging;


namespace HelloAvaloniaWorld.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _currentPath = Directory.GetCurrentDirectory();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            UpCommand = ReactiveCommand.Create(Up);
            DoSomeShitCommand = ReactiveCommand.Create<string>(s => DoSomeShit(s));
        }

        public List<Entry> ItemCollection =>
            Directory.EnumerateFileSystemEntries(_currentPath)
            .Select(path => new Entry(path))
            .ToList();

        public Bitmap ImagePath { get; private set; }

        private string CurrentPath
        {
            get { return _currentPath; }
            set
            {
                _currentPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemCollection)));
            }
        }

        public void DoSomeShit(string path)
        {
            CurrentPath = path;
        }

        private void Up()
        {
            var info = Directory.GetParent(_currentPath);
            CurrentPath = info.FullName;
        }

        public ReactiveCommand UpCommand { get; }

        public ReactiveCommand DoSomeShitCommand { get; }
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
