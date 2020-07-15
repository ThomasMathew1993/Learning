using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class StackUser
    {
        private Node top;
        private Node bottom;
        private int length;
        public StackUser()
        {
            this.top = null;
            this.bottom = null;
            this.length = 0;
        }

        public void Push(int value)
        {
            Node node = new Node() { Value = value, Next = null };
            if (this.length == 0)
            {
                this.bottom = node;
                this.top = node;
            }
            else
            {
                var topNode = this.top;
                this.top = node;
                this.top.Next = topNode;
            }
            length++;
        }
        public void Pop()
        {
            if(this.top == this.bottom)
            {
                this.bottom = null;
            }
            this.top = top.Next;
            length--;
        }
        public int Peek()
        {
            return this.top.Value;
        }
    }
}
