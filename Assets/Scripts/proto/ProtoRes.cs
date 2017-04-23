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
       
        dic.Add("Room.RoomListReq", roomList_rsp);
        dic.Add("Room.EnterRsp", enterRoom_rsp);
        dic.Add("Room.leaveRsp", leaveRoom_rsp);

        dic.Add("Table.MatchRsp", match_rsp);
        dic.Add("Table.MatchResult", matchResult_rsp);
        dic.Add("Table.ReadyRsp", ready_rsp);
        dic.Add("Table.ReadyNotify", ready_notify);
        dic.Add("Table.StartNotify", start_notify);
        dic.Add("MoveNotify", move_notify);
    }

   
    public void onUpdate()
    {
        NetWork.Msg msg = NetClient.Instance().PeekMsg();
        if (msg == null)
            return;
        dic[msg.name].Invoke(msg);
    }
    #region login
    private void login_rsp(Msg msg)
    {
        //登录返回
        Debug.Log("登录成功");
    }
    #endregion

    #region room
    private void roomList_rsp(Msg msg)
    {
        
    }
    private void enterRoom_rsp(Msg msg)
    {
        
    }

    private void leaveRoom_rsp(Msg msg)
    {

    }
    #endregion

    #region table
    private void match_rsp(Msg msg)
    {
        //匹配返回
    }

    private void matchResult_rsp(Msg msg)
    {

    }

    private void ready_rsp(Msg msg)
    {

    }
    private void ready_notify(Msg msg)
    {

    }

    private void start_notify(Msg msg)
    {

    }

    private void move_notify(Msg msg)
    {

    }
    #endregion 
}
