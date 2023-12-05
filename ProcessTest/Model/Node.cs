using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest.Model
{
    public class Node
    {
        public Node() { }
        public string Name;
        public List<Node> Children { get; set; } = new List<Node>();
        public List<Node> Parents { get; set; } = new List<Node>();
        public double X;
        public double Y;
        public Node AppendNext(Node child) { Children.Add(child); child.Parents.Add(this); return child; }

        public List<Node> AsList()
        {
            var list = new List<Node>() { this };
            var LoL = Children.SelectMany(c => c.AsList());

            foreach(var c in LoL)
            {
                if (list.Contains(c))
                    continue;
                list.Add(c);
            }

            return list;
        }

    }
}
