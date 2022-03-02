using System;
using System.Collections.Generic;
using System.Linq;

public class HW1
{
    private static bool CheckNull(int[] customers) // Проверка на то, что кончились покупатели
    {
        bool Null = true;
        for (int i = 0; i < customers.Length; i++)
        {
            if (customers[i] != 0)
            {
                Null = false;
            }
        }
        return Null;
    }
    public static long QueueTime(int[] customers, int n)
    {
        int time = 0;
        while (CheckNull(customers) == false) //если ещё есть покупатели
        {
            for (int i = 0; i < n; i++) //кассы обслуживают
            {
                if (customers[i] == 0) // если обслужили клиента
                {
                    for (int j = 0; j < customers.Length - 1; j++) // "Удаляем клиента" (двигаем в конец)
                    {
                        if (customers[j] == 0)
                        {
                            for(int g = j; g < customers.Length - 1; g++)
                            {
                                int t = customers[g];
                                customers[g] = customers[g + 1];
                                customers[g + 1] = t;
                            } 
                        }
                    }
                }
                if(customers[i] > 0) // если клиента ещё обслуживают то уменьшаем "вес" клиента
                {
                    customers[i]--;
                }

            }
            time++; // увеличиваем время
        }
        
        return time;
    }
}
public class Program
{
    public static void Main (string [] args)
    {
        int[] buyers = new int [] { 5, 3, 4 };
        Console.WriteLine($"Test 1: time = {HW1.QueueTime(buyers, 1)}"); //Ответ 12
        int[] buyers1 = new int[] { 10, 2, 3, 3 };
        Console.WriteLine($"Test 2: time = {HW1.QueueTime(buyers1, 2)}"); //Ответ 10
        int[] buyers2 = new int[] { 2, 3, 10 };
        Console.WriteLine($"Test 3: time = {HW1.QueueTime(buyers2, 2)}"); //Ответ 12
        int[] buyers3 = new int[] { 2, 3, 10 };
        Console.WriteLine($"Test 3: time = {HW1.QueueTime(buyers3, 3)}"); //Ответ 10
        return;
    }
}


