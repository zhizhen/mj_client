using UnityEngine;
using System.Collections;
using NetWork;

public class LoginController : Singleton<LoginController> {


    public void LoginBack(Login.LoginRsp login)
    {
        MainRole.Instance.Id = login.id;
        QuickTips.ShowGreenQuickTips("登录成功");
        ProtoReq.EnterRoom();
        //HallPanel.Instance.load();
    }
}
