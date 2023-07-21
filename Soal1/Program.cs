using System;

class Soal1
{
    static string A000124(int n)
    {
        int[] output = new int[n];
        int currentNumber = 1;
        for (int i = 0; i < n; i++)
        {
            output[i] = currentNumber;
            currentNumber += (i + 1);
        }
        return string.Join("-", output);
    }

    static void Main(string[] args)
    {
        try
        {
            Console.Write("Input: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Input yang dimasukkan salah");
            }
            else
            {
                string result = A000124(n);
                Console.WriteLine("Output: " + result);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Input yang dimasukkan salah");
        }
    }
}
