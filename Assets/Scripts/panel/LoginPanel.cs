using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NetWork;

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

    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _login = uiSprite.FindChild("Button").GetComponent<Button>();

        _login.onClick.AddListener(delegate
        {
            login();
        });
        connect();

        //test
        //GameObject obj = GameObject.Instantiate(_login.gameObject) as GameObject;
        //obj.transform.position = new Vector3(Screen.width, Screen.height, 0);
        //obj.transform.parent = _login.transform.parent;
    }

    private void login()
    {
        //QuickTips.ShowRedQuickTips("消息");
        HallPanel.Instance.load();
        //ProtoReq.Login();

    }

    private void connect()
    {
        Debug.Log("Start Loading...");
        NetClient network = NetClient.Instance();
        network.Connect("127.0.0.1",8888);
        NetClient.Register();
    }
}
