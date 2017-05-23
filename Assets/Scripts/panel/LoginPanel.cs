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
    private Image _head;
    private Text _name;

    private Toggle _toggle;

    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _login = uiSprite.FindChild("Button").GetComponent<Button>();
        _toggle = uiSprite.FindChild("info/Toggle").GetComponent<Toggle>();
        _toggle.isOn = PlayerPrefs.HasKey("check") ? true : false;
        _login.onClick.AddListener(delegate
        {
            login();
        });

        _toggle.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetInt("check", 1);
            //_toggle.isOn = !_toggle.isOn;
        });
        connect();
        _name = uiSprite.FindChild("UserInfo/nameTxt").GetComponent<Text>();
        _head = uiSprite.FindChild("UserInfo/headImg").GetComponent<Image>();
        _name.text = "hahaha";
    }

    private void login()
    {
        //QuickTips.ShowRedQuickTips("消息");
        //HallPanel.Instance.load();
        if (!_toggle.isOn)
        {
            QuickTips.ShowRedQuickTips("请同意用户协议");
            return;
        }

#if !UNITY_EDITOR
        SDKMgr.Instance.updateUserInfo = updateUserInfo;
        SDKMgr.Instance.GetUserInfo();
#else
        ProtoReq.Login("sl", "sl", "htttp://test");
#endif


    }


    private void connect()
    {
        Debug.Log("Start Loading...");
        NetClient network = NetClient.Instance();
        network.Connect("123.207.241.224",8888);
        //network.Connect("192.168.0.119", 8888);
        NetClient.Register();
        //SDKMgr.Instance.DoShareTestFriend();
    }

    private void updateUserInfo(string openId, string unionId, string nickName, string imageUrl)
    {
        Debug.Log("LoginPanel:openId" + openId);
        Debug.Log("LoginPanel:openId" + openId);
        Debug.Log("LoginPanel:openId" + openId);
        Debug.Log("LoginPanel:openId" + openId);
        _name.text = nickName;
        MainRole.Instance.Name = nickName;
        SDKMgr.Instance.SetAsyncImage(imageUrl, _head);
        ProtoReq.Login(nickName, nickName, imageUrl);
    }
}
