using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA
{
    public class SinglyLinkedList
    {

        public class Node
        {
            public Node? Next;
            public object Data;

            public Node(Node? next, object data)
            {
                this.Next = next;
                this.Data = data;
            }

            public Node(object data)
            {
                this.Next = null;
                this.Data = data;
            }
        }

        private Node? root = null;

        public Node? First { get { return root; } set { root = value; } }

        public Node? Last
        {
            get
            {
                Node? curr = root;
                if (curr == null) { return null; }
                while (curr.Next != null) { curr = curr.Next; }
                return curr;
            }
        }

        public static SinglyLinkedList CreateListFromArray(int[] arr)
        {
            SinglyLinkedList sll = new SinglyLinkedList();
            foreach (var item in arr.Reverse())  // Reverse to insert at the beginning
            {
                sll.InsertFirst(item);
            }
            return sll;
        }

        public static SinglyLinkedList CreateRandSLL(int size, int range)
        {
            Random rand = new Random();
            SinglyLinkedList list = new SinglyLinkedList();

            if (size <= 0) return list;

            list.First = new Node(rand.Next(1, range));

            Node current = list.First;

            for (int i = 1; i < size; i++)
            {
                current.Next = new Node(rand.Next(1, range));
                current = current.Next;
            }

            return list;
        }

        public static void Print(SinglyLinkedList sll)
        {
            if (sll.IsEmpty()) { Console.WriteLine("List is empty"); return; }
            Node temp = sll.root;
            while (temp != null)
            {
                Console.Write($"{temp.Data} -> ");
                temp = temp.Next;
            }
        }

        public Node? FindParent(Node a)
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Empty list or no root");
                return null;
            }
            Node? temp = this.root;
            while (temp.Next.Data != a.Data)
            {
                if (temp == null) { Console.WriteLine($"Couldn't find {a.Data}'s parent"); }
                temp = temp.Next;
            }
            return temp;
        }

        public Node Find(Node a)
        {
            Node? temp = this.root;
            while (temp.Data != a.Data)
            {
                temp = temp.Next;
                if (temp == null) { Console.WriteLine($"Could not find {a.Data}"); }
            }
            return temp;
        }

        public int Count()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Empty list or no root");
                return -1;
            }
            Node? temp = root;
            int counter = 0;
            while (temp != null)
            {
                temp = temp.Next;
                counter++;
            }

            return counter;
        }

        public bool IsLast(Node a)
        {
            if (a.Next == null) { return true; }
            else return false;
        }

        public bool IsEmpty()
        {
            if (this.root == null) { return true; }
            else { return false; }
        }

        public void InsertFirst(object toBeInserted)
        {
            Node insertThisNode = new Node(toBeInserted);

            if (this.root == null) { this.root = insertThisNode; }
            else
            {
                Node? root = this.root;
                insertThisNode.Next = root;
                this.root = insertThisNode;
            }
        }

        public void InsertLast(object newLastValue)
        {
            Node last = new Node(newLastValue);

            if (this.IsEmpty()) { this.root = last; return; }

            Node? temp = this.root;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = last;
        }

        public void InsertAfter(Node toBeInserted, Node insertAfterThis)
        {

            //Node insertThisNode = new(toBeInsertedValue);
            if (this.IsEmpty())
            {
                throw new InvalidOperationException($"The list is null");
            }
            else
            {
                toBeInserted.Next = insertAfterThis.Next;
                insertAfterThis.Next = toBeInserted;
            }
        }

        public void Useless()
        {
            Console.WriteLine("This does nothing. " +
                "Delete or modify, then save, to enable git pushes.");
        }
    }
}
