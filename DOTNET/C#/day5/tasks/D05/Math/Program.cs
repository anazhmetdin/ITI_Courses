namespace Math
{
    public static class Math
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static bool Divide(double x, double y, out double result)
        {
            try
            {
                result = x / y;
                return true;
            }
            catch {
                result = default;
                return false;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("5+5=" + Math.Add(5, 5));
            Console.WriteLine("5-5=" + Math.Subtract(5, 5));
            double r;
            if (Math.Divide(6, 5, out r))
                Console.WriteLine("6/5=" + r);
            Console.WriteLine("5*5=" + Math.Multiply(5, 5));
        }
    }
}