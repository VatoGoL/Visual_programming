using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ReactiveUI;
using lab_7.Models;
using Avalonia.Media;

namespace lab_7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            List<Student> students = MakeStudents();
            foreach (var student in students)
                student.PropertyChanged += ContentCollectionChanged;
            Items = new ObservableCollection<Student>(students);
            resetAverage();
        }
        ObservableCollection<Student> items;
        public ObservableCollection<Student> Items
        {
            get
            {
                return items;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref items, value);
            }
        }
        private List<Student> MakeStudents()
        {
            return new List<Student>
            {
                new Student("�������", "������", "��-023", new string[5] {"0","0","0","0","0"}),
                new Student("�������", "�������", "��-023", new string[5] {"1","1","1","1","1"}),
                new Student("������", "����", "��-011", new string[5] {"2","2","2","2","2"}),
                new Student("������", "��������", "��-032", new string[5] {"0","1","2","0","1"}),
                new Student("�����", "���", "��-031", new string[5] {"0","2","1","0","2"}),
                new Student("���������", "����", "��-011", new string[5] {"2","2","2","1","2"}),
                new Student("����������", "����", "��-011", new string[5] {"2","0","2","0","2"}),
                new Student("��������", "��������", "��-0012", new string[5] {"0","1","0","1","0"}),
                new Student("�����", "��������", "?", new string[5] {"0","2","0","2","0"}),
                new Student("������", "���������", "!", new string[5] {"1","0","1","0","1"})
            };
        }
        public void resetAverage()
        {
            int i;
            double x;
            int count = 0;
            for (i = 0; i < 5; i++)
            {
                this[i] = 0;
            }
            foreach (var item in Items)
            {
                for (i = 0; i < 5; i++)
                {
                    if (!Double.TryParse(item[i], out x))
                        break;
                }
                if (i == 5)
                {
                    for (i = 0; i < 5; i++)
                    {
                        this[i] += Double.Parse(item[i]);
                    }
                    count++;
                }
            }
            if (count != 0)
                for (i = 0; i < 5; i++)
                {
                    this[i] /= count;
                    if (this[i] < 1) Brush[i] = Brushes.Red;
                    if (this[i] >= 1.5) Brush[i] = Brushes.Green;
                    if (this[i] >= 1 && this[i] < 1.5) Brush[i] = Brushes.Yellow;
                }
            else
            {
                for (i = 0; i < 5; i++)
                    Brush[i] = Brushes.White;
            }
        }
        public void ContentCollectionChanged(object? sender, PropertyChangedEventArgs e)
        {
            resetAverage();
        }

        double[] average = new double[] { 0D, 0D, 0D, 0D, 0D };
        public double this[int i]
        { get { return average[i]; } set { this.RaiseAndSetIfChanged(ref average[i], value); } }

        MyBrush brush = new MyBrush();
        MyBrush Brush { get { return brush; } set { this.RaiseAndSetIfChanged(ref brush, value); } }
    }
}
