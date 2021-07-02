using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class Event : DialogueBaseNode
    {
        /// <summary>
        /// 等价于UnityEvent
        /// </summary>
        public SerializableEvent[] trigger;
        public override void Trigger()
        {
            for(int i = 0; i < trigger.Length; ++i)
            {
                trigger[i].Invoke();
            }
        }
    }
}