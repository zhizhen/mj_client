using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class PluginIOSTool:SingletonMonoBehaviour<PluginIOSTool>
{
    public bool Init()
    {
		CallIOS("OCinitsySDK", new string[] {"Driver", "1"});
        return true; 
    }

    public void CallIOS(string funName, string[] args = null)
    {
#if UNITY_IPHONE
		OC_CallIOS(funName, args);
#endif
    }

	public void PlaySound(string path)
	{
		CallIOS ("OCplaySound", new string[] {path});
	}

	public void StartRecord(string path)
	{

		CallIOS("OCstartRecord", new string[] {path});
	}

	public void StopRecord()
	{
		CallIOS("OCstopRecord");
	}

	public void SendMsgTest(string msg)
	{
		CallIOS("OCsendMsg", new string[] { msg });
	}

    public void Log(string msg)
    {
        CallIOS("OCDebugLog", new string[] { msg });
    }

    [DllImport("__Internal")]
   	private static extern void OC_CallIOS(string funName, string[] args);


    public void IOS_RecordEnd(string armPath)
    {
        //byte[] bytes = File.ReadAllBytes(armPath);
        //count++;
        //AddLog("IOS_RecordEnd = " + count.ToString() + " len = " + bytes.Length);

        //Debug.Log("armPath = " + armPath + " len = " + bytes.Length);
        //WriteVoiceToFile(bytes, count);
    }

    public void IOS_PlaySound(string retcode)
    {
        //retcode=0代表成功，其他错误吗
       // AddLog("IOS_PlaySound = " + retcode.ToString());
        //回复音量
    }

    public void WriteVoiceToFile(byte[] bytes, uint voiceId)
    {
        FileTools.WriteBytesToFile(bytes, URL.localCachePath + "UnityVoice/" + voiceId + ".amr");
    }


    public void recvVoice(byte[] bytes)
    {
        //降低音量
        WriteVoiceToFile(bytes, 1);
        //PluginIOSTool.Instance.PlaySound(URL.localCachePath + "UnityVoice/" + count + ".amr");
    }
    public bool VoiceFileExists(uint voiceId)
    {
        return File.Exists(URL.localCachePath + "UnityVoice/" + voiceId + ".amr");
    }

}
