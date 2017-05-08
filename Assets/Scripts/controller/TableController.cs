using UnityEngine;
using System.Collections;

public class TableController :Singleton<TableController> {


    public void matched(Table.MatchResult match)
    {
        //HallPanel.Instance.DestoryPanel();
        RoomPanel.Instance.load();
    }

    public void getCards(Table.Cards cards)
    {
        Debug.Log("收到牌");
    }

    public void createdTable(Table.CreateRsp create)
    {
        Debug.Log("桌子号" + create.tab_id);
        GameConst.tableId = create.tab_id;
        // RoomPanel.Instance.load(); 
        ProtoReq.JoinTable(create.tab_id);
    }

    public void joinedTable(Table.JoinRsp join)
    {
        RoomPanel.Instance.load();
    }

    public void ready(Table.ReadyRsp ready)
    {
        EventDispatcher.Instance.Dispatch(GameEventConst.READY_TO_PALY);
    }
}
