using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{
    public class SubGraph : Node
    {
        [Input]
        public bool exec;
        public NodeGraph subGraph;
        [Output]
        public bool output;
    }
}