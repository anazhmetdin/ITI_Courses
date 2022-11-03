#include <iostream>
#include <graphics.h>
#include <conio.h>
#include <windows.h>

using namespace std;

class ShapeColor
{
    int color;
public:
    ShapeColor(int c = 0)
    {
        color = c;
    }

    void setColor(int c)
    {
        color = c;
    }

    int getColor()
    {
        return color;
    }
};

class Shape: public ShapeColor
{
public:
    Shape(int color): ShapeColor(color) {}
    virtual void draw() = 0;
};

class Point
{
    int x, y;
public:
    Point(int c1 = 0, int c2 = 0)
    {
        x = c1;
        y = c2;
    }
    int getX()
    {
        return x;
    }
    int getY()
    {
        return y;
    }
    void setX(int c)
    {
        x = c;
    }
    void setY(int c)
    {
        y = c;
    }
    void show()
    {
        cout << x << "," << y << endl;
    }
};

class MyRectangle: public Shape
{
    Point ul, lr;
public:
    MyRectangle(int p1x, int p1y, int p2x, int p2y, int clr):
        Shape(clr), ul(p1x, p1y), lr(p2x, p2y){}

    void draw()
    {
        setcolor(getColor());
        rectangle(ul.getX(), ul.getY(), lr.getX(), lr.getY());
    }
};

class Line: public Shape
{
    Point p1, p2;
public:
    Line(int p1x, int p1y, int p2x, int p2y, int clr):
        Shape(clr), p1(p1x, p1y), p2(p2x, p2y){}

    void draw()
    {
        setcolor(getColor());
        line(p1.getX(), p1.getY(), p2.getX(), p2.getY());
    }
};

class Triangle: public Shape
{
    Point p1, p2, p3;
public:
    Triangle(int p1x, int p1y, int p2x, int p2y, int p3x, int p3y, int clr):
        Shape(clr), p1(p1x, p1y), p2(p2x, p2y), p3(p3x, p3y){}

    void draw()
    {
        setcolor(getColor());
        line(p1.getX(), p1.getY(), p2.getX(), p2.getY());
        line(p1.getX(), p1.getY(), p3.getX(), p3.getY());
        line(p2.getX(), p2.getY(), p3.getX(), p3.getY());
    }
};

class Circle: public Shape
{
    Point center;
    int radius;
public:
    Circle(int centerX, int centerY, int r, int clr):
        Shape(clr), center(centerX, centerY)
    {
        radius = r;
    }

    void draw()
    {
        setcolor(getColor());
        circle(center.getX(), center.getY(), radius);
    }
};

class Picture
{
    MyRectangle* rPtr;
    int rCount;

    Triangle* tPtr;
    int tCount;

    Line* lPtr;
    int lCount;

    Circle* cPtr;
    int cCount;

public:
    Picture(MyRectangle* _rPtr=NULL, int _rCount=0, Triangle* _tPtr=NULL,
            int _tCount=0, Line* _lPtr=NULL, int _lCount=0, Circle* _cPtr=NULL, int _cCount=0)
    {
        rPtr=_rPtr;
        rCount = _rCount;

        tPtr=_tPtr;
        tCount = _tCount;

        lPtr=_lPtr;
        lCount = _lCount;

        cPtr=_cPtr;
        cCount = _cCount;
    }

    void draw()
    {
        for (int i = 0; i < rCount; i++)
        {
            rPtr[i].draw();
        }
        for (int i = 0; i < tCount; i++)
        {
            tPtr[i].draw();
        }
        for (int i = 0; i < lCount; i++)
        {
            lPtr[i].draw();
        }
        for (int i = 0; i < cCount; i++)
        {
            cPtr[i].draw();
        }
    }

    ~Picture()
    {
        delete []rPtr;
        delete []cPtr;
        delete []lPtr;
        delete []tPtr;
    }
};


class PictureEnhanced
{
    Shape** shapes;
    int sCount;

public:
    PictureEnhanced()
    {
        shapes = NULL;
        sCount = 0;
    }

    PictureEnhanced(Shape** _shapes, int _sCount)
    {
        if (_sCount > 0)
        {
            shapes = _shapes;
            sCount = _sCount;
        }
        else
            PictureEnhanced();
    }

    PictureEnhanced(int _sCount)
    {
        if (_sCount > 0)
        {
            newShapes(_sCount);
        }
        else
            PictureEnhanced();
    }

    void newShapes(int _sCount)
    {
        if (_sCount > 0)
        {
            if (shapes != NULL)
                delete []shapes;

            sCount = _sCount;
            shapes = new Shape*[sCount];
        }
    }

    Shape* &operator[] (int i)
    {
        return shapes[i];
    }

    void draw()
    {
        for (int i = 0; i < sCount; i++)
        {
            if (shapes[i] != NULL)
                shapes[i]->draw();
        }
    }

    ~PictureEnhanced()
    {
        for (int i = 0; i < sCount; i++)
        {
            delete shapes[i];
        }

        delete []shapes;
    }
};


int main()
{
    initgraph();

    int yOffset = 100;

    int color = 2;

    MyRectangle *rectangles = new MyRectangle[1] {MyRectangle(496, 382+yOffset, 650, 434+yOffset, color)};

    Triangle *triangles = new Triangle[1] {Triangle(532, 399+yOffset, 518, 420+yOffset, 546, 419+yOffset, color)};

    Line *lines = new Line[4] {Line(600, 380+yOffset, 600, 300+yOffset, color),
                               Line(544, 380+yOffset, 544, 300+yOffset, color),
                               Line(622, 81+yOffset, 644, 237+yOffset, color),
                               Line(524, 81+yOffset, 502, 237+yOffset, color)};

    Circle *circles = new Circle[2] {Circle(573, 237+yOffset, 142, color),
                                    Circle(573, 81+yOffset, 98, color)};

    Picture picture = Picture(rectangles, 1, triangles, 1, lines, 4, circles, 2);

    picture.draw();

    cout << "press any key to use the enhanced version" << endl;
    _getch();
    system("cls");

    // enhanced picture
    color = 6;
    Shape **shapes = new Shape*[8]{new MyRectangle(496, 382+yOffset, 650, 434+yOffset, color),
                                   new Triangle(532, 399+yOffset, 518, 420+yOffset, 546, 419+yOffset, color),
                                   new Line(600, 380+yOffset, 600, 300+yOffset, color),
                                   new Line(544, 380+yOffset, 544, 300+yOffset, color),
                                   new Line(622, 81+yOffset, 644, 237+yOffset, color),
                                   new Line(524, 81+yOffset, 502, 237+yOffset, color),
                                   new Circle(573, 237+yOffset, 142, color),
                                   new Circle(573, 81+yOffset, 98, color)};

    PictureEnhanced pictureE (shapes, 8);

    pictureE.draw();

    return 0;
}
