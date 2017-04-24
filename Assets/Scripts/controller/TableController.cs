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

}
