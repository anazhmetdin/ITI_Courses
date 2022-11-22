#include <iostream>

using namespace std;

template <class T>
void _merge(T* arr, int lFirst, int lLast, int rFirst, int rLast, int (*compare)(T, T))
{
    T* tempArr = new T[rLast - lFirst];
    int index = 0;
    int saveFirst = lFirst;

    while ((lFirst <= lLast) && (rFirst <= rLast))
    {
        if (compare(arr[lFirst], arr[rFirst]) > 0)
            tempArr[index++] = arr[lFirst++];
        else
            tempArr[index++] = arr[rFirst++];
    }

    while (lFirst <= lLast)
        tempArr[index++] = arr[lFirst++];

    while (rFirst <= rLast)
        tempArr[index++] = arr[rFirst++];

    for (int i = 0; i <= rLast-saveFirst; i++)
    {
        arr[i+saveFirst] = tempArr[i];
    }
}

// sort array in-place using the the comparison function
template <class T>
void mergeSort(T* arr, int first, int last, int (*compare)(T, T))
{
    if (first < last)
    {
        int middle = (first + last) / 2;
        mergeSort(arr, first, middle, compare);
        mergeSort(arr, middle+1, last, compare);
        _merge<T>(arr, first, middle, middle+1, last, compare);
    }
}

// print array in one line
template <class T>
void printArray(T* arr, int n)
{
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;
}

// comparison function
int greaterThan(int x, int y)
{
    return x-y;
}

// comparison function
int lessThan(int x, int y)
{
    return y-x;
}

int main()
{
    int arr[] = {64, 25, 12, 22, 11};

    cout << "Unsorted array: \n";
    printArray<int>(arr, 5);

    mergeSort<int>(arr, 0, 4, &greaterThan);

    cout << "Sorted array descendantly: \n";
    printArray<int>(arr, 5);


    mergeSort<int>(arr, 0, 4, &lessThan);

    cout << "Sorted array ascendantly: \n";
    printArray<int>(arr, 5);

    return 0;
}
