using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RegexApp.Views
{
    public partial class SetRegexWindow : Window
    {
        public SetRegexWindow(string regularExpression) : this()
        {
            this.FindControl<TextBox>("regularExpressionTextBox").Text = regularExpression;
        }
        public SetRegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();

            this.FindControl<Button>("okButton").Click += async delegate
            {
                var regularExpression = this.FindControl<TextBox>("regularExpressionTextBox").Text;
                if (regularExpression != null)
                    Close(regularExpression);
                Close("");
            };
#endif      
            this.FindControl<Button>("cancelButton").Click += async delegate
            {
                Close("");
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
