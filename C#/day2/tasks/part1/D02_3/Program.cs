namespace D02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            int case1Sum = 0;

            Console.WriteLine("Running case 1");
            for (int i = 1; i < 100000000; i++)
            {
                case1Sum += (i.ToString().Split("1").Length - 1);
                if (i % 5000000 == 0)
                {
                    Console.Write("|");
                }
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Case 1 milliseconds: " + elapsedMs + ", found: " + case1Sum);

            //////////////////////////////////////////////////////////////////

            watch = System.Diagnostics.Stopwatch.StartNew();

            int case2Sum = 0;
            int current;

            Console.WriteLine("Running case 2");
            for (int i = 1; i < 100000000; i++)
            {
                current = i;
                while (current != 0)
                {
                    case2Sum += current % 10 == 1 ? 1 : 0;
                    current /= 10;
                }
                if (i % 5000000 == 0)
                {
                    Console.Write("|");
                }
            }

            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Case 2 milliseconds: " + elapsedMs + ", found: " + case2Sum);

            //////////////////////////////////////////////////////////////////

            watch = System.Diagnostics.Stopwatch.StartNew();

            int case3Sum = 0;

            Console.WriteLine("Running case 3");
            case3Sum = (int)Math.Log10(100000000) * 100000000 / 10;

            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Case 3 milliseconds: " + elapsedMs + ", found: " + case3Sum);
        }
    }
}