using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigDatabase : MonoBehaviour
{
    private Config config;
    public Config Config => (config);
    public ConfigDatabase(Config co)
    {
        this.config = co;
    }
}
