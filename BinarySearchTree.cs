using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class BinarySearchTree
    {
        private BinaryNode rootNode;
        public BinarySearchTree()
        {
            this.rootNode = null;
        }
        public void Insert(int value)
        {
            var newNode = new BinaryNode() { Value = value, RightNode = null, LeftNode = null };
            if (this.rootNode == null)
                this.rootNode = newNode;
            else
            {
                var currentNode = this.rootNode;
                while (true)
                {
                    if (value < currentNode.Value)
                    {
                        if (currentNode.LeftNode == null)
                        {
                            currentNode.LeftNode = newNode;
                            break;
                        }
                        currentNode = currentNode.LeftNode;
                    }
                    else
                    {
                        if (currentNode.RightNode == null)
                        {
                            currentNode.RightNode = newNode;
                            break;
                        }
                        currentNode = currentNode.RightNode;
                    }

                }
            }
        }
        public BinaryNode Lookup(int value)
        {
            var currentNode = this.rootNode;
            if (rootNode == null)
            {
                return null;
            }
            while (currentNode != null)
            {
                if (value < currentNode.Value)
                {
                    currentNode = currentNode.LeftNode;
                }
                else if (value > currentNode.Value)
                {
                    currentNode = currentNode.RightNode;
                }
                else if (currentNode.Value == value)
                {
                    return currentNode;
                }
            }
            return null;
        }

        public void Remove(int value)
        {
            if (this.rootNode == null)
                return;
            var currentNode = this.rootNode;
            BinaryNode parentNode = new BinaryNode();
            while (currentNode != null)
            {
                if (value < currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.LeftNode;
                }
                else if (value > currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.RightNode;
                }
                else if (currentNode.Value == value)
                {
                    if (currentNode.RightNode == null)
                    {
                        if (parentNode == null)
                        {
                            this.rootNode = currentNode.LeftNode;
                        }
                        else
                        {
                            if (currentNode.Value < parentNode.Value)
                                parentNode.LeftNode = currentNode.LeftNode;
                            else if (currentNode.Value > parentNode.Value)
                                parentNode.RightNode = currentNode.LeftNode;
                        }
                    }
                    else if (currentNode.RightNode.LeftNode == null)
                    {
                        if (parentNode == null)
                        {
                            this.rootNode = currentNode.LeftNode;
                        }
                        else
                        {
                            currentNode.RightNode.LeftNode = currentNode.LeftNode;
                            if (currentNode.Value < parentNode.Value)
                            {
                                parentNode.LeftNode = currentNode.RightNode;
                            }
                            else if (currentNode.Value > parentNode.Value)
                            {
                                parentNode.RightNode = currentNode.RightNode;
                            }
                        }
                    }
                    else
                    {
                        var leftmost = currentNode.RightNode.LeftNode;
                        var leftmostParent = currentNode.RightNode;
                        while (leftmost.LeftNode != null)
                        {
                            leftmostParent = leftmost;
                            leftmost = leftmost.LeftNode;
                        }
                        leftmostParent.LeftNode = leftmost.RightNode;
                        leftmost.LeftNode = currentNode.LeftNode;
                        leftmost.RightNode = currentNode.RightNode;

                        if (parentNode == null)
                            this.rootNode = leftmost;
                        else
                        {
                            if (currentNode.Value < parentNode.Value)
                                parentNode.LeftNode = leftmost;
                            else if (currentNode.Value > parentNode.Value)
                                parentNode.RightNode = leftmost;
                        }
                    }
                }
            }
        }
        public void BreadthFirstSearch()
        {
            var currentNode = this.rootNode;
            var final = new List<int>();
            var queue = new Queue<BinaryNode>();
            queue.Enqueue(currentNode);
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                final.Add(currentNode.Value);
                if (currentNode.LeftNode != null)
                {
                    queue.Enqueue(currentNode.LeftNode);
                }
                if (currentNode.RightNode != null)
                {
                    queue.Enqueue(currentNode.RightNode);
                }
            }
            foreach (var f in final)
            {
                Console.WriteLine(f);
            }
        }
        private List<int> inOrderList = new List<int>();
        private List<int> preOrderList = new List<int>();
        private List<int> postOrderList = new List<int>();
        public void DFS()
        {
            DFSInOrder(this.rootNode);
            foreach (var f in inOrderList)
                Console.WriteLine(f);
            DFSPreOrder(this.rootNode);
            foreach (var f in preOrderList)
                Console.WriteLine(f);
            DFSPostOrder(this.rootNode);
            foreach (var f in postOrderList)
                Console.WriteLine(f);
        }

        public void DFSInOrder(BinaryNode node)
        {
            if (node.LeftNode != null)
            {
                DFSInOrder(node.LeftNode);
            }
            inOrderList.Add(node.Value);
            if(node.RightNode != null)
            {
                DFSInOrder(node.RightNode);
            }
            //inOrderList.Co
        }

        public void DFSPreOrder(BinaryNode node)
        {
            preOrderList.Add(node.Value);
            if(node.LeftNode != null)
            {
                DFSPreOrder(node.LeftNode);
            }
            if(node.RightNode != null)
            {
                DFSPreOrder(node.RightNode);
            }
        }
        public void DFSPostOrder(BinaryNode node)
        {
            if (node.LeftNode != null)
            {
                DFSPostOrder(node.LeftNode);
            }
            if (node.RightNode != null)
            {
                DFSPostOrder(node.RightNode);
            }
            postOrderList.Add(node.Value);
        }
    }

    class BinaryNode
    {
        public BinaryNode LeftNode { get; set; }
        public BinaryNode RightNode { get; set; }
        public int Value { get; set; }
    }
}
