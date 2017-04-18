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
        dic.Add("Table.MatchRsp", match_rsp);
    }

    private void login_rsp(Msg msg)
    {
        //登录返回
    }
    private void match_rsp(Msg msg)
    {
        //匹配返回
    }
    public void onUpdate()
    {
        NetWork.Msg msg = NetClient.Instance().PeekMsg();
        if (msg == null)
            return;
        dic[msg.name].Invoke(msg);
    }
}
