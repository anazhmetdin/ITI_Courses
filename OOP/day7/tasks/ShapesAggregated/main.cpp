#include <iostream>
#include <windows.h>

using namespace std;

class GeoShape
{
protected:
    int d1, d2;

    int getD1()
    {
        return d1;
    }
    int getD2()
    {
        return d2;
    }

    void setD1(int d)
    {
        d1 = d;
    }
    void setD2(int d)
    {
        d2 = d;
    }

public:
    GeoShape(int a = 0, int b = 0)
    {
        d1 = a;
        d2 = b;
    }

    virtual double getArea()
    {
        return d1*d2;
    }
};

class Circle: public GeoShape
{
public:
    Circle(int radius = 0):
        GeoShape(radius, radius) {}

    void setRadius(int radius)
    {
        setD1(radius);
        setD2(radius);
    }

    double getArea()
    {
        return GeoShape::getArea() * 3.14;
    }
};

class MyRectangle: public GeoShape
{
public:
    MyRectangle(int a = 0, int b = 0):
        GeoShape(a, b) {}
};

class Square: public MyRectangle
{
public:
    Square(int a = 0):
        MyRectangle(a, a) {}

    int getD()
    {
        return getD1();
    }

    void setD(int a)
    {
        setD1(a);
        setD2(a);
    }
};

class Triangle: public GeoShape
{
public:
    Triangle(int base = 0, int height = 0):
        GeoShape(base, height) {}

    double getArea()
    {
        return 0.5 * GeoShape::getArea();
    }

    void setBase(int base)
    {
        setD1(base);
    }
    void setHeight(int height)
    {
        setD2(height);
    }

    int getBase()
    {
        return getD1();
    }
    int getHeight()
    {
        return getD2();
    }
};


double getArea(GeoShape** &shapes, int sCount)
{
    double area = 0;

    for (int i = 0; i < sCount; i++)
    {
        area += shapes[i]->getArea();
    }

    return area;
}


int main()
{
    int d1, d2;

    int cCount, rCount, sCount, tCount;

    cout << "Number of circles: ";
    cin >> cCount;
    system("cls");

    cout << "Number of rectanges: ";
    cin >> rCount;
    system("cls");

    cout << "Number of squares: ";
    cin >> sCount;
    system("cls");

    cout << "Number of triangles: ";
    cin >> tCount;
    system("cls");

    int shapesCount = cCount+rCount+sCount+tCount;

    GeoShape** shapes = new GeoShape*[shapesCount];

    int i = 0;
    for (; i < cCount; i++)
    {
        cout << "radius of circle #" << i+1 << ": ";
        cin >> d1;
        shapes[i] = new Circle(d1);
        system("cls");
    }

    for (; i < cCount+rCount; i++)
    {
        cout << "width of rectangle #" << i+1 << ": ";
        cin >> d1;
        cout << "height of rectangle #" << i+1 << ": ";
        cin >> d2;
        shapes[i] = new MyRectangle(d1, d2);
        system("cls");
    }

    for (; i < cCount+rCount+sCount; i++)
    {
        cout << "side of square #" << i+1 << ": ";
        cin >> d1;
        shapes[i] = new Square(d1);
        system("cls");
    }

    for (; i < shapesCount; i++)
    {
        cout << "base of triangle #" << i+1 << ": ";
        cin >> d1;
        cout << "height of triangle #" << i+1 << ": ";
        cin >> d2;
        shapes[i] = new Triangle(d1, d2);
        system("cls");
    }

    cout << "Sum of Areas = " << getArea(shapes, shapesCount) << endl;

    delete []shapes;

    return 0;
}
