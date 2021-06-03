using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 所有消息回调函数必须遵守的委托定义
/// </summary>
/// <param name="messageName"></param>
/// <param name="kParam"></param>
public delegate void MessageHandler(Message message);

public class MessageDispatcher : Singleton<MessageDispatcher>
{
    Dictionary<string, List<MessageHandler>> m_kMessageTable;
    Queue<Message> _receiveMessageQueue;

    /// <summary>
    /// 对一个消息注册一个新的回调函数，如果这个消息
    /// 已经有该回调函数，则不会注册第二次
    /// </summary>
    /// <param name="messageName"></param>
    /// <param name="kHandler"></param>
    public void RegisterMessageHandler(string messageName, MessageHandler kHandler)
    {
        if (!m_kMessageTable.ContainsKey(messageName))
        {
            m_kMessageTable.Add(messageName, new List<MessageHandler>());
        }
        List<MessageHandler> kHandlerList = m_kMessageTable[messageName];
        if (!kHandlerList.Contains(kHandler))
        {
            kHandlerList.Add(kHandler);
        }
    }

    /// <summary>
    /// 对一个消息取消注册一个回调函数
    /// </summary>
    /// <param name="messageName"></param>
    /// <param name="kHandler"></param>
    public void UnRegisterMessageHandler(string messageName, MessageHandler kHandler)
    {
        if (m_kMessageTable.ContainsKey(messageName))
        {
            List<MessageHandler> kHandlerList = m_kMessageTable[messageName];
            kHandlerList.Remove(kHandler);
        }
    }

    /// <summary>
    /// 分发消息，同步
    /// </summary>
    /// <param name="messageName">消息类型</param>
    /// <param name="kParam">附加参数</param>
    public void DispatchMessage(Message message)
    {
        if (m_kMessageTable.ContainsKey(message.Name))
        {
            List<MessageHandler> kHandlerList = m_kMessageTable[message.Name];
            for (int i = 0; i < kHandlerList.Count; i++)
            {
                ((MessageHandler)kHandlerList[i])(message);
            }
        }
    }

    /// <summary>
    /// 分发消息，异步，会在协程BeginHandleReceiveMessageQueue的下一次检查中进行真正的消息分发
    /// </summary>
    /// <param name="messageName">消息类型</param>
    /// <param name="kParam">附加参数</param>
    public void DispatchMessageAsync(Message message)
    {
        lock (_receiveMessageQueue)
        {
            Message args = new Message(message);
            _receiveMessageQueue.Enqueue(args);
        }
    }

    private IEnumerator BeginHandleReceiveMessageQueue()
    {
        while (true)
        {
            yield return 0;
            lock (_receiveMessageQueue)
            {
                while (_receiveMessageQueue.Count != 0)
                {
                    Message message = _receiveMessageQueue.Dequeue();
                    DispatchMessage(message);
                }
            }
        }
    }

    /// <summary>
    /// 进行单例的初始化
    /// </summary>
    public override void Awake()
    {
        Debuger.Log("初始化Message模块");
        m_kMessageTable = new Dictionary<string, List<MessageHandler>>();
        _receiveMessageQueue = new Queue<Message>();

        singletonManager.StartCoroutine(BeginHandleReceiveMessageQueue());
    }
}