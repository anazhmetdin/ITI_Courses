

// 2.
//a. Add Circle & Square & Triangle & Cube
//b. Add function to get volume for the supported shapes
//c. noting that cube shape only support volume calculation

public interface Shape2D
{
    public double GetArea();
}
public abstract class Shape3D
{
    public abstract double GetVolume();
}

public class Rectangle : Shape2D
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double GetArea()
    {
        return Height * Width;
    }
}

public class Circle : Shape2D
{
    public double Radius { get; set; }
    public double GetArea()
    {
        return 3.14 * Radius * Radius;
    }
}

public class Cube : Shape3D
{
    public double Side { get; set; }
    public double GetVolume()
    {
        return Math.Pow(Side, 3);
    }
}

public class AreaCalculator
{
    public double TotalArea(Shape2D[] arrObjects)
    {
        double area = 0;
        foreach (var obj in arrObjects)
        {
            area += obj.GetArea();
        }
        return area;
    }
}
