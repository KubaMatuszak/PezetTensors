using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest.Model
{
    class Workflow
    {
        public List<Node> Nodes { get; set; }
        public List<Cable> Cables { get; set; }
    }
}
