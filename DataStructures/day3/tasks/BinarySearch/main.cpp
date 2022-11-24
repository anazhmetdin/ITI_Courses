#include <iostream>

using namespace std;

template <class T>
int BSRecursive(T *&arr, int value, int first, int last)
{
    if (first <= last)
    {
        int middle = (first + last)/2;
        if (arr[middle] == value) {return middle;}
        else if (arr[middle] > value) {return BSRecursive(arr, value, first, middle-1);}
        else if (arr[middle] < value) {return BSRecursive(arr, value, middle+1, last);}
    }
    return -1;
}

template <class T>
int BSIterative(T *&arr, int value, int length)
{
    int first = 0, last = length - 1;
    int middle;
    while (first <= last)
    {
        middle = (first + last)/2;
        if (arr[middle] == value) {return middle;}
        else if (arr[middle] > value) {last = middle-1;}
        else if (arr[middle] < value) {first = middle+1;}
    }
    return -1;
}

int main()
{
    int *arr = new int[10] {0,1,2,3,4,5,6,7,8,9};

    cout << "recursive search for 2: " << BSRecursive<int>(arr, 2, 0, 9) << endl;
    cout << "recursive search for 0: " << BSRecursive<int>(arr, 0, 0, 9) << endl;
    cout << "recursive search for 9: " << BSRecursive<int>(arr, 9, 0, 9) << endl;
    cout << "recursive search for 10: " << BSRecursive<int>(arr, 10, 0, 9) << endl << endl;


    cout << "iterative search for 2: " << BSIterative<int>(arr, 2, 10) << endl;
    cout << "iterative search for 0: " << BSIterative<int>(arr, 0, 10) << endl;
    cout << "iterative search for 9: " << BSIterative<int>(arr, 9, 10) << endl;
    cout << "iterative search for 10: " << BSIterative<int>(arr, 10, 10) << endl;

    delete []arr;
    return 0;
}
