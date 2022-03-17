using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Reactive;
using ReactiveUI;
using System.Text.RegularExpressions;

namespace RegexApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string regularExpression = String.Empty;
        string inputText = String.Empty;
        string outputText = String.Empty;


        public string RegularExpression
        { 
            get => regularExpression;
            set
            {
                if (value is not null)
                {
                    regularExpression = value;
                }
            }
        }

        public string OutputText
        {
            get => outputText;
            set
            {
                if (RegularExpression != "")
                    this.RaiseAndSetIfChanged(ref outputText, value);
                else
                    this.RaiseAndSetIfChanged(ref outputText, "Enter regular expression (button 'Set Regex')");
            }
        }

        public string InputText
        {
            get => inputText;
            set
            {
                OutputText = "";

                if (RegularExpression != "")
                {
                    Regex rgx = new Regex(RegularExpression);
                    foreach (Match match in rgx.Matches(value))
                        OutputText += match.Value + "\n";
                }
                this.RaiseAndSetIfChanged(ref inputText, value);

            }
        }
    }
}
