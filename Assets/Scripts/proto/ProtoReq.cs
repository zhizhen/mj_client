using UnityEngine;
using System.Collections;
using NetWork;

public class ProtoReq{
    NetClient network;
    public static void Login()
    {
        Login.LoginReq login = new Login.LoginReq();
        login.account = "";
        login.token = "";
        NetClient.Instance().WriteMsg("Login.LoginReq", login);
    }

    public static void Match()
    {
        Table.MatchReq match = new Table.MatchReq();
        NetClient.Instance().WriteMsg("Table.MatchReq", match);
    }
}
