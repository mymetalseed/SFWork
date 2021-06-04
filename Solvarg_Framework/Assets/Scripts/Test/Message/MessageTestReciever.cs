using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTestReciever : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessageDispatcher.Instance.RegisterMessageHandler(MessageRouter.TestHandler, GetMessage);
    }

    void GetMessage(Message message)
    {
        Debuger.Log(message["Hello"]);
    }
}
