using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [CreateAssetMenu(menuName ="Dialogue/Graph",order = 0)]
    public class DialogueGraph : NodeGraph
    {
        [HideInInspector]
        public Chat current;

        public string DialogId;
        public void Restart()
        {
            current = nodes.Find(x => x is Chat && x.Inputs.All(y => !y.IsConnected)) as Chat;
        }

        public Chat AnswerQuestion(int i)
        {
            current.AnswerQuestion(i);
            return current;
        }
    }
}