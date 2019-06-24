using Avalonia;
using Avalonia.Markup.Xaml;

namespace HelloAvaloniaWorld
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
