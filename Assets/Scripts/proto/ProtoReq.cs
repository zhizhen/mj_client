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
