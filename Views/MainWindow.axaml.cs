using Avalonia;
using Avalonia.Controls;
using RegexApp.ViewModels;
using Avalonia.Interactivity;
using System;
using System.IO;

namespace RegexApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenFileDialog").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPath;

                if (path != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.InputText = "";
                    var pathStr = string.Join(@"\", path);

                    using (StreamReader sr = File.OpenText(pathStr))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                            context.InputText += s;
                    }
                }
            };

            this.FindControl<Button>("SaveFileDialog").Click += async delegate
            {
                var taskPath = new SaveFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string? path = await taskPath;

                if (path != null)
                {
                    var context = this.DataContext as MainWindowViewModel;

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(context.OutputText);
                    }
                }
            };

            this.FindControl<Button>("openSetRegexDialog").Click += async delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                string? regex = await new SetRegexWindow(context.RegularExpression).ShowDialog<string>((Window)this.VisualRoot);
                context.RegularExpression = regex;

                context.InputText = context.InputText;
            };
        }
    }
}
// Who writes these notes?
// \b\w+es\b
