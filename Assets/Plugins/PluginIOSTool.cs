using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class PluginIOSTool :SingletonMonoBehaviour<PluginIOSTool>{

    public Action<string> testBack;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    public bool Init()
    {
        CallIOS("methodName");
        return true; 
    }

    public void CallIOS(string funName, string[] args = null)
    {
#if UNITY_IPHONE
        OC_CallIOS(funName, args);
#endif
    }

    public void Log(string msg)
    {
        CallIOS("OCDebugLog", new string[] { msg });
    }

    [DllImport("__Internal")]
    private static extern void OC_CallIOS(string funName, string[] args);

    public void BeCalledBack(string param)
    {
        if (testBack != null)
        {
            testBack(param);
        }
    }
}
