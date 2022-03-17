using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reactive;
using System.Text.RegularExpressions;
using ReactiveUI;
using Lab5;
using Lab5.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;


namespace Lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string pathOpFile;
        string pathSvFile;
        string inputText;
        string outputText;
        
        string regularValue;
        bool regularStart = false;
        string Result;

        

        public MainWindowViewModel(){ }

        public string InputText
        {
            get { return inputText; }
            set { 
                this.RaiseAndSetIfChanged(ref inputText, value);
            }
        }
        public string OutputText
        {
            get {
                return outputText;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref outputText, value);
            }
        }

        public bool RegularStart
        {
            get { return regularStart; }
            set
            {
                this.RaiseAndSetIfChanged(ref regularStart, value);
                if (regularStart == true)
                {
                    OutputText = "";
                    foreach (Match match in Regex.Matches(InputText, RegularValue))
                    {
                        OutputText += match.Value + "\n";
                    }
                }
                else
                {
                    
                }
            }
        }

        public string RegularValue
        {
            get { return regularValue; }
            set
            {
                regularValue = value;
            }
        }


        public string pathOpenFile
        {
            get { return pathOpFile; }
            set
            {
                this.RaiseAndSetIfChanged(ref pathOpFile, value);
                TextFromPath();

            }
        }
        public string pathSaveFile
        {
            get { return pathSvFile; }
            set
            {
                this.RaiseAndSetIfChanged(ref pathSvFile, value);
                try
                {
                    string[] temp = new string[1];
                    temp[0] = OutputText;
                    File.WriteAllLines(pathSvFile, temp);
                }
                catch (Exception ex) 
                {
                    OutputText = ex.Message;
                }
            }
        }

        public void TextFromPath() 
        {
            try
            {
                string[]? readText = File.ReadAllLines(pathOpenFile);
                string temp = "";

                if(readText == null)
                {
                    InputText = "";
                    return;
                }

                foreach(string s in readText)
                {
                    temp += s;
                }
                InputText = temp;
            }
            catch (Exception ex)
            {
                InputText = ex.Message;
            }
        }

    }
}
