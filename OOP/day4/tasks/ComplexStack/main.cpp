#include <iostream>
#include <stdlib.h>
#include <conio.h>

using namespace std;

class Stack
{
    int *arr;
    int pos;
    int capacity;

    void incrementPos()
    {
        pos++;
    }
    void decrementPos()
    {
        pos--;
    }
    int  getPos() const
    {
        return pos;
    }
    void setPos(int p)
    {
        pos = p;
    }

    void setCapacity(int c)
    {
        capacity = c;
    }
    int getCapacity() const
    {
        return capacity;
    }

    void initArr(int c)
    {
        arr = new int[c];
    }
    void setArrI(int i, int x)
    {
        arr[i] = x;
    }
    int  getArrI(int i) const
    {
        return arr[i];
    }

public:

    Stack()
    {
        setPos(0);
        setCapacity(5);
        initArr(getCapacity());
    }

    Stack(Stack &stk)
    {
        // cout << "Copy Constructor: " << this << endl;
        setPos(0);
        setCapacity(stk.getCapacity());
        initArr(getCapacity());
        for (int i = 0; i < stk.getPos(); i++)
        {
            push(stk.getArrI(i));
        }
    }

    Stack(int c)
    {
        // cout << "Regular Constructor: " << this << endl;
        setPos(0);
        setCapacity(c > 0 ? c : 5);
        initArr(getCapacity());
    }

    bool isFull()
    {
        return getCapacity() == getPos();
    }

    bool isEmpty()
    {
        return getPos() == 0;
    }

    void push(int x)
    {
        if (isFull())
        {
            cout << "Stack is full, can't push" << endl;
        }
        else
        {
            setArrI(getPos(), x);
            incrementPos();
        }
    }

    int pop()
    {
        if (isEmpty())
        {
            cout << "Stack is empty, can't pop" << endl;
            return -1;
        }
        else
        {
            decrementPos();
            return getArrI(getPos());
        }
    }

    int peek()
    {
        if (isEmpty())
        {
            cout << "Stack is empty, can't peek" << endl;
            return -1;
        }
        else
        {
            return getArrI(getPos() - 1);
        }
    }

    int getCount()
    {
        return getPos();
    }

    ~Stack()
    {
        // cout << "Destructor: " << this << endl;
        for (int i = 0; i < getCapacity(); i++)
        {
            setArrI(i, -1);
        }
        delete []arr;
    }

    friend void viewContent(Stack);

    Stack reverseStack()
    {
        Stack reversed = Stack(getCapacity());

        for (int i = getPos() - 1; i >= 0; i--)
        {
            reversed.push(getArrI(i));
        }

        return reversed;
    }

    Stack& operator = (const Stack &r)
    {
        if (&r != this)
        {
            delete []arr;
            setPos(0);
            setCapacity(r.getCapacity());
            initArr(getCapacity());
            for (int i = 0; i < r.getPos(); i++)
            {
                push(r.getArrI(i));
            }
        }

        return *this;
    }

    Stack operator + (const Stack &r)
    {
        Stack result = Stack(getCapacity() + r.getCapacity());

        for (int i = 0; i < getPos(); i++)
        {
            result.push(getArrI(i));
        }

        for (int i = 0; i < r.getPos(); i++)
        {
            result.push(r.getArrI(i));
        }

        return result;
    }

    int& operator [] (const int &i)
    {
        return arr[i];
    }
};


void viewContent(Stack stk)
{
    for (int i = 0; i < stk.getPos(); i++)
    {
        cout << i << "- " << stk.getArrI(i) << endl;
    }
}


int main()
{

    Stack stk1 = Stack(5), stk2 = Stack(4);

    stk1.push(1);
    stk1.push(2);
    stk1.push(3);

    stk2.push(4);
    stk2.push(5);

    cout << "stk 1" << endl;
    viewContent(stk1);
    cout << "stk 2" << endl;
    viewContent(stk2);

    cout << "stk 3 = stk1 + stk2" << endl;
    Stack stk3 = stk1 + stk2;


    cout << "stk3.peek()" << endl;
    cout << stk3.peek() << endl;

    cout << "stk3[3]" << endl;
    cout << stk3[3] << endl;

    cout << "stk3[3] = -1" << endl;
    stk3[3] = -1;

    cout << "stk3[3]" << endl;
    cout << stk3[3] << endl;

    return 0;
}
