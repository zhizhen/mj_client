using UnityEngine;
using System.Collections;
using NetWork;

public class LoginController : Singleton<LoginController> {


    public void LoginBack(Login.LoginRsp login)
    {
        MainRole.Instance.Id = login.id;
        //MainRole.Instance.Name = login.name
        Debug.Log("id" + login.id);
        QuickTips.ShowGreenQuickTips("登录成功");
        ProtoReq.EnterRoom();
        //HallPanel.Instance.load();
    }
}
