using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Message message = new Message(MessageRouter.TestHandler, this);
            message.Add("Hello", "Hello Message");
            message.Send();
        }
    }

}
