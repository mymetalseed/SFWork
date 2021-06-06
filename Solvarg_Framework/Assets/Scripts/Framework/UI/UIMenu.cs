using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : BaseUI
{
    public override Defines.EnumUIName GetUIType()
    {
        return Defines.EnumUIName.Menu;
    }

    #region params
    private Text startGameTxt;
    private Text continueGameTxt;
    private Text QuitGameTxt;
    private Button startGameBtn;
    private Button continueGameBtn;
    private Button QuitGameBtn;
    #endregion

    #region BaseUI Callback
    protected override void OnAwake()
    {
        base.OnAwake();
        startGameTxt = transform.Find("StartGame/Text").GetComponent<Text>();
        continueGameTxt = transform.Find("Continue/Text").GetComponent<Text>();
        QuitGameTxt = transform.Find("QuitGame/Text").GetComponent<Text>();
        startGameBtn = transform.Find("StartGame").GetComponent<Button>();
        continueGameBtn = transform.Find("Continue").GetComponent<Button>();
        QuitGameBtn = transform.Find("QuitGame").GetComponent<Button>();
    }

    protected override void OnOpen()
    {
        base.OnOpen();
        Debuger.Log("打开菜单UI");
    }
    #endregion
}
