#include <iostream>
#include <conio.h>

using namespace std;

template <class T>
class Queue
{
    T *arr;
    int head, tail;
    int capacity, length;

    void incrementHead()
    {
        if (getHead() + 1 == getCapacity())
            setHead(0);
        else
            setHead(getHead() + 1);
    }
    void incrementTail()
    {
        if (getTail() + 1 == getCapacity())
            setTail(0);
        else
            setTail(getTail() + 1);
    }
    void incrementLength()
    {
        length++;
    }
    void decrementLength()
    {
        length--;
    }

    int getHead()
    {
        return head;
    }
    int getTail()
    {
        return tail;
    }

    void setHead(int h)
    {
        head = h;
    }
    void setTail(int t)
    {
        tail = t;
    }

    void setLength(int l)
    {
        length = l;
    }
    int getLength()
    {
        return length;
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
    T getArrI(int i)
    {
        return arr[i];
    }

public:

    Queue(int c = 5)
    {
        setHead(0);
        setTail(0);
        setLength(0);
        setCapacity(c > 0 ? c : 5);
        initArr(getCapacity());
    }

    bool isFull()
    {
        return getCapacity() == getLength();
    }

    bool isEmpty()
    {
        return getLength() == 0;
    }

    void enqueue(int x)
    {
        if (isFull())
        {
            cout << "Queue is full, can't enqueue" << endl;
        }
        else
        {
            setArrI(getTail(), x);
            incrementTail();
            incrementLength();
        }
    }

    T dequeue()
    {
        if (isEmpty())
        {
            cout << "Queue is empty, can't dequeue" << endl;
            return -1;
        }
        else
        {
            int temp = peek();
            incrementHead();
            decrementLength();
            return temp;
        }
    }

    T peek()
    {
        if (isEmpty())
        {
            cout << "Queue is empty, can't peek" << endl;
            return -1;
        }
        else
        {
            return getArrI(getHead());
        }
    }

    int getCount()
    {
        return getLength();
    }

    ~Queue()
    {
        delete []arr;
    }
};


int main()
{
    int input, option;

    cout << "Enter the queue size: ";

    cin >> input;

    Queue<int> q = Queue<int>(input);

    do
    {
        cout << "\n1- enqueue\n2- dequeue\n3- peek\n4- count\n0- exit\n\nPlease enter your option: ";
        cin >> option;

        switch (option)
        {
        case 1:
            cout << "Enter the value: ";
            cin >> input;
            q.enqueue(input);
            break;
        case 2:
            cout << q.dequeue()  << endl;
            break;
        case 3:
            cout << q.peek() << endl;
            break;
        case 4:
            cout << q.getCount() << endl;
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
