using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PluginIOSCB : MonoBehaviour {
	public string _outputLog;
	private uint count = 0;
	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<Camera> ();
		PluginIOSTool.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	void OnGUI()
	{
		_outputLog = GUI.TextField (new Rect (Screen.width/2-50, 50, 300, 400), _outputLog);
		if (GUI.Button (new Rect (40, 50, 100, 100), "TestLog")) 
		{
			Debug.Log ("Cccccccc");
			count++;
			//AddLog ("count = " + count.ToString ());
			PluginIOSTool.Instance.SendMsgTest("count = " + count.ToString());
		}

		if (GUI.Button (new Rect (40, 170, 100, 100), "Start"))
		{
			PluginIOSTool.Instance.StartRecord(URL.localCachePath);
		}

		if (GUI.Button (new Rect (40, 290, 100, 100), "Stop"))
		{
			PluginIOSTool.Instance.StopRecord();
		}

		if (GUI.Button (new Rect (40, 410, 100, 100), "Replay")) 
		{
			PluginIOSTool.Instance.PlaySound(URL.localCachePath + "UnityVoice/" + count + ".amr");
		}


	}

	void AddLog(string log)
	{
		Debug.Log (log);
		_outputLog = _outputLog + log + "\n";
	}

	public void IOS_RecordEnd(string armPath)
	{
		byte[] bytes = File.ReadAllBytes (armPath);
		count++;
		AddLog ("IOS_RecordEnd = " + count.ToString () + " len = " + bytes.Length);

		Debug.Log ("armPath = " + armPath + " len = " + bytes.Length);
		WriteVoiceToFile(bytes, count);
	}

	public void IOS_PlaySound(string retcode)
	{
		//retcode=0代表成功，其他错误吗
		AddLog("IOS_PlaySound = " + retcode.ToString());
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
		PluginIOSTool.Instance.PlaySound(URL.localCachePath + "UnityVoice/" + count + ".amr");
	}
	public bool VoiceFileExists(uint voiceId)
	{
		return File.Exists(URL.localCachePath + "UnityVoice/" + voiceId + ".amr");
	}
 
}
