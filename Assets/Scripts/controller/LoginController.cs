﻿using UnityEngine;
using System.Collections;
using NetWork;

public class LoginController : Singleton<LoginController> {


    public void LoginBack(Login.LoginRsp login)
    {
        QuickTips.ShowGreenQuickTips("登录成功");
       // Debug.Log("登录成功");
        HallPanel.Instance.load();
        //LoginPanel.Instance.DestoryPanel();
    }
}
