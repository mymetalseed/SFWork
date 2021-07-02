using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 根据dialogId更新当前的对话,然后开始对话
    /// </summary>
    /// <param name="dialogId"></param>
    public async Task Dialogue_StartDialogById(string dialogId)
    {
        await dialoguesManager.StartDialogById(dialogId);
    }

    /// <summary>
    /// 获得当前的DialoguePanel
    /// </summary>
    /// <returns></returns>
    public UIDialogue GetDialoguePanel()
    {
        return dialoguesManager.GetDialoguePanel;
    }
}
