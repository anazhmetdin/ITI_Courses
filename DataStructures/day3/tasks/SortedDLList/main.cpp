#include <iostream>

using namespace std;

template <class T>
class Node
{
public:
    T data;
    Node *prev, *next;

    static Node* newNode(T data)
    {
        Node *node = new Node;
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
            delete temp;
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
class SortedDList: public DList<T>
{
public:
    void add(T data)
    {
        if (DList<T>::pFirst == NULL || data >= DList<T>::pLast->data)
        {
            DList<T>::add(data);
        }
        else
        {
            Node<T> *node = Node<T>::newNode(data);
            if (DList<T>::pFirst == DList<T>::pLast)
            {
                node->next = DList<T>::pLast;
                DList<T>::pFirst = DList<T>::pLast->prev = node;
            }
            else
            {
                Node<T>* temp = DList<T>::pFirst;
                while (temp != NULL)
                {
                    if (data >= temp->data)
                    {
                        temp = temp->next;
                    }
                    else
                    {
                        node->next = temp;

                        if (temp == DList<T>::pFirst)
                        {
                            DList<T>::pFirst = node;
                        }
                        else
                        {
                            temp->prev->next = node;
                        }

                        temp->prev = node;
                        break;
                    }
                }
            }
        }
    }
};

int main()
{
    SortedDList<int> sDList;

    sDList.add(5);
    sDList.add(1);
    sDList.add(6);
    sDList.add(3);
    sDList.add(5);
    sDList.add(8);

    sDList.displayAll();

    return 0;
}
