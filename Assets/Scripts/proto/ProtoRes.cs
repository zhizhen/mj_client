using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NetWork;
using System;

public class ProtoRes:Singleton<ProtoRes>{
    public delegate void ON_RES(NetWork.Msg msg);
    public ON_RES onRes;
    private Dictionary<string, ON_RES> dic;
    public ProtoRes()
    {
        dic = new Dictionary<string, ON_RES>();
        addRes();
        GlobleTimer.Instance.update += delegate (float dt)
          {
              onUpdate();
          };
    }

    private void addRes()
    {
        dic.Add("Login.LoginRsp", login_rsp);
       
        dic.Add("Room.RoomListRsp", roomList_rsp);
        dic.Add("Room.EnterRsp", enterRoom_rsp);
        dic.Add("Room.leaveRsp", leaveRoom_rsp);

        dic.Add("Table.CreateRsp", createTable_rsp);
        dic.Add("Table.JoinRsp", joinTable_rsp);
        dic.Add("Table.MatchResult", matchResult_rsp);
        dic.Add("Table.ReadyRsp", ready_rsp);
        dic.Add("Table.ReadyNotify", ready_notify);
        dic.Add("Table.StartNotify", start_notify);
        dic.Add("Table.MoveNotify", move_notify);
        dic.Add("Table.Cards", get_cards);
        dic.Add("Table.Turn", turn);
        dic.Add("Table.Play", play);
        dic.Add("Table.Gang", gang);
        dic.Add("Table.Pass", pass);
        dic.Add("Table.NewCard", newCard);
    }

   
    public void onUpdate()
    {
        NetWork.Msg msg = NetClient.Instance().PeekMsg();
        if (msg == null)
            return;
        Debug.Log("收到协议"+msg.name);
        dic[msg.name].Invoke(msg);
    }
    #region login
    private void login_rsp(Msg msg)
    {
        //登录返回
        LoginController.Instance.LoginBack((Login.LoginRsp)msg.body);

    }
    #endregion

    #region room
    private void roomList_rsp(Msg msg)
    {
        //RoomController.Instance.InitRoomList((Room.RoomListRsp)msg.body);
    }
    private void enterRoom_rsp(Msg msg)
    {
        //RoomController.Instance.enteredRoom((Room.EnterRsp)msg.body);
        HallPanel.Instance.load();
    }

    private void leaveRoom_rsp(Msg msg)
    {
        Debug.Log("收到Room.leaveRsp");
    }
    #endregion

    #region table
    private void createTable_rsp(Msg msg)
    {
        TableController.Instance.createdTable((Table.CreateRsp)msg.body);
    }
    private void joinTable_rsp(Msg msg)
    {
        TableController.Instance.joinedTable((Table.JoinRsp)msg.body);
    }

    private void matchResult_rsp(Msg msg)
    {
        TableController.Instance.matched((Table.MatchResult)msg.body);
    }

    private void ready_rsp(Msg msg)
    {
        Debug.Log("收到Table.ReadyRsp");
    }
    private void ready_notify(Msg msg)
    {
        Debug.Log("收到Table.ReadyNotify");
    }

    private void start_notify(Msg msg)
    {
        Debug.Log("收到Table.StartNotify");
    }

    private void move_notify(Msg msg)
    {
        Debug.Log("收到Table.MoveNotify");
    }

    private void get_cards(Msg msg)
    {
        TableController.Instance.getCards((Table.Cards)msg.body);
    }

    private void turn(Msg msg)
    {

    }

    private void play(Msg msg)
    {


    }

    private void gang(Msg msg)
    {


    }

    private void pass(Msg msg)
    {


    }
    private void newCard(Msg msg)
    {


    }
    #endregion 
}
