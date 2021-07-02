using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace Dialogue
{
    [NodeTint("#CCFFCC")]
    public class Chat : DialogueBaseNode
    {
        public CharacterInfo character;

        [TextArea]
        public string text;

        [Output(dynamicPortList = true)]
        public List<Answer> answers = new List<Answer>();

        [System.Serializable]
        public class Answer
        {
            public string text;
            public AudioClip voiceClip;
        }

        public override void Trigger()
        {
            Debuger.LogError(text);
            (graph as DialogueGraph).current = this;
        }
        /// <summary>
        /// 如果index=-1,回答失败,继续等待回答
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool AnswerQuestion(int index)
        {
            NodePort port = null;
            if(answers.Count == 0)
            {
                port = GetOutputPort("output");
                Debuger.LogError("进入这里了喔");
            }
            else
            {
                if (index==-1 || answers.Count <= index) return false;
                port = GetOutputPort("answers " + index);
            }

            if(port == null)
            {
                return false;
            }

            for(int i = 0; i < port.ConnectionCount; ++i)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
            return true;
        }

    }
}