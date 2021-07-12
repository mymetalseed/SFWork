using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    #region 参数
    AudioSource bgmAS;
    Dictionary<string, AudioSource> soundList = new Dictionary<string, AudioSource>();
    #endregion

    #region 函数
    /// <summary>
    /// 更改背景音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeBGMValue(float value)
    {
        if (bgmAS == null)
            return;
        bgmAS.volume = value;
    }

    /// <summary>
    /// 改变音效音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSoundValue(float value)
    {
        if (soundList.Count == 0)
            return;
        Dictionary<string, AudioSource>.Enumerator enumerator = soundList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            soundList[enumerator.Current.Key].volume = value;
        }
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public async void PlayBGM(string path)
    {
        if (bgmAS == null)
        {
            GameObject BGM = new GameObject("Solvarg_BGM");
            GameObject.DontDestroyOnLoad(BGM);
            bgmAS = BGM.AddComponent<AudioSource>();
            bgmAS.loop = true;
        }
        if (bgmAS.isPlaying)
            bgmAS.Stop();
        // TODO: 待修改
        bgmAS.clip = await singletonManager.LoadAsset<AudioClip>(path);
        bgmAS.Play();
    }

    /// <summary>
    /// 停止背景音乐
    /// </summary>
    public void StopBGM()
    {
        if (bgmAS != null && bgmAS.isPlaying)
            bgmAS.Stop();
    }

    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    public void PauseBGM()
    {
        if (bgmAS != null && bgmAS.isPlaying)
            bgmAS.Pause();
    }

    /// <summary>
    /// 播放音效音乐
    /// </summary>
    /// <param name="name"></param>
    /// <param name="isLoop"></param>
    public async void PlaySound(string path,string name, bool isLoop = false)
    {
        if (!soundList.ContainsKey(name))
        {
            if (GameObject.Find("Solvarg_Sound") == null)
            {
                GameObject go = new GameObject("Solvarg_Sound");
                GameObject.DontDestroyOnLoad(go);
            }
            AudioSource tmp = GameObject.Find("Solvarg_Sound").AddComponent<AudioSource>();
            // TODO：待修改
            tmp.clip = await singletonManager.LoadAsset<AudioClip>(path);
            tmp.name = name;
            soundList.Add(name, tmp);
        }
        soundList[name].loop = isLoop;
        soundList[name].Play();
    }

    /// <summary>
    /// 停止音效音乐
    /// </summary>
    /// <param name="name"></param>
    public void StopSound(string name)
    {
        if (!soundList.ContainsKey(name))
            return;
        if (soundList[name].isPlaying)
            soundList[name].Stop();
    }

    /// <summary>
    /// 停止所有音效
    /// </summary>
    public void StopAllSound()
    {
        Dictionary<string, AudioSource>.Enumerator enumerator = soundList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            soundList[enumerator.Current.Key].Stop();
        }
    }

    #endregion


    #region Unity Callback
    public override void Awake()
    {
        base.Awake();
    }

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
