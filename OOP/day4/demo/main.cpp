#include <iostream>

using namespace std;

class dummy;

/// class to represent imaginary numbers
class Complex
{
    int real;
    int imaginary;
    char op; // operator of the imaginary number

    char getOp()
    {
        return op;
    }

    void setOp()
    {
        op = getImaginary() < 0 ? '-' : '+';
    }

public:

    int x[5] = {};

    Complex(int r, int i)
    {
        cout << "\nRegular Constructor: " << this << endl;
        setReal(r);
        setImaginary(i);
    }

    Complex(Complex &c)
    {
        cout << "\nCopy Constructor: " << this << endl;
        setReal(c.getReal());
        setImaginary(c.getImaginary());
    }

    int getReal() const
    {
        return real;
    }

    int getImaginary() const
    {
        return imaginary;
    }

    void setReal(int r)
    {
        real = r;
    }

    void setImaginary(int i)
    {
        imaginary = i;

        setOp();
    }

    void print()
    {
        // if the real part isn't zero, print it
        if (getReal() != 0)
        {
            cout << getReal() << " ";
        }

        // if the imaginary part isn't zero, print it
        if (getImaginary() != 0)
        {
            // if the real part wasn't 0, print the imaginary number with space
            if (getReal() != 0)
                cout << getOp() << " " << abs(getImaginary()) << "i";
            // if real is 0, print without spaces
            else
                cout << getImaginary() << "i";
        }

        // if both 0, print 0
        if (getReal() == 0 && getImaginary() == 0)
        {
            cout << 0;
        }

        cout << endl;
    }

    Complex sum(Complex &r)
    {
        return Complex(getReal() + r.getReal(), getImaginary() + r.getImaginary());
    }

    Complex operator+ (const Complex &r)
    {
        return Complex(getReal() + r.getReal(), getImaginary() + r.getImaginary());
    }

    Complex operator++ (int)
    {
        Complex temp (getReal(), getImaginary());
        real++;
        return temp;
    }

    Complex& operator++ ()
    {
        setReal(getReal()+1);
        return *this;
    }

    ~Complex()
    {
        cout << "\ndestructor: " << this << endl;
        setReal(0);
        setImaginary(0);
    }
};


class dummy
{
public:
    int x;

    dummy(int y)
    {
        cout << "dummy constructor from integer" << endl;
        x = y;
    }

    dummy(const Complex &c)
    {
        cout << "dummy constructor from complex" << endl;
        x = c.getReal();
    }

    operator Complex()
    {
        cout << "type casting from dummy to complex" << endl;
        return Complex(x, x);
    }
};


int main()
{
    Complex c1 = Complex(4, 3);
    Complex c2 = Complex(-6, -5);

    c1.sum(c2).print();
    (c1 + c2).print();

    // this is logic error, because the second c1 will have the increased value
    ((c1++)+c1).print();
    (++c1).print();

    c1.x[0] = 5;
    // this will copy element by element
    c2 = c1;

    // won't change c2
    c1.x[0] = 3;

    // 5
    cout << c2.x[0] << endl;

    // constructor
    dummy d1 = static_cast<Complex>(c1);
    // constructor
    dummy d2 = c1;
    // type casting
    Complex c3 = d1;

    return 0;
}
