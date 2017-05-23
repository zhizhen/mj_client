using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using cn.sharesdk.unity3d;
public class SDKMgr : SingletonMonoBehaviour<SDKMgr> {
	private ShareSDK ssdk;

	public OnUserInfo updateUserInfo;
	public delegate void OnUserInfo(string openId, string unionId, string nickName, string imageUrl);
	// Uprivate ShareSDK ssdk;se this for initialization
	void Start () {
		ssdk = gameObject.GetComponent<ShareSDK> ();
		ssdk.authHandler = AuthResultHandler;
		ssdk.showUserHandler = GetUserInfoResultHandler;
		ssdk.shareHandler = ShareResultHandler;  
	}

	//public void GetUserInfo(OnUserInfo userInfoCb)
	public void GetUserInfo()
	{
		/*GameObject driverGo = GameObject.Find ("Driver");
		if (driverGo != null) 
		{
			SDKMgr sdkMgr = driverGo.GetComponent<SDKMgr>();
			sdkMgr.updateUserInfo = userInfoCb;//改为eventdispatch也可以，这里测试
			sdkMgr.DoGetUserInfo();
		}*/
		//this.updateUserInfo = userInfoCb;
		DoGetUserInfo();
	}

	void AddLog(string msg)
	{
		Debug.Log(msg);
	}

	void AuthResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result)
	{
		if (state == ResponseState.Success) {
			AddLog ("authoirize success");
		} else if (state == ResponseState.Fail) {
			AddLog ("authoirize falied " + result ["error_code"] + ";error_msg" + result ["error_msg"]);
		} else if (state == ResponseState.Cancel) {
			AddLog ("authoirize cancel");
		}
	}

	void GetUserInfoResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result)
	{
		if (state == ResponseState.Success) {
			AddLog ("getuserinfo success");
			AddLog (MiniJSON.jsonEncode (result));
			string name = (string)result ["nickname"];
			string openid = (string)result ["openid"];
			string unionid = (string)result ["unionid"];
			string headimgurl = (string)result ["headimgurl"];
			AddLog ("name = " + name);
			AddLog ("openid = " + openid);
			AddLog ("uionid = " + unionid);
			AddLog ("headimgurl = " + headimgurl);
			if (updateUserInfo != null) {
				updateUserInfo (openid, unionid, name, headimgurl);
			}
		} else if (state == ResponseState.Fail) {
			AddLog ("getuserinfo falied " + result ["error_code"] + ";error_msg" + result ["error_msg"]);
		} else if (state == ResponseState.Cancel) {
			AddLog ("getuserinfo cancel");
		}		
	}

	void ShareResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result)
	{
		if (state == ResponseState.Success) {
			AddLog ("share success");
		} else if (state == ResponseState.Fail) {
			AddLog ("share falied " + result ["error_code"] + ";error_msg" + result ["error_msg"]);
		} else if (state == ResponseState.Cancel) {
			AddLog ("share cancel");
		}		
	}

	public void DoGetUserInfo()
	{
		ssdk.GetUserInfo(PlatformType.WeChat);
	}

	public void DoShareTest()
	{
		ShareContent content = new ShareContent ();
		content.SetText("分享测试Text");
		content.SetImageUrl ("http://imga3.5054399.com/upload_pic/2017/3/23/4399_11332611981.jpg");
        content.SetTitle("分享测试");
        content.SetUrl("http://www.4399.com");
        content.SetShareType (ContentType.Webpage);

		ssdk.ShareContent (PlatformType.WeChatMoments, content);

      
	}

	public void DoShareTestFriend(string tableId)
	{
        ShareContent content = new ShareContent();
        content.SetText("邀请胶己人麻将");
        content.SetImageUrl("http://imga3.5054399.com/upload_pic/2017/3/23/4399_11332611981.jpg");
        content.SetTitle("桌子号："+tableId);
        content.SetUrl("http://www.4399.com");
        content.SetShareType(ContentType.Webpage);
        ssdk.ShareContent (PlatformType.WeChat, content);
    }

	public Sprite myWXPic;
	public void InitImagePath()
	{
		if (!Directory.Exists (imagePath)) 
		{
			Directory.CreateDirectory (imagePath);
		}
		myWXPic = null;
	}
	public string imagePath
	{
		get{
			//return Application.persistentDataPath + "/ImageCache/";
			return Application.persistentDataPath + "/";
		}
	}
	public string _outputLog;
	void OnGUI()
	{
		//_outputLog = GUI.TextField (new Rect (Screen.width/2, 450, 790, 100), _outputLog);
	}
	public void NewAddLog(string log)
	{
		_outputLog = _outputLog + log + "\n";
	}

	public void SetAsyncImage(string url, Image image)
	{
		if (myWXPic != null)
		{
			image.sprite = myWXPic;
			return;
		}
		Debug.Log ("hashcode = " + MyGetHashCode(url).ToString ());
		if (!File.Exists (imagePath + MyGetHashCode(url))) 
		{
			StartCoroutine (DownLoadImage (url, image));
		} 
		else 
		{
			StartCoroutine (LoadLocalImage (url, image));
		}
	}

	IEnumerator DownLoadImage(string url, Image image)
	{
		Debug.Log ("Download image" + MyGetHashCode(url).ToString());
		NewAddLog("download image");
		WWW www = new WWW (url);
		yield return www;

		Texture2D tex2d = www.texture;
		Sprite m_sprite = Sprite.Create (tex2d, new Rect (0, 0, tex2d.width, tex2d.height), new Vector2 (0, 0));
		image.sprite = m_sprite;
		myWXPic = m_sprite;
		byte[] pngData = tex2d.EncodeToPNG();
		File.WriteAllBytes(imagePath + MyGetHashCode (url), pngData);


	}

	IEnumerator LoadLocalImage(string url, Image image)
	{
		NewAddLog ("local image");
		Debug.Log ("Load local image");
		string filePath = "file:///" + imagePath +  MyGetHashCode (url);
		WWW www = new WWW (filePath);
		yield return www;

		Texture2D texture = www.texture;
		Sprite m_sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),new Vector2(0, 0));
		image.sprite = m_sprite;
		myWXPic = m_sprite;
	}

	public int MyGetHashCode(string url)
	{
		
		int value = url.GetHashCode ();
		if (value < 0)
			value = -value;
		return value;
	}

}
