using ProcessTest.Model;
using ProcessTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest
{
    public static class NodeTests
    {

        /// <summary>
        /// Method generates sample workflow.
        /// </summary>
        /// <returns></returns>
        public static Workflow GimmeWorkflow()
        {
            Node root = new Node() { Name = "Root node 00", X = 50, Y = 40 };
            Node node1 = new Node() { Name = "node 01", X = 130, Y = 130 };
            Node node2 = new Node() { Name = "node 02", X = 320, Y = 160 };
            Node node3 = new Node() { Name = "node 03", X = 550, Y = 350 };
            root.AppendNext(node1).AppendNext(node3);
            root.AppendNext(node2).AppendNext(node3);

            Workflow workflow = new Workflow();
            workflow.Nodes = root.AsList();
            workflow.Cables = new List<Cable>();

            foreach (var node in workflow.Nodes)
                foreach (var ch in node.Children)
                    workflow.Cables.Add(new Cable() { XFrom = node.X, YFrom = node.Y, XTo = ch.X, YTo = ch.Y });

            return workflow;
        }

        
        
    }
}
