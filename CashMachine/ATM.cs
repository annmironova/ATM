using System;
using System.Collections.Generic;

namespace ATM
{
    internal class ATM
    {
        static void Main(string[] args)
        {
            long sumForExchange = GetSum();
            long[] values = GetValues().ToArray();
            Console.WriteLine("Result: ");
            if (values.Length == 0) 
            {
                Console.WriteLine("No combinations!");
                return; 
            }
            long[] currentCombination = new long[values.Length];
            int ways = ExchangeWays(values, currentCombination, sumForExchange, values.Length - 1);
            if (ways == 0)
            {
                Console.WriteLine("No combinations!");
            }
        }

        static long GetSum()
        {
            long sumForExchange = 0;
            Console.WriteLine("Input total sum:");
            try
            {
                sumForExchange = Convert.ToInt64(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error, invalid value! Try again");
                GetSum();
            }
            return sumForExchange;
        }

        static List<long> GetValues()
        {
            Console.WriteLine("Input values:");
            SortedSet<string> strValues = new SortedSet<string>();
            List<long> values = new List<long>();
            string input;
            do
            {
                input = Console.ReadLine();
                if (input != "0")
                {
                    strValues.Add(input);
                }
            } while (input != "0");

            foreach (var element in strValues)
            {
                try
                {
                    long value = Int64.Parse(element);
                    if (value > 0)
                    {
                        values.Add(value);
                    }
                    else
                    {
                        Console.WriteLine($"Error, invalid value '{element}' will be skipped!");
                    }
                }
                catch
                {
                    Console.WriteLine($"Error, invalid value '{element}' will be skipped!");
                }
            }
            return values;
        }

        static int ExchangeWays(long[] values, long[] combination, long sum, int l)
        {
            if (l != 0)
            {
                int ways = 0;
                for (long i = sum / values[l]; i > -1; i--)
                {
                    combination[l] = i;
                    ways += ExchangeWays(values, combination, sum - values[l] * combination[l], l - 1);
                }
                return ways;
            }
            else
            {
                if (sum % values[0] == 0)
                {
                    combination[0] = sum / values[0];
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (combination[i] != 0)
                        {
                            Console.Write($"{values[i]}$ - {combination[i]}; ");
                        }
                    }
                    Console.WriteLine();
                    return 1;
                }
                else
                { 
                    return 0; 
                }
            }
        }

    }
}
