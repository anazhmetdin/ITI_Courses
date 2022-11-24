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

    int countNodes(Node<T> *root)
    {
        if (root != NULL)
        {
            return countNodes(root->left) + 1 + countNodes(root->right);
        }

        return 0;
    }

    Node<T>* searchData(T data)
    {
        return searchData(data, root);
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

    void traverse()
    {
        traverse(root);
    }

    void traverse(Node<T> *root)
    {
        if (root != NULL)
        {
            traverse(root->left);
            cout << root->data << endl;
            traverse(root->right);
        }
    }

    void add(T data)
    {
        add(root, data);
    }

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

    void add2(T data)
    {
        add(root, root, data);
    }

    void add(Node<T> *root, Node<T> *leaf, T data)
    {
        if (leaf == NULL)
        {
            if (root == NULL)
                root = Node<T>::newNode(data);

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

    void deleteData(T data)
    {
        deleteData(root, data);
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
            node->data = toBeDeleted->data;
        }

        delete toBeDeleted;
    }

    Node<T>* getMax(Node<T>* root)
    {
        if (root == NULL) return NULL;
        else return getMax(root->right);
    }
};

template <class T>
class AVL
{

};

int main()
{
    BST<int> tree;

    for (int i = 0; i < 4; i++)
        tree.add(i);

    tree.traverse();

    cout << "----------" << endl;

    for (int i = 0; i < 4; i++)
        tree.add2(i);

    tree.traverse();

    cout << "----------" << endl;

    for (int i = 4; i < 8; i++)
        tree.add2(i);

    tree.traverse();

    cout << "----------" << endl;

    tree.deleteData(0);
    tree.deleteData(7);
    tree.deleteData(3);

    tree.traverse();

    cout << "----------" << endl;

    cout << tree.searchData(6)->data << endl;
    cout << tree.searchData(1)->data << endl;

    return 0;
}
