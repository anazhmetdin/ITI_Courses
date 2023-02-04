namespace D03_4
{
    internal class Program
    {
        public static void printList(float[] presentVolume, float[] presentPrice, float[,] spending)
        {
            for (int i = 0; i < spending.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("_\t\t\t0\t1\t3\t4\t5\t6");
                    Console.WriteLine("___________________________________________________");
                    Console.Write(i + ":\t" + "   -   " + "   \t");
                }
                else
                    Console.Write(i + ":\t" + presentPrice[i-1] + "-" + presentVolume[i-1] + "   \t");
                for (int j = 0; j < spending.GetLength(1); j++)
                {
                    Console.Write(spending[j,j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static float PresentList(float budget, float bagVolume, int people,
            int Npresents, float[] presentVolume, float[] presentPrice)
        {
            int rows = Npresents + 1;
            int cols = (int)Npresents / people + 1;
            int height = (int)Npresents / people + 1;

            float[,,] spending = new float[rows, cols, height];

            for (int i = 0; i < rows; i++)
            {
                spending[i,0] = 0;
            }

            for (int j = 0; j < cols; j++)
            {
                spending[0, j] = 0;
            }

            printList(presentVolume, presentPrice, spending);

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    
                }
            }

            return 0;
        }

        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            Console.SetIn(reader);

            float budget = float.Parse(Console.ReadLine()!);
            float bagVolume = float.Parse(Console.ReadLine()!);
            int people = Int32.Parse(Console.ReadLine()!);
            int Npresents = Int32.Parse(Console.ReadLine()!);

            float[] presentVolume = new float[Npresents];
            float[] presentPrice = new float[Npresents];

            for (int i = 0;i < Npresents; i++)
            {
                presentVolume[i] = float.Parse(Console.ReadLine()!);
                presentPrice[i] = float.Parse(Console.ReadLine()!);
            }

            Array.Sort(presentPrice, presentVolume);
            Array.Sort(presentVolume);

            float spending = PresentList(budget, bagVolume, people, Npresents, presentVolume, presentPrice);

            Console.WriteLine("\nSpendings = " + spending);

        }
    }
}