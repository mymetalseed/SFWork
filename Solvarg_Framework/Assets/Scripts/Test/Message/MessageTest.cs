using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Message message = new Message(MessageRouter.TestAction.ROUTE, this);
        message.Add(MessageRouter.TestAction.Params.TEST1, "Hello Message");
        message.Send();
    }
    
}
