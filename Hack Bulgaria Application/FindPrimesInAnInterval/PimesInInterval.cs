using System;
using System.Collections.Generic;

class PrimesInInterval
{
    static void Main()
    {
        Console.WriteLine("Please add start number:");
        int startNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Please add end number:");
        int endNumber = int.Parse(Console.ReadLine());

        List<int> primeNumbers = FindPrimesInAnInterval(startNumber, endNumber);

        foreach (int number in primeNumbers)
        {
            Console.Write(number + " ");
        }
                
    }

    public static List<int> FindPrimesInAnInterval(int startNumber, int endNumber)
    {
        if (startNumber > endNumber)
        {
            throw new ArgumentException("Start number has to be lower or equal to end number");
        }

        if (!(startNumber > 0 && endNumber > 0))
        {
            throw new ArgumentOutOfRangeException("Both numbers have to be positive");
        }

        List<int> primeNumbers = new List<int>();

        for (int i = startNumber; i <= endNumber; i++)
        {
            if (IsPrime(i))
            {
                primeNumbers.Add(i);
            }
        }

        return primeNumbers;
    }

    public static bool IsPrime(int number)
    {
        if (number == 1)
        {
            return false;
        }

        for (int i = 2; i < Math.Sqrt(number) + 1 && i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        
        return true;
    }
}