namespace D05
{
    class Point3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Point3D(float x) : this()
        {
            X = x;
        }
        public Point3D(float x, float y) : this(x)
        {
            Y = y;
        }
        public Point3D(float x, float y, float z) : this(x, y)
        {
            Z = z;
        }
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public static implicit operator string(Point3D p)
        {
            return p.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                Point3D other = (Point3D)obj;

                return other.X == X && other.Y == Y && other.Z == Z;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point3D p = new Point3D(10, 10, 10);

            Console.WriteLine(p.ToString());
            Console.WriteLine(p);

            Point3D p1 = new(), p2 = new();

            float x, y, z;
            bool parsed = false;

            do
            {
                Console.WriteLine("X for p1:");
            } while (!float.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.WriteLine("y for p1:");
                try { y = Convert.ToSingle(Console.ReadLine()); parsed = true; } catch { }
            } while (!parsed);

            parsed = false;
            do
            {
                Console.WriteLine("z for p1:");
                try { z = float.Parse(Console.ReadLine()); parsed = true; } catch { }
            } while (!parsed);

            string? point;

            parsed = false;
            do
            {
                do
                {
                    Console.WriteLine("Point 2: x,y,z");
                } while ((point = Console.ReadLine()) == null);

                string[] cordinates = point.Split(',');

                if (cordinates.Length == 3 && float.TryParse(cordinates[0], out x) &&
                    float.TryParse(cordinates[1], out y) && float.TryParse(cordinates[2], out z))
                {
                    parsed = true;
                }
            } while (!parsed);


            Console.WriteLine("p1 == p2: " + p1 == p2);
            Console.WriteLine("p1.Equals(p2): " + p1.Equals(p2));
        }
    }
}