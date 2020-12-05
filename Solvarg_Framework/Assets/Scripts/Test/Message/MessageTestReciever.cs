using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTestReciever : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessageDispatcher.Instance.RegisterMessageHandler(MessageRouter.TestAction.ROUTE, GetMessage);
    }

    void GetMessage(Message message)
    {
        Debuger.Log(message[MessageRouter.TestAction.Params.TEST1]);
    }
}
