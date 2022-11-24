#include <iostream>

using namespace std;

template <class T>
class Node
{
public:
    T data;
    Node *left, *right;

    static Node* newNode(T data)
    {
        Node *node = new Node;
        node->data = data;
        node->left = node->right = NULL;

        return node;
    }
};

template <class T>
class BST
{
    void add(Node<T> *&root, T data)
    {
        if (root == NULL)
        {
            root = Node<T>::newNode(data);
        }
        else if (data < root->data)
        {
            add(root->left, data);
        }
        else if (data > root->data)
        {
            add(root->right, data);
        }
    }

    void add(Node<T> *root, Node<T> *leaf, T data)
    {
        if (leaf == NULL)
        {
            if (root == NULL)
            {
                root = Node<T>::newNode(data);
            }
            else
            {
                if (data < root->data)
                {
                    root->left = Node<T>::newNode(data);
                }
                else if (data > root->data)
                {
                    root->right = Node<T>::newNode(data);
                }
            }
        }
        else if (data < leaf->data)
        {
            add(leaf, leaf->left, data);
        }
        else if (data > leaf->data)
        {
            add(leaf, leaf->right, data);
        }
    }

    void deleteData(Node<T> *&root, T data)
    {
        if (data < root->data) {deleteData(root->left, data);}
        else if (data > root->data) {deleteData(root->right, data);}
        else {deleteNode(root);}
    }

    void deleteNode(Node<T> *&node)
    {
        Node<T> * toBeDeleted = node;

        if (node->left == NULL)
        {
            node = node->right;
        }
        else if (node->right == NULL)
        {
            node = node->left;
        }
        else
        {
            toBeDeleted = getMax(node->left);
            if (toBeDeleted != NULL)
                node->data = toBeDeleted->data;
            else
                node = NULL;
        }

        if (toBeDeleted != NULL)
            delete toBeDeleted;
    }

    Node<T>* getMax(Node<T>* root)
    {
        if (root == NULL) return NULL;
        else if (root->right == NULL) return root;
        else return getMax(root->right);
    }

    Node<T>** toArray(int length)
    {
        int index = 0;
        Node<T>** arr = new Node<T>*[length];
        toArray(root, arr, index);

        return arr;
    }

    void toArray(Node<T>* root, Node<T>** &arr, int &index)
    {
        if (root != NULL)
        {
            toArray(root->left, arr, index);
            arr[index++] = root;
            toArray(root->right, arr, index);
        }
    }

    void arrayToBST(Node<T>** &arr, int first, int last)
    {
        if (first <= last)
        {
            int middle = (first + last) / 2;
            add(root, arr[middle]->data);
            arrayToBST(arr, first, middle-1);
            arrayToBST(arr, middle+1, last);
        }
    }

    void balance()
    {
        int length = countNodes();
        Node<T>** arr = toArray(length);
        root = NULL;
        arrayToBST(arr, 0, length-1);
        delete []arr;
    }

    int countNodes(Node<T> *root)
    {
        if (root != NULL)
        {
            return countNodes(root->left) + 1 + countNodes(root->right);
        }

        return 0;
    }

    Node<T>* searchData(T data, Node<T> *root)
    {
        if (root != NULL)
        {
            if (root->data == data) {return root;}

            Node<T> *foundLeft = searchData(data, root->left);
            if (foundLeft != NULL) {return foundLeft;}

            Node<T> *foundRight = searchData(data, root->right);
            if (foundRight != NULL) {return foundRight;}
        }

        return NULL;
    }

    void printNode(T &data, int depth, T &parent)
    {
        if (depth != 0)
            cout << data << " - depth: " << depth << " - parent: " << parent << endl;
        else
            cout << data << " - depth: " << depth << " - root " << endl;
    }

    void traversePre(Node<T> *root, int depth = 0, T parent = T())
    {
        if (root != NULL)
        {
            printNode(root->data, depth, parent);

            traversePre(root->left, depth+1, root->data);
            traversePre(root->right, depth+1, root->data);
        }
    }
    void traverseIn(Node<T> *root, int depth = 0, T parent = T())
    {
        if (root != NULL)
        {
            traverseIn(root->left, depth+1, root->data);

            printNode(root->data, depth, parent);

            traverseIn(root->right, depth+1, root->data);
        }
    }
    void traversePost(Node<T> *root, int depth = 0, T parent = T())
    {
        if (root != NULL)
        {
            traversePost(root->left, depth+1, root->data);
            traversePost(root->right, depth+1, root->data);

            printNode(root->data, depth, parent);
        }
    }
public:
    Node<T> *root;

    BST()
    {
        root = NULL;
    }

    int countNodes()
    {
        return countNodes(root);
    }

    Node<T>* searchData(T data)
    {
        return searchData(data, root);
    }

    void traverse(int mode = 0)
    {
        if (mode == 0)
            traversePre(root);
        else if (mode == 1)
            traverseIn(root);
        else if (mode == 2)
            traversePost(root);
    }

    void add(T data)
    {
        add(root, data);
        balance();
    }

    void add2(T data)
    {
        add(root, root, data);
        balance();
    }

    void deleteData(T data)
    {
        deleteData(root, data);
        balance();
    }
};

int main()
{
    BST<int> tree;

    for (int i = 0; i < 4; i++)
        tree.add(i);

    cout << "first insert function" << endl;
    tree.traverse();

    cout << "----------" << endl;

    for (int i = 0; i < 4; i++)
        tree.add2(i);

    cout << "second insert function, duplicates" << endl;
    tree.traverse();

    cout << "----------" << endl;

    for (int i = 4; i < 8; i++)
        tree.add2(i);

    cout << "second insert function, new data" << endl;
    tree.traverse();

    cout << "----------" << endl;

    tree.deleteData(0);
    tree.deleteData(7);
    tree.deleteData(3);

    cout << "delete 0,7,3" << endl;
    tree.traverse();

    cout << "----------" << endl;

    cout << "search for 6,1" << endl;
    cout << tree.searchData(6)->data << endl;
    cout << tree.searchData(1)->data << endl;

    cout << "----------" << endl;

    cout << "count nodes" << endl;
    cout << tree.countNodes() << endl;

    return 0;
}
