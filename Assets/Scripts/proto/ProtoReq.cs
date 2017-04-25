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

    public static void Cards()
    {
        Table.Cards card = new Table.Cards();
        NetClient.Instance().WriteMsg("Table.Cards", card);
    }
    public static void Turn()
    {
        Table.Turn turn = new Table.Turn();
        NetClient.Instance().WriteMsg("Table.Turn", turn);
    }
    public static void Play()
    {
        Table.Play play = new Table.Play();
        NetClient.Instance().WriteMsg("Table.Play", play);
    }
    public static void Gang()
    {
        Table.Gang gang = new Table.Gang();
        NetClient.Instance().WriteMsg("Table.Gang", gang);
    }
    public static void Pass()
    {
        Table.Pass pass = new Table.Pass();
        NetClient.Instance().WriteMsg("Table.Pass", pass);    
    }

    public static void NetCard()
    {
        Table.NewCard card = new NewCard();
        NetClient.Instance().WriteMsg("Table.NewCard", card);
    }
}
