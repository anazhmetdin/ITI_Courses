#include <iostream>

using namespace std;

class QueueLinear
{
    int *arr;
    int tail;
    int capacity;

    void incrementTail()
    {
        setTail(getTail() + 1);
    }
    void decrementTail()
    {
        setTail(getTail() - 1);
    }

    int  getTail()
    {
        return tail;
    }
    void setTail(int t)
    {
        tail = t;
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

    QueueLinear()
    {
        setTail(0);
        setCapacity(5);
        initArr(getCapacity());
    }

    QueueLinear(int c)
    {
        setTail(0);
        setCapacity(c > 0 ? c : 5);
        initArr(getCapacity());
    }

    bool isFull()
    {
        return getCapacity() == getTail();
    }

    bool isEmpty()
    {
        return getTail() == 0;
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
        }
    }

    int dequeue()
    {
        if (isEmpty())
        {
            cout << "Queue is empty, can't dequeue" << endl;
            return -1;
        }
        else
        {
            int temp = getArrI(0);

            for (int i = 0; i < getTail(); i++)
                setArrI(i, getArrI(i+1));

            decrementTail();
            return temp;
        }
    }

    int peek()
    {
        if (isEmpty())
        {
            cout << "Queue is empty, can't peek" << endl;
            return -1;
        }
        else
        {
            return getArrI(0);
        }
    }

    int getCount()
    {
        return getTail();
    }

    ~QueueLinear()
    {
        delete []arr;
    }
};


int main()
{
    int input, option;

    cout << "Enter the queue size: ";

    cin >> input;

    QueueLinear qLinear = QueueLinear(input);

    do
    {
        cout << "\n1- enqueue\n2- dequeue\n3- peek\n4- count\n0- exit\n\nPlease enter your option: ";
        cin >> option;

        switch (option)
        {
        case 1:
            cout << "Enter the value: ";
            cin >> input;
            qLinear.enqueue(input);
            break;
        case 2:
            cout << qLinear.dequeue()  << endl;
            break;
        case 3:
            cout << qLinear.peek() << endl;
            break;
        case 4:
            cout << qLinear.getCount() << endl;
            break;
        case 0:
            cout << "Good bye!" << endl;
            break;

        default:
            cout << "Invalid option" << endl;
            break;
        }
    }
    while (option != 0);

    return 0;
}
