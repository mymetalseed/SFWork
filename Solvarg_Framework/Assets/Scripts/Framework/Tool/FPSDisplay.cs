using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    public bool showTop=true;

    [Range(0, 1)]
    public float textScale = 0.1f;

    public TextAnchor textAnchor = TextAnchor.UpperLeft;

    public Color textColor = new Color(0, 0, 1, 0.5f);
    public Color backgroundColor = new Color(0, 0, 0, 0.5f);

    private float _deltaTime = 0.0f;

    private void Update()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
    }

    private GUIStyle style;

    private void OnEnable()
    {
        style = new GUIStyle();
    }

    private void OnGUI()
    {
        int w = Screen.width/2, h = Screen.height;
        int charH = (int)(Mathf.Min(w, h) * textScale);

        style.fontSize = charH;
        style.normal.textColor = textColor;
        style.alignment = textAnchor;

        Rect rect = new Rect(0, showTop ? 0 : (h - charH), w, charH);

        float msec = _deltaTime * 1000.0f;
        float fps = 1.0f / _deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, Mathf.Round(fps));

        GUI.DrawTexture(rect, Texture2D.whiteTexture, ScaleMode.StretchToFill, true, 0, backgroundColor, 0, 0);
        GUI.Label(rect, text, style);
    }

}
