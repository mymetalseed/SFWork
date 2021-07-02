using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 根据dialogId更新当前的对话,然后开始对话
    /// </summary>
    /// <param name="dialogId"></param>
    public void Dialogue_StartDialogById(string dialogId)
    {
        dialoguesManager.StartDialogById(dialogId);
    }
}
