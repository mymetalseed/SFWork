using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [Label("开启FPS面板")]
    public bool enableFPS;
    private void Start()
    {
        //预初始化所有的管理器
        SingletonManager.Instance.InitSingletons();

        if (enableFPS)
        {
            FPSDisplay fps = SingletonManager.Instance.gameObject.AddComponent<FPSDisplay>();
        }

        //开启预加载流程,之后的流程都将在流程模块进行
        SingletonManager.Instance.StartProcedure<LoadConfigProcedure>();
    }
}
