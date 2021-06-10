using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIDialog : MonoBehaviour
{
	bool isOpened = false;

    Animator m_Animator = null;
	private Text titleText;
	private Text contentText;
	private Text button1Text;
	private Text button2Text;
	private Button closeBtn;
	private Button button1;
	private Button button2;

	private UnityAction closeAction;
	private UnityAction button1Action;

    private void Awake()
    {
		Debuger.Log("加载完毕");
		m_Animator = GetComponent<Animator>();
		titleText = transform.Find("Window/Header/Text").GetComponent<Text>();
		contentText = transform.Find("Window/Body/Text").GetComponent<Text>();
		button1Text = transform.Find("Window/Button1/Text").GetComponent<Text>();
		button2Text = transform.Find("Window/Button2/Text").GetComponent<Text>();
		closeBtn = transform.Find("Window/Close").GetComponent<Button>();
		button1 = transform.Find("Window/Button1").GetComponent<Button>();
		button2 = transform.Find("Window/Button2").GetComponent<Button>();
		isOpened = false;
	}

    public void Open(string title,string content,string button1Txt = "确定",string button2Txt = "取消", UnityAction closeAction =null,UnityAction btn1Action = null) 
	{
		if (isOpened) return;
		isOpened = true;
		titleText.text = title;
		contentText.text = content;
		button1Text.text = button1Txt;
		button2Text.text = button2Txt;
		this.closeAction = closeAction;
		this.button1Action = btn1Action;

		closeBtn.onClick.AddListener(Close);
		button1.onClick.AddListener(Btn1Click);
		button2.onClick.AddListener(Btn2Click);
		this.transform.SetAsLastSibling();
		gameObject.SetActive(true);
	}

	private void Close()
	{
		m_Animator.SetTrigger("Close");
		Closed();
	}

	private void Closed()
	{
		isOpened = false;
		gameObject.SetActive(false);
        if (closeAction!=null)
        {
			closeAction();
        }
		closeBtn.onClick.RemoveAllListeners();
		button1.onClick.RemoveAllListeners();
		button2.onClick.RemoveAllListeners();
	}

	private void Btn1Click()
    {
		if (button1Action != null)
		{
			button1Action();
		}
	}
	private void Btn2Click()
	{
		Close();
	}
}
