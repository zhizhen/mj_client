using UnityEngine;
using System.Collections;
using NetWork;
using Table;

public class ProtoReq{
    NetClient network;
    public static void Login()
    {
        Login.LoginReq login = new Login.LoginReq();
        login.account = "";
        login.token = "";
        NetClient.Instance().WriteMsg("Login.LoginReq", login);
    }

    public static void CreateTable()
    {
        Table.CreateReq table = new CreateReq();
        NetClient.Instance().WriteMsg("Table.CreateReq", table);
    }

    public static void JoinTable(int id)
    {
        Table.JoinReq table = new JoinReq();
        NetClient.Instance().WriteMsg("Table.JoinTable", table);
    }
    public static void Ready()
    {
        Table.ReadyReq ready = new Table.ReadyReq();
        NetClient.Instance().WriteMsg("Table.ReadyReq", ready);
    }

}
