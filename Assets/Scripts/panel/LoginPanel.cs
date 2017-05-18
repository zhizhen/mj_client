using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NetWork;
using cn.sharesdk.unity3d;

public class LoginPanel : BasePanel {

    private static LoginPanel instance;
    public static LoginPanel Instance
    {
        get
        {
            if (instance == null)
                instance = new LoginPanel();
            return instance;
        }

    }
    private LoginPanel()
    {
        base_name = PanelTag.LOGIN_PANEL;
    }

    private Button _login;

    private Button _login1;
    private Image _head;
    private Text _name;

    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _login = uiSprite.FindChild("Button").GetComponent<Button>();

        _login.onClick.AddListener(delegate
        {
            login();
        });
        connect();


        _login1 = uiSprite.FindChild("Button1").GetComponent<Button>();
        _name = uiSprite.FindChild("UserInfo/nameTxt").GetComponent<Text>();
        _head = uiSprite.FindChild("UserInfo/headImg").GetComponent<Image>();
        _name.text = "hahaha";
        _login1.onClick.AddListener(delegate
        {
            login1();
        });
    }

    private void login()
    {
        SoundMgr._instance.playBigBgm("beijing-fangjian");
        //QuickTips.ShowRedQuickTips("消息");
        //HallPanel.Instance.load();
        ProtoReq.Login("sl","sl","htttp://test");
    }

    private void login1()
    {
        SDKMgr.Instance.updateUserInfo = updateUserInfo;
        SDKMgr.Instance.GetUserInfo();
    }

    private void connect()
    {
        Debug.Log("Start Loading...");
        NetClient network = NetClient.Instance();
        network.Connect("123.207.241.224",8888);
        //network.Connect("192.168.0.119", 8888);
        NetClient.Register();
    }

    private void updateUserInfo(string openId, string unionId, string nickName, string imageUrl)
    {
        Debug.Log("LoginPanel:openId" + openId);
        Debug.Log("LoginPanel:openId" + openId);
        Debug.Log("LoginPanel:openId" + openId);
        Debug.Log("LoginPanel:openId" + openId);
        _name.text = nickName;
        SDKMgr.Instance.SetAsyncImage(imageUrl, _head);
    }
}
