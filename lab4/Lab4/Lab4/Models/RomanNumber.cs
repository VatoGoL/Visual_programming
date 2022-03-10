using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanNumbr;

namespace RomanNumbr
{
    public class RomanNumber : ICloneable, IComparable
    {
        internal ushort number;

        //Конструктор получает число n, которое должен представлять объект
        //класса
        public RomanNumber(ushort n)
        {
            if(n < ushort.MinValue || n > ushort.MaxValue || n == 0)
            {
                throw new RomanNumberException("Аргумент выходит за диапазон значений");
            }
            number = n;
        }
        //Сложение римских чисел
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            if(n1 == null || n2 == null)
            {
                throw new RomanNumberException("Передаваемые аргументы содержат null");
            }
            if ((n1.number+n2.number) < ushort.MinValue || (n1.number + n2.number) > ushort.MaxValue)
            {
                throw new RomanNumberException("Результат сложения аргументов выходит за диапазон значений ushort");
            }
            return new RomanNumber((ushort)(n1.number + n2.number));
        }
        //Вычитание римских чисел
        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("Передаваемые аргументы содержат null");
            }
            if ((n1.number - n2.number) < ushort.MinValue || (n1.number - n2.number) > ushort.MaxValue)
            {
                throw new RomanNumberException("Результат разницы аргументов выходит за диапазон значений ushort");
            }
            return new RomanNumber((ushort)(n1.number - n2.number));
        }
        //Умножение римских чисел
        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("Передаваемые аргументы содержат null");
            }
            if ((n1.number * n2.number) < ushort.MinValue || (n1.number * n2.number) > ushort.MaxValue)
            {
                throw new RomanNumberException("Результат умножения аргументов выходит за диапазон значений ushort");
            }
            return new RomanNumber((ushort)(n1.number * n2.number));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("Передаваемые аргументы содержат null");
            }
            if(n2.number == 0)
            {
                throw new RomanNumberException("Второй агрумент равен 0, деление на 0 недопустимо");
            }
            return new RomanNumber((ushort)(n1.number / n2.number));
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            string value = "";
            ushort n = number;
            if(n/10000 != 0)
            {
                switch (n / 10000)
                {
                    case 1:
                        value += "_X";
                        break;
                    case 2:
                        value += "_X_X";
                        break;
                    case 3:
                        value += "_X_X_X";
                        break;
                    case 4:
                        value += "_X_L";
                        break;
                    case 5:
                        value += "_L";
                        break;
                    case 6:
                        value += "_L_X";
                        break;
                }
            }
            n %= 10000;
            if (n / 1000 != 0)
            {
                switch (n / 1000)
                {
                    case 1:
                        value += "M";
                        break;
                    case 2:
                        value += "MM";
                        break;
                    case 3:
                        value += "MMM";
                        break;
                    case 4:
                        value += "M_V";
                        break;
                    case 5:
                        value += "_V";
                        break;
                    case 6:
                        value += "_VM";
                        break;
                    case 7:
                        value += "_VMM";
                        break;
                    case 8:
                        value += "_VMMM";
                        break;
                    case 9:
                        value += "M_X";
                        break;
                }
            }
            n %= 1000;
            if (n / 100 != 0)
            {
                switch (n / 100)
                {
                    case 1:
                        value += "C";
                        break;
                    case 2:
                        value += "CC";
                        break;
                    case 3:
                        value += "CCC";
                        break;
                    case 4:
                        value += "CD";
                        break;
                    case 5:
                        value += "D";
                        break;
                    case 6:
                        value += "DC";
                        break;
                    case 7:
                        value += "DCC";
                        break;
                    case 8:
                        value += "DCCC";
                        break;
                    case 9:
                        value += "CM";
                        break;
                }
            }
            n %= 100;
            if (n / 10 != 0)
            {
                switch (n / 10)
                {
                    case 1:
                        value += "X";
                        break;
                    case 2:
                        value += "XX";
                        break;
                    case 3:
                        value += "XXX";
                        break;
                    case 4:
                        value += "XL";
                        break;
                    case 5:
                        value += "L";
                        break;
                    case 6:
                        value += "LX";
                        break;
                    case 7:
                        value += "LXX";
                        break;
                    case 8:
                        value += "LXXX";
                        break;
                    case 9:
                        value += "XC";
                        break;
                }
            }
            n %= 10;
            switch (n)
            {
                case 1:
                    value += "I";
                    break;
                case 2:
                    value += "II";
                    break;
                case 3:
                    value += "III";
                    break;
                case 4:
                    value += "IV";
                    break;
                case 5:
                    value += "V";
                    break;
                case 6:
                    value += "VI";
                    break;
                case 7:
                    value += "VII";
                    break;
                case 8:
                    value += "VIII";
                    break;
                case 9:
                    value += "IX";
                    break;
            }
            return value;

            //throw new NotImplementedException();
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(this.number);
            //throw new NotImplementedException();
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if(obj is RomanNumber)
            {
                return this.number.CompareTo(((RomanNumber)obj).number);
            }
            throw new RomanNumberException("Некорректное значение параметра!");
        }
    }
}
