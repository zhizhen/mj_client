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
        dic.Add("Table.Join", joined);
        dic.Add("Table.JoinRsp", joinTable_rsp);
        dic.Add("Table.QuitRsp", quit_rsp);
        dic.Add("Table.Ready", ready_rsp);
        dic.Add("Table.Start", start);
        dic.Add("Table.Cards", get_cards);
        dic.Add("Table.Turn", turn);
        dic.Add("Table.Play", play);
        dic.Add("Table.Gang", gang);
        dic.Add("Table.Peng", peng);
        dic.Add("Table.Pass", pass);
        dic.Add("Table.NewCard", newCard);
        dic.Add("Table.Angang",anGang);
        dic.Add("Table.Hu", hu);

        dic.Add("Table.RoundScore", roundScore);
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
    private void joined(Msg msg)
    {
        TableController.Instance.joined((Table.Join)msg.body);
    }
    private void ready_rsp(Msg msg)
    {
        TableController.Instance.ready((Table.Ready)msg.body);
    }
    private void start(Msg msg)
    {
        TableController.Instance.start((Table.Start)msg.body);
    }
    private void get_cards(Msg msg)
    {
        TableController.Instance.getCards((Table.Cards)msg.body);
    }

    private void turn(Msg msg)
    {
        TableController.Instance.turn((Table.Turn)msg.body);
    }

    private void play(Msg msg)
    {
        TableController.Instance.play((Table.Play)msg.body);

    }
    private void peng(Msg msg)
    {
        TableController.Instance.peng((Table.Peng)msg.body);
    }
    private void gang(Msg msg)
    {
        TableController.Instance.gang((Table.Gang)msg.body);

    }

    private void pass(Msg msg)
    {
        TableController.Instance.pass((Table.Pass)msg.body);

    }
    private void newCard(Msg msg)
    {
        TableController.Instance.newCard((Table.NewCard)msg.body);

    }

    private void anGang(Msg msg)
    {
        TableController.Instance.anGang((Table.Angang)msg.body);
    }

    private void quit_rsp(Msg msg)
    {
        TableController.Instance.quitTable((Table.QuitRsp)msg.body);
    }

    private void hu(Msg msg)
    {
        TableController.Instance.hu((Table.Hu)msg.body);
    }

    private void roundScore(Msg msg)
    {
        TableController.Instance.roundScore((Table.RoundScore)msg.body);
    }
    #endregion
}
