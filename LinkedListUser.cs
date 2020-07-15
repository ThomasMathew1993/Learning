using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedListUser
    {
        private Node head;
        private Node tail;
        private int length;
        public LinkedListUser(int value)
        {
            head = new Node() { Value = value, Next = null };
            tail = head;
            length = 1;
        }
        public LinkedListUser(List<int> values)
        {
            int i = 0;
            foreach (var value in values)
            {
                if (i == 0)
                {
                    head = new Node() { Value = value, Next = null };
                    tail = head;
                    length = 1;
                    i++;
                }
                else
                {
                    Append(value);
                }
            }
        }
        public void Append(int value)
        {
            var node = new Node() { Value = value, Next = null };
            tail.Next = node;
            tail = node;
            length++;
        }

        public void Prepend(int value)
        {
            head = new Node() { Value = value, Next = head };
            length++;
        }

        public void Insert(int index, int value)
        {
            var currentNode = this.head;
            if (index == 0)
            {
                Prepend(value);
            }
            else if (index >= length - 1)
            {
                Append(value);
            }
            else
            {
                ActualInsert(index, value, currentNode);
            }
        }

        private void ActualInsert(int index, int value, Node currentNode)
        {
            for (int i = 0; i <= index; i++)
            {
                if (i == index - 1)
                {
                    var node = new Node() { Value = value, Next = currentNode.Next };
                    currentNode.Next = node;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            length++;
        }

        public void Remove(int index)
        {
            if (index > length - 1)
            {
                Console.Write("Invalid Index");
            }
            var currentNode = this.head;
            Node node = new Node();
            for (int i = 0; i <= index + 1; i++)
            {
                if (i == index - 1)
                {
                    node = currentNode;
                }
                else if (i == index + 1)
                {
                    node.Next = currentNode;
                }
                currentNode = currentNode.Next;
            }
            length--;
        }

        public void Print()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public int GetLength()
        {
            return length;
        }

        public void Reverse()
        {
            
            Node firstnode = this.head;
            Node secondNode = firstnode.Next;
            tail = firstnode;
            while (secondNode != null)
            {
                var nextNode = secondNode.Next;
                secondNode.Next = firstnode;
                firstnode = secondNode;
                secondNode = nextNode;
            }
            this.head = firstnode;
            tail.Next = null;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

    }
}
