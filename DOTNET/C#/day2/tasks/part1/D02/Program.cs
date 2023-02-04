using System;

namespace D02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int greatestDist = 0;
            char? targetNumber = null;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == targetNumber)
                {
                    continue;
                }
                for (int j = input.Length - 1; j > i; j--)
                {
                    if (input[i] == input[j] && greatestDist < j - i - 1)
                    {
                        greatestDist = j - i - 1;
                        targetNumber = input[i];
                        break;
                    }
                }
            }

            Console.WriteLine(greatestDist + " - " + targetNumber);
        }
    }
}