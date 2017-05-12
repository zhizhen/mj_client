using UnityEngine;
using System.Collections;
using NetWork;

public class LoginController : Singleton<LoginController> {


    public void LoginBack(Login.LoginRsp login)
    {
        GameConfig.roleId = login.id;
        MainRole.Instance.Id = login.id;
        QuickTips.ShowGreenQuickTips("登录成功");
        ProtoReq.EnterRoom();
        //HallPanel.Instance.load();
    }
}
