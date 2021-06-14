using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public static class ApplicationTools
{
    /// <summary>
    /// 离开APP
    /// </summary>
    public static void QuitApp()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
