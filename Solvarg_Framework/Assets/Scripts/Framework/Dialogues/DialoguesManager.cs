using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialogue;
using System.Threading.Tasks;

public class DialoguesManager : Singleton<DialoguesManager>
{
    #region 静态注册
    public static string pathPre = "Assets/AssetPackage/Dialogue/DialogueGraph/";

    /// <summary>
    /// Key - ID
    /// Value - 地址
    /// </summary>
    public DoubleMap<string, string> DialogPath;
    public override void Awake()
    {
        base.Awake();
        DialogPath = new DoubleMap<string, string>();
        DialogPath.Add("T01", "Tutorial.asset");
    }
    #endregion

    #region 参数
    private DialogueGraph currentDialog;
    public DialogueGraph CurrentDialog => (currentDialog);

    private UIDialogue uiDialoguePanel;
    public UIDialogue GetDialoguePanel=>(uiDialoguePanel);
    #endregion

    #region 方法
    public async Task StartDialogById(string id)
    {
        if (!DialogPath.ContainsKey(id)) return;
        currentDialog = await singletonManager.LoadAsset<DialogueGraph>(pathPre+DialogPath.GetValueByKey(id));
        await singletonManager.OpenUI(Defines.EnumUIName.Dialogue);
        uiDialoguePanel = singletonManager.GetUIObject(Defines.EnumUIName.Dialogue).GetComponent<UIDialogue>();
        uiDialoguePanel.StartDialogue(currentDialog);
    }

    /// <summary>
    /// 这个函数后面由UIdialogue调用
    /// 用于处理对话过程中的事件分发
    /// </summary>
    /// <param name="param"></param>
    public void Trigger(string param)
    {

    }

    #endregion

    #region Unity Callback
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
