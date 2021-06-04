using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 注册消息句柄
    /// </summary>
    /// <param name="messageName"></param>
    /// <param name="kHandler"></param>
    public void Message_Subscribe(string messageName, MessageHandler kHandler)
    {
        messageDispatcher.RegisterMessageHandler(messageName, kHandler);
    }

    /// <summary>
    /// 反注册消息句柄
    /// </summary>
    /// <param name="messageName"></param>
    /// <param name="kHandler"></param>
    public void Message_UnSubscribe(string messageName, MessageHandler kHandler)
    {
        messageDispatcher.UnRegisterMessageHandler(messageName, kHandler);
    }

    /// <summary>
    /// 异步发送,不是即时发送
    /// </summary>
    /// <param name="message"></param>
    public void Message_FireAsync(Message message)
    {
        messageDispatcher.DispatchMessageAsync(message);
    }

    /// <summary>
    /// 同步发送,调用即发送
    /// </summary>
    /// <param name="message"></param>
    public void Message_Fire(Message message)
    {
        messageDispatcher.DispatchMessage(message);
    }
}
