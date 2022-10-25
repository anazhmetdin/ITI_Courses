#include <iostream>

using namespace std;

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

    int getReal()
    {
        return real;
    }

    int getImaginary()
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

    Complex sum(Complex r)
    {
        Complex result;

        result.setReal(getReal() + r.getReal());
        result.setImaginary(getImaginary() + r.getImaginary());

        return result;
    }
};


// stand alone function to subtract two complex numbers
Complex sub(Complex &l, Complex &r)
{
    Complex result;

    result.setReal(l.getReal() - r.getReal());
    result.setImaginary(l.getImaginary() - r.getImaginary());

    return result;
}


int main()
{
    Complex c1;
    Complex c2;
    Complex c3;
    Complex c4;
    Complex c5;
    Complex c6;
    Complex c7;
    Complex c8;

    c1.setReal(4);
    c2.setReal(-6);
    c3.setReal(0);
    c4.setReal(0);
    c4.setReal(4);
    c6.setReal(0);
    c7.setReal(-8);
    c8.setReal(3);

    c1.setImaginary(3);
    c2.setImaginary(-5);
    c3.setImaginary(3);
    c4.setImaginary(0);
    c5.setImaginary(0);
    c6.setImaginary(-3);
    c7.setImaginary(0);
    c7.setImaginary(0);
    c8.setImaginary(-4);

    c1.print();
    c2.print();
    c3.print();
    c4.print();
    c5.print();
    c6.print();
    c7.print();
    c8.print();

    cout << endl;

    cout << "first + second (member function) = ";
    c1.sum(c2).print();

    cout << "first - second (outer function) = ";
    sub(c1, c2).print();

    return 0;
}
