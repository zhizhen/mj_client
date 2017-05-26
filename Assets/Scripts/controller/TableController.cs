using UnityEngine;
using System.Collections;

public class TableController :Singleton<TableController> {


    public void getCards(Table.Cards cards)
    {
        Debug.Log("收到牌");
        for (int i = 0; i < cards.cards.Count; i++)
        {
            CardController.Instance.addCard(CardConst.getCardInfo(cards.cards[i]).type, CardConst.getCardInfo(cards.cards[i]).value);
        }
        EventDispatcher.Instance.Dispatch(GameEventConst.CARD_TO_HAND);
    }

    public void createdTable(Table.CreateRsp create)
    {
        Debug.Log("桌子号" + create.tab_id);
        GameConst.tableId = create.tab_id;
        GameConst.isFangzZhu = true;
        // RoomPanel.Instance.load(); 
        ProtoReq.JoinTable(create.tab_id);
    }

    public void joinedTable(Table.JoinRsp join)
    {
        Debug.Log("JoinRsp");
        for (int i = 0; i < join.roles.Count; i++)
        {
            RoleController.Instance.addPlayer(join.roles[i]);
            
            Debug.Log("role" + i + join.roles[i].name);
        }
        RoomPanel.Instance.load();
    }

    public void joined(Table.Join join)
    {
        Debug.Log("Join");
        RoleController.Instance.addPlayer(join.role);
        EventDispatcher.Instance.Dispatch(GameEventConst.ADD_PLAYER);
    }

    public void ready(Table.Ready ready)
    {
        RoleController.Instance.getPlayerById(ready.id).IsReady = true;
        EventDispatcher.Instance.Dispatch(GameEventConst.READY_TO_PALY,ready.id);
    }

    public void turn(Table.Turn turn)
    {
        Debug.Log("turn的回合");
        if (turn.id == MainRole.Instance.Id)
        {
            EventDispatcher.Instance.Dispatch(GameEventConst.TURN_TO, true,turn.id);
        }
        else
        {
            EventDispatcher.Instance.Dispatch(GameEventConst.TURN_TO, false,turn.id);
        }
    }
    public void start(Table.Start start)
    {
        Debug.Log("收到start协议");
        
        DataMgr.Instance.zhuangId = start.id;
        DataMgr.Instance.curRound = start.round;
        if (start.status == 1)
        {
            EventDispatcher.Instance.Dispatch(GameEventConst.START);
        }

    }
    public void play(Table.Play play)
    {
        Debug.Log("收到play返回");
        if (play.err_no == 0)
        {
            DataMgr.Instance._curCard = play.card;
            Debug.Log("现在的cur" + play.card);
            EventDispatcher.Instance.Dispatch(GameEventConst.PUT_HE_CARD, play.id.idToPos(), play.card);
        }
        else
        {
            QuickTips.ShowRedQuickTips("play___" + play.err_no);
        }
       
    }

    public void gang(Table.Gang gang)
    {
        if (gang.err_no == 0)
            EventDispatcher.Instance.Dispatch(GameEventConst.GANG, gang.id.idToPos(), gang.from.idToPos(), gang.card);
        else
            QuickTips.ShowRedQuickTips("Gang__" + gang.err_no);
    }

    public void peng(Table.Peng peng)
    {
        if (peng.err_no == 0)
            EventDispatcher.Instance.Dispatch(GameEventConst.PENG, peng.id.idToPos(), peng.from.idToPos(), peng.card);
        else
            QuickTips.ShowRedQuickTips("peng___" + peng.err_no);
    }
    public void pass(Table.Pass pass)
    {

    }

    public void newCard(Table.NewCard card)
    {
        Debug.Log("摸牌");
        EventDispatcher.Instance.Dispatch(GameEventConst.GET_NEW_CARD,card.id,card.card,card.leftcard);
    }

    public void anGang(Table.Angang gang)
    {
        Debug.Log("暗杠");
        EventDispatcher.Instance.Dispatch<int,int>(GameEventConst.AN_GANG, gang.id.idToPos(), gang.card);
    }

    public void quitTable(Table.QuitRsp quit)
    {
        Debug.Log("退出");
        HallPanel.Instance.load();

    }
    public void hu(Table.Hu hu)
    {
        if (hu.err_no == 0)
            Debug.Log("胡了");
        else
            QuickTips.ShowRedQuickTips("hu___" + hu.err_no);
    }
}
