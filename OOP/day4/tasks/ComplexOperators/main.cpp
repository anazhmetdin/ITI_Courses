#include <iostream>
#include <string.h>

using namespace std;

/// class to represent imaginary numbers
class Complex
{
    int real;
    int imaginary;
    char op; // operator of the imaginary number

    void setOp()
    {
        op = getImaginary() < 0 ? '-' : '+';
    }

    char getOp()
    {
        return op;
    }

public:

    Complex(int r = 0, int i = 0)
    {
        //cout << "\nRegular Constructor: " << this << endl;
        setReal(r);
        setImaginary(i);
    }

    Complex(Complex &c)
    {
        //cout << "\nCopy Constructor: " << this << endl;
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

    Complex operator +(const Complex &r)
    {
        return Complex(getReal() + r.getReal(), getImaginary() + r.getImaginary());
    }

    Complex operator - (const Complex &r)
    {
        return Complex(getReal() - r.getReal(), getImaginary() - r.getImaginary());
    }

    Complex operator - (const int &r)
    {
        return Complex(getReal() - r, getImaginary());
    }

    Complex& operator -= (const Complex &b)
    {
        *this = *this - b;
        return *this;
    }

    Complex& operator -= (const int &b)
    {
        *this = *this - Complex(b);
        return *this;
    }

    Complex& operator -- ()
    {
        setReal(getReal() - 1);
        return *this;
    }

    Complex operator -- (int)
    {
        Complex temp = Complex(*this);
        setReal(getReal() - 1);
        return temp;
    }

    bool operator == (const Complex &b)
    {
        return getReal() == b.getReal() && getImaginary() == b.getImaginary();
    }

    bool operator != (const Complex &b)
    {
        return getReal() != b.getReal() || getImaginary() != b.getImaginary();
    }

    bool operator > (const Complex &b)
    {
        return getReal() > b.getReal() || ( getReal() == b.getReal() && getImaginary() > b.getImaginary());
    }

    bool operator >= (const Complex &b)
    {
        return !(*this < b);
    }

    bool operator < (const Complex &b)
    {
        return !(*this > b);
    }

    bool operator <= (const Complex &b)
    {
        return !(*this > b);
    }

    operator int()
    {
        return getReal();
    }

    operator char*()
    {
        string result;

        // if the real part isn't zero, print it
        if (getReal() != 0)
        {
            result += to_string(getReal()) + " ";
        }

        // if the imaginary part isn't zero, print it
        if (getImaginary() != 0)
        {
            // if the real part wasn't 0, print the imaginary number with space
            if (getReal() != 0)
            {
                result += getOp();
                result += " " + to_string(abs(getImaginary())) + "i";
            }
            // if real is 0, print without spaces
            else
                result += getImaginary() + "i";
        }

        // if both 0, print 0
        if (getReal() == 0 && getImaginary() == 0)
        {
            result += "0";
        }

        char *c = new char[result.length() + 1];
        strcpy(c, result.c_str());
        return c;
    }

    ~Complex()
    {
        //cout << "\ndestructor: " << this << endl;
        setReal(0);
        setImaginary(0);
    }
};


Complex operator - (const int &a, const Complex &b)
{
    return Complex(a) - b;
}

int& operator -= (int &a, const Complex &b)
{
    a = a - b.getReal();
    return a;
}

int main()
{
    Complex c1 = Complex(4, 3);
    Complex c2 = Complex(-6, -5);

    int x = 7;

    cout << (char*)c1 << endl;
    cout << (char*)c2 << endl;
    cout << endl;

    cout << "1.  c1 -  c2 = " << (char*)(c1 - c2) << endl;
    cout << endl;
    cout << "2.  7  -  c2 = " << (char*)(x - c2) << endl;
    cout << endl;
    cout << "3.  c1 -  7  = " << (char*)(c1 - x) << endl;
    cout << endl;
    cout << "4.  c1 -= c2 = " << (char*)(c1 -= c2) << endl;
    cout << endl;
    cout << "5.  c1 -= 7  = " << (char*)(c1 -= x) << endl;
    cout << endl;
    cout << "6.  7  -= c2 = " << (int)(x -= c1) << endl;
    cout << endl;
    cout << "7.  --c2     = " << (char*)(--c2) << endl;
    cout << endl;
    cout << "8.  c2--     = " << (char*)(c2--) << endl;
    cout << endl;
    cout << "9.  c1 == c2 = " << (c1 == c2) << endl;
    cout << endl;
    cout << "10. c1 != c2 = " << (c1 != c2) << endl;
    cout << endl;
    cout << "11. c1 >  c2 = " << (c1 > c2) << endl;
    cout << "    c1 >= c2 = " << (c1 >= c2) << endl;
    cout << endl;
    cout << "12. c1 <  c2 = " << (c1 < c2) << endl;
    cout << "    c1 <= c2 = " << (c1 <= c2) << endl;
    cout << endl;
    cout << endl;
    cout << "13. (int)c1  = " << (int)(c1) << endl;
    return 0;
}
