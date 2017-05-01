using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class PluginTool:SingletonMonoBehaviour<PluginTool> {

    private AndroidJavaObject activity;
    public Action<string> testBack;
    void Start()
    {
        Init();
    }
    public bool Init()
    {
#if UNITY_ANDROID
        if (activity == null)
        {
            try
            {
                var jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
                if (activity != null)
                {

                }
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("初始化android插件失败"+e);
            }
            
        }
        return false;
#endif
        return false;

    }

    public void testFun()
    {
        CallAndroid("androidFun");
    }

    private void CallAndroid(string methodName, params object[] args)
    {
#if UNITY_ANDROID
        if (activity != null)
        {
            activity.Call(methodName, args);
        }
#endif
    }

    private T CallAndroid<T>(string methodName, params object[] args)
    {
#if UNITY_ANDROID
        if (activity != null)
        {
            activity.Call(methodName, args);
        }
#endif
        return default(T);
    }

    public void BeCalledBack(string param)
    {
        if (testBack != null)
        {
            testBack(param);
        }
    }


    #region test
    public string _outputLog = "";
    private uint count = 0;
    //void OnGUI()
    //{
    //    _outputLog = GUI.TextField(new Rect(Screen.width / 2 - 50, 50, 300, 400), _outputLog);
    //    if (GUI.Button(new Rect(40, 50, 100, 100), "TestLog"))
    //    {
    //        Debug.Log("Cccccccc");
    //        count++;
    //        //AddLog ("count = " + count.ToString ());
    //        SendMsgTest("count = " + count.ToString());
    //    }

    //    if (GUI.Button(new Rect(40, 170, 100, 100), "Start"))
    //    {
    //        StartRecord(URL.localCachePath);
    //    }

    //    if (GUI.Button(new Rect(40, 290, 100, 100), "Stop"))
    //    {
    //       StopRecord();
    //    }

    //    if (GUI.Button(new Rect(40, 410, 100, 100), "Replay"))
    //    {
    //        PlaySound(URL.localCachePath + count + ".amr");
    //    }


    //}

    public void SendMsgTest(string msg)
    {
        //("OCsendMsg", new string[] { msg });
    }
    public void StartRecord(string path)
    {

        CallAndroid("startRecord", path);
    }
    public void StopRecord()
    {
        CallAndroid("stopRecord","");
    }
    public void PlaySound(string path)
    {
        CallAndroid("playSound", path);
    }

    public void AND_RecordEnd(string param)
    {
        byte[] bytes = File.ReadAllBytes(param);
        count++;
        AddLog("IOS_RecordEnd = " + count.ToString() + " len = " + bytes.Length);

        Debug.Log("armPath = " + param + " len = " + bytes.Length);
        WriteVoiceToFile(bytes, count);
    }

    public void AND_PlaySound(string param)
    {
        //retcode=0代表成功，其他错误吗
        AddLog("IOS_PlaySound = " + param.ToString());
        //回复音量
    }

    public void WriteVoiceToFile(byte[] bytes, uint voiceId)
    {
        FileTools.WriteBytesToFile(bytes, URL.localCachePath  + voiceId + ".amr");

    }
    public void AddLog(string log)
    {
        Debug.Log(log);
        _outputLog = _outputLog + log + "\n";
    }

    #endregion
}
