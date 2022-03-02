using Lab3;

public class Program
{
    public static void Main(string[] args)
    {
        RomanNumber r = new RomanNumber(65535);
        Console.WriteLine(r.ToString());
        int n = 5;
        Random random = new Random();
        RomanNumber[] A_Test = {
            new RomanNumber((ushort)(random.Next(0, ushort.MaxValue)/3)),
            new RomanNumber((ushort)(random.Next(0, ushort.MaxValue)/3)),
            new RomanNumber((ushort)(random.Next(0, ushort.MaxValue)/3)),
            new RomanNumber((ushort)(random.Next(0, ushort.MaxValue)/3)),
            new RomanNumber((ushort)(random.Next(0, ushort.MaxValue)/3))
        };

        try
        {
            RomanNumber result = A_Test[0] / A_Test[1]; // /
            Console.WriteLine("Result : " + result.ToString());
        }
        catch (RomanNumberException e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            try
            {
                RomanNumber result = A_Test[2] + A_Test[3]; //+
                Console.WriteLine("Result : " + result.ToString());
            }
            catch (RomanNumberException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                try
                {
                    RomanNumber result = A_Test[3] - A_Test[4]; //-
                    Console.WriteLine("Result : " + result.ToString());
                }
                catch (RomanNumberException e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    try
                    {
                        RomanNumber result = A_Test[0] * A_Test[1]; // *
                        Console.WriteLine("Result : " + result.ToString());
                    }
                    catch (RomanNumberException e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Array.Sort(A_Test);
                        Console.WriteLine("\nОтсортированный массив:");
                        for (int i = 0; i < A_Test.Length; i++)
                        {
                            Console.WriteLine(A_Test[i].ToString());
                        }
                    }
                }
            }

        }
    }
}
