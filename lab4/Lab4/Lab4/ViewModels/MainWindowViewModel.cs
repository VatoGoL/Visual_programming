using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using RomanNumbr;

namespace Lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text;
        string Rim_Num = "";
        string Action = "";
        bool End = false;

        public MainWindowViewModel()
        {
            ClickButton = ReactiveCommand.Create<string, string>(
                (val) =>
                {
                    try
                    {
                        if (val != "=")
                        {
                            if ((val == "+" || val == "-" || val == "*" || val == "/") && Action == "")
                            {
                                Rim_Num = Text;
                                Action = val;
                            }
                            Text += val;
                        }
                        else
                        {
                            if (End == false)
                            {
                                string temp = Text.Remove(0, Rim_Num.Length + Action.Length);

                                RomanNumberExtend N1 = new RomanNumberExtend(Rim_Num);
                                RomanNumberExtend N2 = new RomanNumberExtend(temp);

                                RomanNumber t1 = new RomanNumber(N1.number);
                                RomanNumber t2 = new RomanNumber(N2.number);
                                RomanNumber Result = new RomanNumber(63000);

                                if (Action == "+")
                                {
                                    Result = RomanNumber.Add(t1, t2);
                                }
                                else if (Action == "-")
                                {
                                    Result = RomanNumber.Sub(t1, t2);
                                }
                                else if (Action == "*")
                                {
                                    Result = RomanNumber.Mul(t1, t2);
                                }
                                else if (Action == "/")
                                {
                                    Result = RomanNumber.Div(t1, t2);
                                }

                                Text = "Result: " + Result.ToString();

                                Action = "";
                                Rim_Num = "";
                                End = true;
                            }
                            else
                            {
                                Text = "";
                                End = false;
                            }

                        }
                        return val;
                    }
                    catch (RomanNumberException e)
                    {
                        Text = e.Message;
                        return val;
                    }
                    
                }
            );
        }
        
        public string Text
        {
            set
            {
                this.RaiseAndSetIfChanged(ref text, value);
            }
            get
            {
                return text;
            }
        }
        
        public ReactiveCommand<string, string> ClickButton { get; }
        
        
        
        
    }
}
