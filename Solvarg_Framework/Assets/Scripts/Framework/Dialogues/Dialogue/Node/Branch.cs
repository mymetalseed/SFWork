using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{

    public class Branch : DialogueBaseNode
    {
        public Condition[] conditions;
        [Output]
        public DialogueBaseNode pass;
        [Output]
        public DialogueBaseNode fail;

        private bool success;

        public override void Trigger()
        {
            //Perform Condition
            bool success = true;
            for(int i = 0; i < conditions.Length; ++i)
            {
                if (!conditions[i].Invoke())
                {
                    success = false;
                    break;
                }
            }

            //Trigger next node
            NodePort port;
            if (success) port = GetOutputPort("pass");
            else port = GetOutputPort("fail");

            if (port == null) return;
            for(int i = 0; i < port.ConnectionCount; ++i)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }

        }
    }

    [Serializable]
    public class Condition : SerializableCallback<bool> { }
}