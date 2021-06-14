using System.Collections.Generic;

public class Message
{
    private Dictionary<string, object> dicDatas = null;
    public string Name { get; private set; }
    public object Sender { get; private set; }
    public object Content { get; set; }
    #region message[key]=value or data=message[key]
    public object this[string key]
    {
        get
        {
            if (dicDatas == null || !dicDatas.ContainsKey(key))
                return null;
            return dicDatas[key];
        }
        set
        {
            if (dicDatas == null)
                dicDatas = new Dictionary<string, object>();
            if (!dicDatas.ContainsKey(key))
                dicDatas.Add(key, value);
            else
                dicDatas[key] = value;
        }
    }
    #endregion

    #region Message Construction Function
    public Message(string name, object sender)
    {
        this.Name = name;
        this.Sender = sender;
        this.Content = null;
    }
    public Message(string name, object sender, object content)
    {
        this.Name = name;
        this.Sender = sender;
        this.Content = content;
    }
    public Message(string name, object sender, object content, params object[] _dicParams)
    {
        this.Name = name;
        this.Content = content;
        this.Sender = sender;
        if (_dicParams.GetType() == typeof(Dictionary<string, object>))
        {
            foreach (var _dicParam in _dicParams)
            {
                foreach (KeyValuePair<string, object> kvp in _dicParam as Dictionary<string, object>)
                {
                    dicDatas[kvp.Key] = kvp.Value;
                }
            }
        }
    }
    public Message(Message message)
    {
        this.Name = message.Name;
        this.Sender = message.Sender;
        this.Content = message.Content;
        if (message.dicDatas != null)
        {
            foreach (KeyValuePair<string, object> kvp in message.dicDatas)
            {
                this[kvp.Key] = kvp.Value;
            }
        }
    }
    #endregion

    #region Add & Remove

    public void Add(string key, object value)
    {
        this[key] = value;
    }

    public void Remove(string key)
    {
        if (dicDatas != null && dicDatas.ContainsKey(key))
            dicDatas.Remove(key);
    }

    #endregion

    #region Send

    public void Send()
    {
        MessageDispatcher.Instance.DispatchMessageAsync(this);
    }

    #endregion
}
