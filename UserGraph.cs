using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class UserGraph
    {
        private int numberOfNodes;
        private Dictionary<int, List<int>> adjacentList = new Dictionary<int, List<int>>();
        private List<int> nodes = new List<int>();
        public UserGraph()
        {
            this.numberOfNodes = 0;
        }
        public void AddVertex(int node)
        {
            this.nodes.Add(node);
            numberOfNodes++;
        }
        public void AddEdges(int node1, int node2)
        {
            if (nodes.Contains(node1) && nodes.Contains(node2))
            {
                if (!adjacentList.ContainsKey(node1))
                    adjacentList.Add(node1, new List<int>() { node2 });
                else
                    adjacentList[node1].Add(node2);
                if (!adjacentList.ContainsKey(node2))
                    adjacentList.Add(node2, new List<int>() { node1 });
                else
                    adjacentList[node2].Add(node1);
            }
            else
            {
                Console.WriteLine("Nodes unavailable");
            }

        }
    }
}
