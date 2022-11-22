#include <iostream>
#include <stdlib.h>
#include <conio.h>

using namespace std;

template <class T>
class Node
{
public:
    T data;
    Node *prev, *next;

    static Node* newNode(T data)
    {
        Node *node = (Node*) malloc(sizeof(Node));
        node->data = data;
        node->next = node->prev = NULL;

        return node;
    }
};

template <class T>
class DList
{
public:
    Node<T> *pFirst, *pLast;

    DList()
    {
        pFirst = NULL;
        pLast = NULL;
    }

    void add(T data)
    {
        Node<T> *node = Node<T>::newNode(data);

        if (pFirst == NULL)
        {
            pFirst = pLast = node;
        }
        else
        {
            node->prev = pLast;
            pLast = pLast->next = node;
        }
    }

    void displayAll()
    {
        Node<T>* current = pFirst;
        while(current != NULL)
        {
            cout << current->data << endl;
            current = current->next;
        }
    }

    Node<T>* search(T data)
    {
        Node<T>* current = pFirst;
        while(current != NULL)
        {
            if (current->data == data)
                return current;

            current = current->next;
        }

        return NULL;
    }

    void display(T data)
    {
        cout << search(data)->data;
    }

    void deleteAll()
    {
        Node<T> *temp;
        while (pFirst != NULL)
        {
            temp = pFirst;
            pFirst = pFirst->next;
            free(temp);
        }

        pFirst = NULL;
        pLast  = NULL;
    }

    void deleteNode(Node<T> *node)
    {
        if (node != NULL)
        {
            if (node->prev == NULL)
            {
                pFirst = node->next;
                if (pFirst != NULL)
                    pFirst->prev = NULL;
            }
            else if (node->next == NULL)
            {
                pLast = node->prev;
                pLast->next = NULL;
            }
            else if (pFirst == pLast)
            {
                pFirst = pLast = NULL;
            }
            else
            {
                node->prev->next = node->next;
                node->next->prev = node->prev;
            }

            free(node);
        }
    }

    void deleteData(T data)
    {
        deleteNode(search(data));
    }

    ~DList()

    {
        deleteAll();
    }
};

template <class T>
class Queue
{
    DList<T> arr;
    int length;

    void incrementLength()
    {
        length++;
    }
    void decrementLength()
    {
        length--;
    }

    void setLength(int l)
    {
        length = l;
    }
    int getLength()
    {
        return length;
    }

public:

    Queue()
    {
        setLength(0);
    }

    Queue(const Queue<T> &q)
    {
        setLength(0);
        Node<T>* current = q.arr.pFirst;
        while(current != NULL)
        {
            enqueue(current->data);

            current = current->next;
        }
    }

    bool isFull()
    {
        return false;
    }

    bool isEmpty()
    {
        return getLength() == 0;
    }

    void enqueue(T x)
    {
        arr.add(x);
        incrementLength();
    }

    T dequeue()
    {
        if (isEmpty())
        {
            cout << "Queue is empty, can't dequeue" << endl;
            return T();
        }

        T temp = peek();
        decrementLength();
        arr.deleteNode(arr.pFirst);
        return temp;
    }

    T peek()
    {
        return arr.pFirst->data;
    }

    int getCount()
    {
        return getLength();
    }

    template <class A>
    friend void viewContent(Queue<A>&);

    ~Queue()
    {
        arr.deleteAll();
    }
};

template <class T>
void viewContent(Queue<T> &q)
{
    Node<T>* current = q.arr.pFirst;
    while(current != NULL)
    {
        cout << current->data << endl;

        current = current->next;
    }
}

typedef struct Employee
{
    int ID, Age;
    char Gender, Name[100], Address[200];
    double Salary, OverTime, Deduct;
} Employee;

ostream& operator << (ostream &o, const Employee& emp)
{
    return o << emp.ID << ". " << emp.Name << ", $" << emp.Salary + emp.OverTime - emp.Deduct << endl;
}

int main()
{
    Queue<Employee> q1;

    Employee e1 = {1,25,'M',"Ahmed","st. df.", 2000, 400, 50};
    Employee e2 = {2,28,'M',"Ali","st. df.", 2500, 200, 100};
    Employee e3 = {3,23,'F',"Asmaa","st. df.", 2100, 200, 70};
    Employee e4 = {4,25,'M',"Alaa","st. df.", 2300, 100, 10};

    q1.enqueue(e1);
    q1.enqueue(e2);
    q1.enqueue(e3);
    q1.enqueue(e4);

    cout << "display queue:" << endl;
    viewContent(q1);

    cout << "q2 = q1" << endl;
    Queue<Employee> q2 = q1;

    cout << "\npeek:" << endl;
    cout << q1.peek();

    cout << "\ndequeue:" << endl;
    cout << q1.dequeue();
    cout << "\ncount:" << endl;
    cout << q1.getCount() << endl;

    cout << "\npeek:" << endl;
    cout << q1.peek();

    cout << "\ndequeue:" << endl;
    cout << q1.dequeue();
    cout << "\ncount:" << endl;
    cout << q1.getCount() << endl;
    cout << "\ndequeue:" << endl;
    cout << q1.dequeue();
    cout << "\ndequeue:" << endl;
    cout << q1.dequeue();
    cout << "\ndequeue:" << endl;
    cout << q1.dequeue();

    cout << "\ndisplay q2:" << endl;
    viewContent(q2);

    return 0;
}
