namespace DSnA.DataStructures
{// Riley contributed this code
    public class Node
    {
        public int Value;
        public Node Left, Right;

        public Node(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }
    public class BinarySearchTree
    {
        private Node root;
        private Random random = new Random();

        public void Insert(int value)
        {
            root = InsertRecursive(root, value);
        }

        private Node InsertRecursive(Node node, int value)
        {
            if (node == null)
                return new Node(value);
            if (value < node.Value)
                node.Left = InsertRecursive(node.Left, value);
            else
                node.Right = InsertRecursive(node.Right, value);
            return node;
        }

        public bool Search(int value)
        {
            return SearchRecursive(root, value);
        }

        private bool SearchRecursive(Node node, int value)
        {
            if (node == null)
                return false;
            if (value == node.Value)
                return true;
            else if (value < node.Value)
                return SearchRecursive(node.Left, value);
            else
                return SearchRecursive(node.Right, value);
        }
    }
}
