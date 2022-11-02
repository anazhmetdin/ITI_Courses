#include <iostream>
#include <windows.h>

using namespace std;

class GeoShape
{
    int d1, d2;
public:
    GeoShape(int a, int b)
    {
        d1 = a;
        d2 = b;
    }

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

    double getArea()
    {
        return d1*d2;
    }
};

class Circle: protected GeoShape
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

class Square: protected MyRectangle
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

    int getArea()
    {
        return GeoShape::getArea();
    }
};

class Triangle: protected GeoShape
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

double getArea(Circle* cPtr, int cCount, MyRectangle* rPtr, int rCount,
               Square* sPtr, int sCount, Triangle* tPtr, int tCount)
{
    double area = 0;

    for (int i = 0; i < cCount; i++)
    {
        area += cPtr[i].getArea();
    }
    for (int i = 0; i < rCount; i++)
    {
        area += rPtr[i].getArea();
    }
    for (int i = 0; i < sCount; i++)
    {
        area += sPtr[i].getArea();
    }
    for (int i = 0; i < tCount; i++)
    {
        area += tPtr[i].getArea();
    }

    return area;
}

int main()
{
    int d1, d2;

    Circle* cPtr;
    int cCount;

    MyRectangle* rPtr;
    int rCount;

    Square* sPtr;
    int sCount;

    Triangle* tPtr;
    int tCount;

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

    cPtr = new Circle[cCount];
    rPtr = new MyRectangle[rCount];
    sPtr = new Square[sCount];
    tPtr = new Triangle[tCount];

    for (int i = 0; i < cCount; i++)
    {
        cout << "radius of circle #" << i+1 << ": ";
        cin >> d1;
        cPtr[i] = Circle(d1);
        system("cls");
    }

    for (int i = 0; i < rCount; i++)
    {
        cout << "width of rectangle #" << i+1 << ": ";
        cin >> d1;
        cout << "height of rectangle #" << i+1 << ": ";
        cin >> d2;
        rPtr[i] = MyRectangle(d1, d2);
        system("cls");
    }

    for (int i = 0; i < sCount; i++)
    {
        cout << "side of square #" << i+1 << ": ";
        cin >> d1;
        sPtr[i] = Square(d1);
        system("cls");
    }

    for (int i = 0; i < tCount; i++)
    {
        cout << "base of triangle #" << i+1 << ": ";
        cin >> d1;
        cout << "height of triangle #" << i+1 << ": ";
        cin >> d2;
        tPtr[i] = Triangle(d1, d2);
        system("cls");
    }


    cout << "Sum of Areas = " << getArea(cPtr, cCount, rPtr, rCount,
            sPtr, sCount, tPtr, tCount) << endl;;

    return 0;
}
