using UnityEngine;
using System.Collections;
using System;

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
}
