using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    #region config
    private ConfigDatabase config;
    public ConfigDatabase Config => (config);

    public void SetConfig(ConfigDatabase co)
    {
        config = co;
    }
    #endregion
}
