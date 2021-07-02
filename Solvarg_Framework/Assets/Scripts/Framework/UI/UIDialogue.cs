using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dialogue;

/// <summary>
/// 对话面板
/// </summary>
public class UIDialogue : BaseUI
{
    private Image roleAvatar;
    private Image dlBackGround;
    private Text chatText;
    private GameObject chatNextBtn;

    #region Button Group
    private Button Btn1;
    private Button Btn2;
    private Button Btn3;
    private Button Btn4;

    private Text btnText1;
    private Text btnText2;
    private Text btnText3;
    private Text btnText4;
    #endregion

    private DialogueGraph currentDialogue;
    private bool canNext = true;
    public bool CanNext => (canNext);

    public override Defines.EnumUIName GetUIType()
    {
        return Defines.EnumUIName.Dialogue;
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        roleAvatar = transform.Find("Header/RoleAvatar").GetComponent<Image>();
        dlBackGround = transform.Find("Background").GetComponent<Image>();
        chatText = transform.Find("Background/Text").GetComponent<Text>();
        chatNextBtn = transform.Find("Background/NextBtn").gameObject;

        Btn1 = transform.Find("SwitchGroup/Btn1").GetComponent<Button>();
        Btn2 = transform.Find("SwitchGroup/Btn2").GetComponent<Button>();
        Btn3 = transform.Find("SwitchGroup/Btn3").GetComponent<Button>();
        Btn4 = transform.Find("SwitchGroup/Btn4").GetComponent<Button>();

        btnText1 = transform.Find("SwitchGroup/Btn1/Text").GetComponent<Text>();
        btnText2 = transform.Find("SwitchGroup/Btn2/Text").GetComponent<Text>();
        btnText3 = transform.Find("SwitchGroup/Btn3/Text").GetComponent<Text>();
        btnText4 = transform.Find("SwitchGroup/Btn4/Text").GetComponent<Text>();

        canNext = true;
    }

    /// <summary>
    /// 初次开启对话
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="duration"></param>
    public void StartDialogue(DialogueGraph graph, float duration = 2.0f)
    {
        graph.Restart();
        currentDialogue = graph;
        StartDialogue();
    }
    /// <summary>
    /// 后续开启对话,或者继续当前对话
    /// </summary>
    /// <param name="duration"></param>
    public void StartDialogue(float duration=2.0f)
    {
        canNext = false;

        InitDialog();

        Chat currentChat = currentDialogue.current;
        Dialogue.CharacterInfo character = currentChat.character;
        //更改roleAvatar
        roleAvatar.sprite = character.roleAvatar;

        int textCount = currentChat.text.Length;
        int curCount;
        string curText;
        float progressPerText = 1.0f / textCount;

        //这里加入字体缓动
        SingletonManager.Instance.Timer_Register(duration,
            () =>
            {
                //最后把下一句话显示出来
                chatNextBtn.SetActive(true);
                //TODO: 加入选项


                canNext = true;
            },
            (progress, deltatime)=>{
                curCount = (int)(progress / progressPerText);
                curText = currentChat.text.Substring(0, curCount);
                if (chatText.text != curText)
                {
                    chatText.text = curText;
                }
            }
        );
    }

    private void InitDialog()
    {
        Btn1.gameObject.SetActive(false);
        Btn2.gameObject.SetActive(false);
        Btn3.gameObject.SetActive(false);
        Btn4.gameObject.SetActive(false);
        chatText.text = "";
        chatNextBtn.SetActive(false);
    }


    /// <summary>
    /// 进入对话分支
    /// </summary>
    /// <param name="duration"></param>
    public void AnswerQuestion(int index=-1,float duration=2.0f)
    {
        if (canNext)
        {
            currentDialogue.AnswerQuestion(-1);
            StartDialogue(duration);
        }
    }

    public void StopChat()
    {
        canNext = false;
    }

    public void ResumeChat()
    {
        canNext = true;
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
        if (canNext && Input.GetKeyDown(KeyCode.O))
        {
            AnswerQuestion();
        }
    }

}
