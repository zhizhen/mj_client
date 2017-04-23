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

    public static void Match()
    {
        Table.MatchReq match = new Table.MatchReq();
        NetClient.Instance().WriteMsg("Table.MatchReq", match);
    }

    public static void GetRoomList()
    {
        Room.RoomListReq roomList = new Room.RoomListReq();
        NetClient.Instance().WriteMsg("Room.RoomListReq", roomList);
    }

    public static void EnterRoom(int roomId)
    {
        Room.EnterReq enter = new Room.EnterReq();
        enter.room_id = roomId;
        NetClient.Instance().WriteMsg("Room.EnterReq", enter);
    }

    public static void LeaveRoom()
    {
        Room.LeaveReq leave = new Room.LeaveReq();
        NetClient.Instance().WriteMsg("Room.LeaveReq", leave);
    }

    public static void Ready()
    {
        Table.ReadyReq ready = new Table.ReadyReq();
        NetClient.Instance().WriteMsg("Table.ReadyReq", ready);
    }
    public static void MoveReq(Move move)
    {
        Table.MoveReq moveReq = new Table.MoveReq();
        moveReq.move = move;
        NetClient.Instance().WriteMsg("Table.MoveReq", moveReq);
    }

}
