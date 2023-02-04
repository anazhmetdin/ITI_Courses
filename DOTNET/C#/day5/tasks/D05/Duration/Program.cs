namespace Duration
{
    class Duration
    {
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public int Seconds { get; set; } = 0;

        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes:{Minutes}, Seconds:{Seconds}";
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                Duration other = (Duration)obj;
                return other.Hours == Hours && other.Minutes == Minutes && other.Seconds == Seconds;
            }

            return false;
        }
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(int seconds)
        {
            Seconds = seconds % 60;
            Minutes = seconds / 60 % 60;
            Hours = seconds / (60 * 60) % 60;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Duration operator +(Duration a, Duration b)
        {
            return new Duration(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);
        }

        public static Duration operator +(Duration a, int seconds)
        {
            return a + new Duration(seconds);
        }
        public static Duration operator +(int seconds, Duration a)
        {
            return new Duration(seconds) + a;
        }
        public static Duration operator ++(Duration a)
        {
            return new Duration(a.Hours, a.Minutes + 1, a.Seconds);
        }
        public static Duration operator --(Duration a)
        {
            return new Duration(a.Hours, a.Minutes - 1, a.Seconds);
        }
        public static Duration operator -(Duration a)
        {
            return new Duration(a.Hours * -1, a.Minutes * -1, a.Seconds * -1);
        }
        public static bool operator >(Duration a, Duration b)
        {
            return a.Hours > b.Hours && a.Minutes > b.Minutes && a.Seconds > b.Seconds;
        }
        public static bool operator <(Duration a, Duration b)
        {
            return a.Hours < b.Hours && a.Minutes < b.Minutes && a.Seconds < b.Seconds;
        }
        public static bool operator >=(Duration a, Duration b)
        {
            return a.Equals(b) || a > b;
        }
        public static bool operator <=(Duration a, Duration b)
        {
            return a.Equals(b) || a < b;
        }

        public static implicit operator bool(Duration a)
        {
            return a == null;
        }

        public static implicit operator DateTime(Duration a)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, a.Hours, a.Minutes, a.Seconds);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration D = new Duration(1, 10, 15);
            Console.WriteLine(D.ToString());

            Duration D1 = new Duration(3600);
            Console.WriteLine(D1.ToString());


            Duration D2 = new Duration(7800);
            Console.WriteLine(D2.ToString());

            Duration D3 = D1 + D2;
            D3 = D1 + 7800;
            D3 = 666 + D3;
            D3 = D1++;
            D3 = --D2;
            D1 = -D2;
            if(D1 > D2)
            {
                Console.WriteLine("> works");
            }
            if(D1 <= D2)
            {
                Console.WriteLine("<= works");
            }
            if (D1)
            {
                Console.WriteLine("bool cast works");
            }
            D1 = new Duration(3600);
            DateTime Obj = (DateTime)D1;
        }
    }
}