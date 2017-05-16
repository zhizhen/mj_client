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
    public static void EnterRoom()
    {
        Room.EnterReq room = new Room.EnterReq();
        room.room_id = 1;
        NetClient.Instance().WriteMsg("Room.EnterReq", room);
    }
    public static void CreateTable()
    {
        Table.CreateReq table = new CreateReq();
        table.token = "123";
        NetClient.Instance().WriteMsg("Table.CreateReq", table);
    }

    public static void JoinTable(int id)
    {
        Table.JoinReq table = new JoinReq();
        table.tab_id = id;
        NetClient.Instance().WriteMsg("Table.JoinReq", table);
    }
    public static void Ready()
    {
        Table.ReadyReq ready = new Table.ReadyReq();
        NetClient.Instance().WriteMsg("Table.ReadyReq", ready);
    }
    public static void Turn()
    {
        Table.Turn turn = new Table.Turn();
        NetClient.Instance().WriteMsg("Table.Turn", turn);
    }
    public static void Play(int num)
    {
        Table.Play play = new Table.Play();
        play.card = num;
        NetClient.Instance().WriteMsg("Table.Play", play);
    }
    public static void Gang(int num)
    {
        Table.Gang gang = new Table.Gang();
        gang.card = num;
        NetClient.Instance().WriteMsg("Table.Gang", gang);
    }

    public static void AnGang(int num)
    {
        Table.Angang gang = new Table.Angang();
        gang.card = num;
        NetClient.Instance().WriteMsg("Table.Angang", gang);
    }
    public static void Pass()
    {
        Table.Pass pass = new Table.Pass();
        NetClient.Instance().WriteMsg("Table.Pass", pass);    
    }

    public static void Peng(int num)
    {
        Table.Peng peng = new Table.Peng();
        peng.card = num;
        NetClient.Instance().WriteMsg("Table.Peng", peng);
    }

    public static void NetCard()
    {
        Table.NewCard card = new NewCard();
        NetClient.Instance().WriteMsg("Table.NewCard", card);
    }

    public static void QuiTable()
    {
        Table.Quit quit = new Quit();
        NetClient.Instance().WriteMsg("Table.Quit", quit);
    }
}
