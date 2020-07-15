using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class DoublyLinkedListUser
    {
        private DoublyNode head;
        private DoublyNode tail;
        private int length;
        public DoublyLinkedListUser(int value)
        {
            head = new DoublyNode() { Value = value, Next = null, Previous = null };
            tail = head;
            length = 1;
        }
        public DoublyLinkedListUser(List<int> values)
        {
            int i = 0;
            foreach (var value in values)
            {
                if (i == 0)
                {
                    head = new DoublyNode() { Value = value, Next = null, Previous = null };
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
            var node = new DoublyNode() { Value = value, Next = null, Previous = tail };
            tail.Next = node;
            tail = node;
            length++;
        }

        public void Prepend(int value)
        {
            head = new DoublyNode() { Value = value, Next = head, Previous = null };
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

        private void ActualInsert(int index, int value, DoublyNode currentNode)
        {
            for (int i = 0; i <= index; i++)
            {
                if (i == index - 1)
                {
                    var node = new DoublyNode() { Value = value, Next = currentNode.Next, Previous = currentNode };
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
            DoublyNode node = new DoublyNode();
            for (int i = 0; i <= index + 1; i++)
            {
                if (i == index - 1)
                {
                    node = currentNode;
                }
                else if (i == index + 1)
                {
                    node.Next = currentNode;
                    node.Previous = node;
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
    }

    public class DoublyNode
    {
        public int Value { get; set; }
        public DoublyNode Next { get; set; }
        public DoublyNode Previous { get; set; }

    }
}
