using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomPanel : BasePanel {

    private static RoomPanel instance;
    public static RoomPanel Instance
    {
        get
        {
            if (instance == null)
                instance = new RoomPanel();
            return instance;
        }

    }
    private RoomPanel()
    {
        base_name = PanelTag.ROOM_PANEL;
    }

    private Button _zhunbei;
    private Button _get;
    private GameObject _list;
    private GameObject _grid;
    private GameObject _last;
    private int _curCard;
    private Button _otherCardClick;
    private GameObject _otherCard;

    private Text _tableNum;


    private GameObject _always;
    private GameObject _before;
    private GameObject _afterBase;
    private GameObject _after;

    private GameObject _card;

    private GameObject _count;
    private GameObject _center;

    private GameObject _self;
    private GameObject _top;
    private GameObject _left;
    private GameObject _right;

    private GameObject _leftCard;
    private GameObject _selfCard;
    private GameObject _topCard;
    private GameObject _rightCard;

    private GameObject _fun;
    private Button _hu;
    private Button _gang;
    private Button _peng;
    private Button _pass;

    private GameObject _handCard;
    private int _curHeCard;

    public bool isTurn = false;
    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _always = uiSprite.FindChild("always").gameObject;
        _before = uiSprite.FindChild("before").gameObject;
        _afterBase = uiSprite.FindChild("afterBase").gameObject;

        _tableNum = _always.transform.FindChild("number").GetComponent<Text>();
        _count = _always.transform.FindChild("count").gameObject;
        _center = _always.transform.FindChild("center").gameObject;

        _fun = uiSprite.transform.FindChild("fun").gameObject;
        _hu = _fun.transform.FindChild("hu").GetComponent<Button>();
        _gang = _fun.transform.FindChild("gang").GetComponent<Button>();
        _peng = _fun.transform.FindChild("peng").GetComponent<Button>();
        _pass = _fun.transform.FindChild("pass").GetComponent<Button>();

        //inittest();
        addClick();
    }

    public override void startUp(object obj = null)
    {
        base.startUp(obj);
        _always.SetActive(true);
        _before.SetActive(true);
        _afterBase.SetActive(false);
        _fun.SetActive(false);
        //_handCard.SetActive(false);
        //initCard();
        initHead();
        _tableNum.text = GameConst.tableId.ToString();
        _count.SetActive(false);
        addPlayer();
    }

    private void copyAfter()
    {
        if (_after != null)
            GameObject.Destroy(_after);
        _after = GameObject.Instantiate(_afterBase);
        _after.name = "after";
        _after.transform.parent = _afterBase.transform.parent;
        _after.transform.position = _afterBase.transform.position;
        _card = _after.transform.FindChild("card").gameObject;

        _self = _card.transform.FindChild("self").gameObject;
        _top = _card.transform.FindChild("top").gameObject;
        _left = _card.transform.FindChild("left").gameObject;
        _right = _card.transform.FindChild("right").gameObject;

        _selfCard = _after.transform.FindChild("selfCard").gameObject;
        _leftCard = _after.transform.FindChild("leftCard").gameObject;
        _rightCard = _after.transform.FindChild("rightCard").gameObject;
        _topCard = _after.transform.FindChild("topCard").gameObject;

        _handCard = _after.transform.FindChild("handCard").gameObject;

        for (int i = 0; i < _selfCard.transform.FindChild("hand/grid").childCount; i++)
        {
            int index = i;
            Transform obj = _selfCard.transform.FindChild("hand/grid").GetChild(index);
            obj.GetComponent<Button>().onClick.AddListener(delegate
            {
                if (!isTurn)
                    return;
                isTurn = false;
                string name = obj.FindChild("value").GetComponent<Image>().sprite.name;
                int num = GameTools.getCardNumByName(name);
                Debug.Log("牌号:" + GameTools.getCardNumByName(name));
                CardController.Instance.delCard(CardConst.getCardInfo(num).type, CardConst.getCardInfo(num).value);
                ProtoReq.Play(num);
                //setSelfHe(num);
                initCard();
                endTimeCount();
            });
        }

        _handCard.GetComponent<Button>().onClick.AddListener(delegate
        {
            if (!isTurn)
                return;
            isTurn = false;
            string name = _handCard.transform.FindChild("value").GetComponent<Image>().sprite.name;
            int num = GameTools.getCardNumByName(name);
            Debug.Log("牌号:" + GameTools.getCardNumByName(name));
            CardController.Instance.delCard(CardConst.getCardInfo(num).type, CardConst.getCardInfo(num).value);
            ProtoReq.Play(num);
            //setSelfHe(num);
            initCard();
            endTimeCount();
        });
    }
    private void initHead()
    {
        for(int i=0;i<4;i++)
        {
            //IconMgr.Instance.SetHeadRawImage(_before.transform.FindChild("role" + i + "/head").GetComponent<RawImage>(), "111");
            _before.transform.FindChild("role" + i + "/head").gameObject.SetActive(false);
            _before.transform.FindChild("role" + i + "/ready").gameObject.SetActive(false);
        }
    }

    private void inittest()
    {
        CardProxy card1 = _self.GetComponent<CardProxy>();
        for (int i = 0; i < card1.cards.Length; i++)
        {
            IconMgr.Instance.SetImage(card1.cards[i].transform.FindChild("value").GetComponent<Image>(), "xia_1_" + Random.Range(1, 34));

        }

        CardProxy card2 = _top.GetComponent<CardProxy>();
        for (int i = 0; i < card2.cards.Length; i++)
        {
            IconMgr.Instance.SetImage(card2.cards[i].transform.FindChild("value").GetComponent<Image>(), "shang1_" + Random.Range(1, 34));

        }


        CardProxy card3 = _left.GetComponent<CardProxy>();
        for (int i = 0; i < card3.cards.Length; i++)
        {
            IconMgr.Instance.SetImage(card3.cards[i].transform.FindChild("value").GetComponent<Image>(), "zuo1_" + Random.Range(1, 34));

        }

        CardProxy card4 = _right.GetComponent<CardProxy>();
        for (int i = 0; i < card4.cards.Length; i++)
        {
            IconMgr.Instance.SetImage(card4.cards[i].transform.FindChild("value").GetComponent<Image>(), "you1_" + Random.Range(1, 34));

        }
    }
    private void initCard()
    {
        int index = 0;
        for (int i = CardController.Instance._myCardList.Length-1; i >=0 ; i--)
        {
            for (int j = CardController.Instance._myCardList[i].Count-1; j >=0 ; j--)
            {
                if (index == 13)
                {
                    IconMgr.Instance.SetImage(_handCard.transform.FindChild("value").GetComponent<Image>(), "zm1_" + CardConst.GetCardBigNum(i, CardController.Instance._myCardList[i][j]));
                    _handCard.SetActive(true);
                    index++;
                    isTurn = true;

                    if (CardController.Instance.checkCard(true))
                    {
                        _fun.SetActive(true);
                        _hu.gameObject.SetActive(true);
                    }
                    beginTimeCount();
                    return;
                }
                IconMgr.Instance.SetImage(_selfCard.transform.FindChild("hand/grid").transform.GetChild(index).FindChild("value").GetComponent<Image>(), "zm1_"+CardConst.GetCardBigNum(i,CardController.Instance._myCardList[i][j]));
                index++;
            }
        }
        if (index < 14)
        {
            _handCard.SetActive(false);
        }
        for (int i = 0; i < _selfCard.transform.FindChild("hand/grid").transform.childCount; i++)
        {
            if (i < index)
                _selfCard.transform.FindChild("hand/grid").transform.GetChild(i).gameObject.SetActive(true);
            else
                _selfCard.transform.FindChild("hand/grid").transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    //改变其他人手牌的显示s
    private void initOtherHandCard(int pos)
    {
        GameObject obj = null;
        int sum = 0;
        switch (pos)
        {
            case 1:
                obj = _rightCard.transform.FindChild("hand/grid").gameObject;
                sum = DataMgr.Instance.rightCardNum;
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    if (i < sum)
                        obj.transform.GetChild(i).gameObject.SetActive(true);
                    else
                        obj.transform.GetChild(i).gameObject.SetActive(false);
                }
                break;
            case 2:
                obj = _topCard.transform.FindChild("hand/grid").gameObject;
                sum = DataMgr.Instance.topCardNum;
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    if (i < sum)
                        obj.transform.GetChild(i).gameObject.SetActive(true);
                    else
                        obj.transform.GetChild(i).gameObject.SetActive(false);
                }
                break;
            case 3:
                obj = _leftCard.transform.FindChild("hand/grid").gameObject;
                sum = DataMgr.Instance.leftCardNum;
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    if (i < sum)
                        obj.transform.GetChild(obj.transform.childCount-1-i).gameObject.SetActive(true);
                    else
                        obj.transform.GetChild(obj.transform.childCount - 1-i).gameObject.SetActive(false);
                }
                break;
        }

       

    }
    private void addClick()
    {

        _hu.onClick.AddListener(delegate
        {
            //CardController.Instance.hu
            // ProtoReq.
            _fun.SetActive(false);
            _hu.gameObject.SetActive(false);
            _peng.gameObject.SetActive(false);
            _gang.gameObject.SetActive(false);
        });
        _gang.onClick.AddListener(delegate {
            // ProtoReq.Gang(0);//没记录牌
            ProtoReq.Gang(DataMgr.Instance._curCard);
            _fun.SetActive(false);
            _hu.gameObject.SetActive(false);
            _peng.gameObject.SetActive(false);
            _gang.gameObject.SetActive(false);
        });
        _peng.onClick.AddListener(delegate {
            //CardController.Instance.peng(0, 0);
            ProtoReq.Peng(DataMgr.Instance._curCard);
            isTurn = true;
            _fun.SetActive(false);
            _hu.gameObject.SetActive(false);
            _peng.gameObject.SetActive(false);
            _gang.gameObject.SetActive(false);
        });

        _pass.onClick.AddListener(delegate {
            //ProtoReq.Pass();
            endTimeCount();
        });
        _before.transform.FindChild("invite").GetComponent<Button>().onClick.AddListener(delegate
        {
            weixinInvite();
        });

        _before.transform.FindChild("Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            toReady();
        });
    }

    private void setSelfHe(int num)
    {
        IconMgr.Instance.SetImage(_self.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[0]].transform.FindChild("value").GetComponent<Image>(), "xia_1_"+num);
        _self.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[0]].SetActive(true);
    }
    private void setTopHe(int num)
    {
        IconMgr.Instance.SetImage(_top.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[2]].transform.FindChild("value").GetComponent<Image>(), "shang1_" + num);
        _top.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[2]].SetActive(true);

    }
    private void setLeftHe(int num)
    {
        IconMgr.Instance.SetImage(_left.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[3]].transform.FindChild("value").GetComponent<Image>(), "zuo1_" + num);
        _left.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[3]].SetActive(true);
    }

    private void setRightHe(int num)
    {
        IconMgr.Instance.SetImage(_right.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[1]].transform.FindChild("value").GetComponent<Image>(), "you1_" + num);
        _right.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[1]].SetActive(true);
    }

    private void selfGang(int card,int pos)
    {
        CardController.Instance.gang(CardConst.getCardInfo(card).type, CardConst.getCardInfo(card).value);
        initCard();
        newPengOrGang(_selfCard.transform.FindChild("other/grid/" + pos + "Gang").gameObject, card);
    }

    private void topGang(int card, int pos)
    {
        DataMgr.Instance.topCardNum -= 3;
        initOtherHandCard(2);

        newPengOrGang(_topCard.transform.FindChild("other/grid/" + pos + "Geng").gameObject, card);
    }

    private void leftGang(int card, int pos)
    {
        DataMgr.Instance.leftCardNum -= 3;
        initOtherHandCard(3);

        newPengOrGang(_leftCard.transform.FindChild("other/grid/" + pos + "Geng").gameObject, card);
    }
    private void rightGang(int card, int pos)
    {
        DataMgr.Instance.rightCardNum -= 3;
        initOtherHandCard(1);

        newPengOrGang(_rightCard.transform.FindChild("other/grid/" + pos + "Geng").gameObject, card);
    }

    private void selfPeng(int card,int pos)
    {
        CardController.Instance.peng(CardConst.getCardInfo(card).type, CardConst.getCardInfo(card).value);
        initCard();

        newPengOrGang(_selfCard.transform.FindChild("other/grid/"+pos+"Peng").gameObject,card);
    }

    private void topPeng(int card,int pos)
    {
        DataMgr.Instance.topCardNum -= 3;
        initOtherHandCard(2);
        Debug.Log("pengPos" + pos);
        newPengOrGang(_topCard.transform.FindChild("other/grid/" + pos + "Peng").gameObject, card);
    }

    private void leftPeng(int card,int pos)
    {
        DataMgr.Instance.leftCardNum -= 3;
        initOtherHandCard(3);
        Debug.Log("pengPos" + pos);
        newPengOrGang(_leftCard.transform.FindChild("other/grid/" + pos + "Peng").gameObject, card);
    }

    private void rightPeng(int card,int pos)
    {
        DataMgr.Instance.rightCardNum -= 3;
        initOtherHandCard(1);
        Debug.Log("pengPos" + pos);
        newPengOrGang(_rightCard.transform.FindChild("other/grid/" + pos + "Peng").gameObject, card);
    }
    public override void AddListener()
    {
        base.AddListener();
        EventDispatcher.Instance.AddEventListener<int>(GameEventConst.READY_TO_PALY, onReady);
        EventDispatcher.Instance.AddEventListener(GameEventConst.CARD_TO_HAND, getCard);
        EventDispatcher.Instance.AddEventListener<int>(GameEventConst.GET_NEW_CARD, getCurCard);
        EventDispatcher.Instance.AddEventListener<int, int>(GameEventConst.PUT_HE_CARD, putHeCard);
        EventDispatcher.Instance.AddEventListener(GameEventConst.ADD_PLAYER, addPlayer);
        EventDispatcher.Instance.AddEventListener<bool,int>(GameEventConst.TURN_TO, turnTo);
        EventDispatcher.Instance.AddEventListener<int, int, int>(GameEventConst.PENG, onPeng);
        EventDispatcher.Instance.AddEventListener<int, int, int>(GameEventConst.GANG, onGang);
        EventDispatcher.Instance.AddEventListener(GameEventConst.TIME_COUNT_END, onTimeEnd);
    }

    public override void RemoveListener()
    {
        base.RemoveListener();
        EventDispatcher.Instance.RemoveEventListener<int>(GameEventConst.READY_TO_PALY, onReady);
        EventDispatcher.Instance.RemoveEventListener(GameEventConst.CARD_TO_HAND, getCard);
        EventDispatcher.Instance.RemoveEventListener<int>(GameEventConst.GET_NEW_CARD, getCurCard);
        EventDispatcher.Instance.RemoveEventListener<int, int>(GameEventConst.PUT_HE_CARD, putHeCard);
        EventDispatcher.Instance.RemoveEventListener(GameEventConst.ADD_PLAYER, addPlayer);
        EventDispatcher.Instance.RemoveEventListener<bool,int>(GameEventConst.TURN_TO, turnTo);
        EventDispatcher.Instance.RemoveEventListener<int, int, int>(GameEventConst.PENG, onPeng);
        EventDispatcher.Instance.RemoveEventListener<int, int, int>(GameEventConst.GANG, onGang);
        EventDispatcher.Instance.RemoveEventListener(GameEventConst.TIME_COUNT_END, onTimeEnd);
    }
    private void onTimeEnd()
    {
        //if (isTurn)
        //{
        //    isTurn = false;
          
        //    if (_handCard.activeSelf)
        //    {
        //        string name = _handCard.transform.FindChild("value").GetComponent<Image>().sprite.name;
        //        int num = GameTools.getCardNumByName(name);
        //        Debug.Log("牌号:" + GameTools.getCardNumByName(name));
        //        CardController.Instance.delCard(CardConst.getCardInfo(num).type, CardConst.getCardInfo(num).value);
        //        ProtoReq.Play(num);
        //        //setSelfHe(num);
        //        initCard();
        //    }
        //    else
        //    {
        //        ProtoReq.Pass();
        //    }
        //    endTimeCount();
        //}
    }

    private void onPeng(int pos,int fromPos,int card)
    {
        Debug.Log("转化为pos" + pos);
        Debug.Log("来自pos" + fromPos);
        switch (fromPos)
        {
            case 0:
                _self.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[0]-1].SetActive(false);
                break;
            case 1:
                _right.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[1]-1].SetActive(false);
                break;
            case 2:
                _top.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[2]-1].SetActive(false);
                break;
            case 3:
                _left.GetComponent<CardProxy>().cards[DataMgr.Instance.heCardIndex[3]-1].SetActive(false);
                break;
        }
        DataMgr.Instance.heCardIndex[DataMgr.Instance.curHeIndex]--;
        switch (pos)
        {
            case 0:
                selfPeng(card, fromPos);
                isTurn = true;
                break;
            case 1:
                rightPeng(card, fromPos);
                break;
            case 2:
                topPeng(card, fromPos);
                break;
            case 3:
                leftPeng(card, fromPos);
                break;
        }
    }

    private void onGang(int pos, int fromPos, int card)
    {
        switch (pos)
        {
            case 0:
                selfGang(card, fromPos);
                isTurn = true;
                break;
            case 1:
                rightGang(card, fromPos);
                break;
            case 2:
                topGang(card, fromPos);
                break;
            case 3:
                leftGang(card, fromPos);
                break;
        }
    }

    //收到那个人的turn
    private void turnTo(bool boo,int id)
    {
        if (GameConst.zhuang)
        {
            GameConst.zhuangPos = id.idToPos();
            if (GameConst.zhuangPos == 1)
                DataMgr.Instance.rightCardNum = 14;
            if (GameConst.zhuangPos == 2)
                DataMgr.Instance.topCardNum = 14;
            if (GameConst.zhuangPos == 3)
                DataMgr.Instance.leftCardNum = 14;
            GameConst.zhuang = false;
        }
        if (boo)
        {
            //自己的turn
            Debug.Log("自己的turn");
        }
        else
        {
            //比人的turn
            Debug.Log("别人的turn");
            beginTimeCount();
        }
    }
    private void addPlayer()
    {
        foreach (var item in RoleController.Instance._playerDic)
        {
            Transform obj = _before.transform.FindChild("role" + item.Value.Pos);
            if (obj != null)
            {
                IconMgr.Instance.SetHeadRawImage(obj.FindChild("head").GetComponent<RawImage>(), item.Value.Name);
                obj.FindChild("head").gameObject.SetActive(true);

                _before.transform.FindChild("role" + RoleController.Instance.getPlayerPos(item.Value.Id) + "/ready").gameObject.SetActive(item.Value.IsReady);
            }
        }
    }
    private void putHeCard(int pos, int card)
    {
        switch (pos)
        {
            case 0:
                setSelfHe(card);
                break;
            case 1:
                setRightHe(card);
                break;
            case 2:
                setTopHe(card);
                break;
            case 3:
                setLeftHe(card);
                break;
        }
        if (pos < 4)
        {
            DataMgr.Instance.heCardIndex[pos]++;
            DataMgr.Instance.curHeIndex = pos;
        }
        if (pos!=MainRole.Instance.Id.idToPos())
        {
            Debug.Log("检测00000");
            Card card1 = new Card(DataMgr.Instance._curCard);
            //一系列判断
            CardController.Instance.addCard(card1.CardType, card1.CardNum);

            if (CardController.Instance.checkCard(false))
            {
                _fun.SetActive(true);
                _hu.gameObject.SetActive(true);
            }
            else
            {
                CardController.Instance.delCard(card1.CardType, card1.CardNum);
                _hu.gameObject.SetActive(false);
            }
            if (CardController.Instance.checkPeng(card1.CardType, card1.CardNum))
            {
                _fun.SetActive(true);
                _peng.gameObject.SetActive(true);
            }
            if (CardController.Instance.checkGang(card1.CardType, card1.CardNum))
            {
                _fun.SetActive(true);
                _gang.gameObject.SetActive(true);
            }

        }
    }

    private void onReady(int id)
    {
        _before.transform.FindChild("role" + RoleController.Instance.getPlayerPos(id) + "/ready").gameObject.SetActive(true);
    }
    private void weixinInvite()
    {
        Debug.Log("微信邀请");
    }
    private void toReady()
    {
        ProtoReq.Ready();
    }
    private void getCard()
    {
        //SoundMgr._instance.bgmPlay("beijing-fangjian");
        GameConst.zhuang = true;
        copyAfter(); 
        _after.SetActive(true);
        _before.SetActive(false);
        _hu.gameObject.SetActive(false);
        _peng.gameObject.SetActive(false);
        _gang.gameObject.SetActive(false);
        _pass.gameObject.SetActive(false);
        initCard();

        initFeng();
    }

    private void initFeng()
    {
        Debug.Log("风" + MainRole.Instance.Pos);
        _center.transform.localRotation = Quaternion.Euler(0, 0, -(90 * (MainRole.Instance.Pos-1)));

    }

    private void setFengLight(int pos)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == pos)
                _center.transform.FindChild(i.ToString()).gameObject.SetActive(true);
            else
                _center.transform.FindChild(i.ToString()).gameObject.SetActive(false);
        }
    }

    private void getCurCard(int num)
    {
        IconMgr.Instance.SetImage(_handCard.transform.FindChild("value").GetComponent<Image>(), "zm1_" + num);
        beginTimeCount();
        isTurn = true;
        DataMgr.Instance._curCard = num;
        Card card = new Card(DataMgr.Instance._curCard);
        //一系列判断
        CardController.Instance.addCard(card.CardType, card.CardNum);
        _handCard.SetActive(true);
        if (CardController.Instance.checkCard(true))
        {
            _fun.SetActive(true);
            _hu.gameObject.SetActive(true);
        }
    }

    private void beginTimeCount()
    {
        _count.GetComponent<TimeCount>().time = GameConst.timeCount;
        _count.SetActive(true);
    }

    private void endTimeCount()
    {
        _count.SetActive(false);
        _fun.SetActive(false);
        _hu.gameObject.SetActive(false);
        _peng.gameObject.SetActive(false);
        _gang.gameObject.SetActive(false);
    }
    private void newPengOrGang(GameObject gameObject,int card)
    {
        GameObject objItem = GameObject.Instantiate(gameObject);
        objItem.transform.parent = gameObject.transform.parent;
        objItem.SetActive(true);
        PengAndGangProxy proxy = objItem.GetComponent<PengAndGangProxy>();
        for (int i = 0; i < proxy.startStrs.Length; i++)
        {
            IconMgr.Instance.SetImage(proxy.images[i], proxy.startStrs[i] + card);
        }
        
    }
}
