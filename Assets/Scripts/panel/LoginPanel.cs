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
    }

    private void login()
    {
        ProtoReq.Login();

    }

    private void connect()
    {
        Debug.Log("Start Loading...");
        NetClient network = NetClient.Instance();
        network.Connect("192.168.0.105",8888);
        NetClient.Register();
    }
}
