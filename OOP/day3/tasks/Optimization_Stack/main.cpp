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
    int  getPos()
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
    int getCapacity()
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
    int  getArrI(int i)
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
        cout << "Copy Constructor: " << this << endl;
        setPos(0);
        setCapacity(stk.getCapacity());
        initArr(getCapacity());
        for (int i = 0; i < getCapacity(); i++)
        {
            push(stk.getArrI(i));
        }
    }

    Stack(int c)
    {
        cout << "Regular Constructor: " << this << endl;
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
        cout << "Destructor: " << this << endl;
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
};


void viewContent(Stack stk)
{
    for (int i = 0; i < stk.getCapacity(); i++)
    {
        cout << i << "- " << stk.getArrI(i) << endl;
    }
}


int main()
{
    int input, option;

    cout << "Enter the stack size: ";

    cin >> input;

    Stack stk = Stack(input);

    do
    {
        cout << "\n1- push\n2- pop\n3- peek\n4- count\n5- view\n6- reverse().pop()\n0- exit\n\nPlease enter your option: ";
        cin >> option;

        switch (option)
        {
        case 1:
            cout << "Enter the value: ";
            cin >> input;
            stk.push(input);
            break;
        case 2:
            cout << stk.pop()  << endl;
            break;
        case 3:
            cout << stk.peek() << endl;
            break;
        case 4:
            cout << stk.getCount() << endl;
            break;
        case 5:
            viewContent(stk);
            break;
        case 6:
            cout << "first element in the reversed stack: " << stk.reverseStack().peek() << endl;
            cout << "first element in the original stack: " << stk.peek() << endl;
            break;
        case 0:
            cout << "Good bye!" << endl;
            break;

        default:
            cout << "Invalid option" << endl;
            break;
        }

        _getch();
        system("cls");
    }
    while (option != 0);

    return 0;
}
