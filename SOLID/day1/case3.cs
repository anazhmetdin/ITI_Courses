
public abstract class Shape2D
{
    public abstract double GetArea();
}

public class Rectangle : Shape2D
{
    public double Height { get; set; }
    public double Width { get; set; }

    public Rectangle(double height, double width) {
        Height = height;
        Width = width;
    }

    public double GetArea()
    {
        return Height * Width;
    }
}

public class Square : Shape2D
{
    public double Side { get; set; }

    public Square(double side) {
        Side = side;
    }

    public double GetArea()
    {
        return Side * Side;
    }
}