#include <iostream>

using namespace std;

class IntArray
{
    int *arr, capacity;

public:
    IntArray(int c = 5)
    {
        capacity = 5;
        arr = new int[c];
        for (int i = 0; i < c; i++)
        {
            arr[i] = 0;
        }
    }

    IntArray(const IntArray &old)
    {
        capacity = old.capacity;
        arr = new int[capacity];
        for (int i = 0; i < capacity; i++)
        {
            arr[i] = old[i];
        }
    }

    ~IntArray()
    {
        delete [] arr;
    }

    IntArray& operator = (const IntArray &old)
    {
        if (&old != this)
        {
            capacity = old.capacity;
            delete []arr;
            arr = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                arr[i] = old[i];
            }
        }
    }

    int& operator [] (int i) const
    {
        return arr[i];
    }

    IntArray operator + (const IntArray &obj)
    {
        const IntArray &largerArr = capacity > obj.capacity ? *this : obj;
        const IntArray smallerArr = capacity <= obj.capacity ? *this : obj;

        IntArray result = IntArray(largerArr);

        for (int i = 0; i < smallerArr.capacity; i++)
        {
            result[i] += smallerArr[i];
        }

        return result;
    }

    int getSize()
    {
        return capacity;
    }
};

int main()
{
    IntArray myA(7);

    for (int i = 0; i < myA.getSize(); i++)
    {
        myA[i] = 3*i;
        cout << myA[i] << " ";
    }

    IntArray myA1 = myA;

    IntArray myA2 = myA + myA1;

    cout << endl;

    for (int i = 0; i < myA2.getSize(); i++)
    {
        cout << myA2[i] << " ";
    }

    return 0;
}
