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
    private GameObject _after;

    private GameObject _card;

    private GameObject _self;
    private GameObject _top;
    private GameObject _left;
    private GameObject _right;

    private GameObject _leftCard;
    private GameObject _selfCard;
    private GameObject _topCard;
    private GameObject _rightCard;

    private Button _hu;
    private Button _gang;
    private Button _peng;
    private Button _pass;

    private GameObject _handCard;
    private int _curHeCard;
    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _always = uiSprite.FindChild("always").gameObject;
        _before = uiSprite.FindChild("before").gameObject;
        _after = uiSprite.FindChild("after").gameObject;

        _tableNum = _always.transform.FindChild("number").GetComponent<Text>();

        _card = _after.transform.FindChild("card").gameObject;
        _self = _card.transform.FindChild("self").gameObject;
        _top = _card.transform.FindChild("top").gameObject;
        _left = _card.transform.FindChild("left").gameObject;
        _right = _card.transform.FindChild("right").gameObject;

        _hu = _after.transform.FindChild("fun/hu").GetComponent<Button>();
        _gang = _after.transform.FindChild("fun/gang").GetComponent<Button>();
        _peng = _after.transform.FindChild("fun/peng").GetComponent<Button>();
        _pass = _after.transform.FindChild("fun/pass").GetComponent<Button>();

        _selfCard = _after.transform.FindChild("selfCard").gameObject;
        _leftCard  = _after.transform.FindChild("leftCard").gameObject;
        _rightCard = _after.transform.FindChild("rightCard").gameObject;
        _topCard = _after.transform.FindChild("rightCard").gameObject;

        _handCard = _after.transform.FindChild("handCard").gameObject;
        inittest();
        addClick();
    }

    public override void startUp(object obj = null)
    {
        base.startUp(obj);
        _always.SetActive(true);
        _before.SetActive(true);
        _after.SetActive(false);

        _handCard.SetActive(false);
        initCard();
        initHead();
        _tableNum.text = GameConst.tableId.ToString();
    }
    private void initHead()
    {
        for(int i=1;i<5;i++)
        {
            IconMgr.Instance.SetHeadRawImage(_before.transform.FindChild("role" + i + "/head").GetComponent<RawImage>(), "111");
           
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

    private void addClick()
    {

        _hu.onClick.AddListener(delegate
        {
            //CardController.Instance.hu
        });
        _gang.onClick.AddListener(delegate {
            CardController.Instance.gang(0,0);
            GameObject obj = _selfCard.transform.FindChild("other/grid/gang").gameObject;
            GameObject objItem = GameObject.Instantiate(obj);
            objItem.transform.parent = obj.transform.parent;
            objItem.SetActive(true);
            IconMgr.Instance.SetImage(objItem.transform.FindChild("card4/value").GetComponent<Image>(), "zm2_" + CardConst.GetCardBigNum(0, 0));
           
        });
        _peng.onClick.AddListener(delegate {
            CardController.Instance.peng(0, 0);

        });

        _pass.onClick.AddListener(delegate {
            
        });
        _before.transform.FindChild("invite").GetComponent<Button>().onClick.AddListener(delegate
        {
            weixinInvite();
        });

        _before.transform.FindChild("Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            toReady();
        });

        for (int i = 0; i < _selfCard.transform.FindChild("hand/grid").childCount; i++)
        {
            int index = i;
            Transform obj = _selfCard.transform.FindChild("hand/grid").GetChild(index);
            obj.GetComponent<Button>().onClick.AddListener(delegate
            {
                string name = obj.FindChild("value").GetComponent<Image>().sprite.name;
                int num = GameTools.getCardNumByName(name);
                Debug.Log("牌号:" + GameTools.getCardNumByName(name));
                CardController.Instance.delCard(CardConst.getCardInfo(num).type, CardConst.getCardInfo(num).value);
                initCard();
            });
        }

        _handCard.GetComponent<Button>().onClick.AddListener(delegate
        {
            string name = _handCard.transform.FindChild("value").GetComponent<Image>().sprite.name;
            int num = GameTools.getCardNumByName(name);
            Debug.Log("牌号:" + GameTools.getCardNumByName(name));
            CardController.Instance.delCard(CardConst.getCardInfo(num).type, CardConst.getCardInfo(num).value);
            initCard();
        });
    }

    public override void AddListener()
    {
        base.AddListener();
        EventDispatcher.Instance.AddEventListener(GameEventConst.READY_TO_PALY, onReady);
    }

    public override void RemoveListener()
    {
        base.RemoveListener();
        EventDispatcher.Instance.RemoveEventListener(GameEventConst.READY_TO_PALY, onReady);
    }

    private void onReady()
    {
        _after.SetActive(true);
        _before.SetActive(false);
        _hu.gameObject.SetActive(false);
        _peng.gameObject.SetActive(false);
        _gang.gameObject.SetActive(false);
        _pass.gameObject.SetActive(false);
        //_self.transform.FindChild("heCard").gameObject.SetActive(false);
        //_right.transform.FindChild("heCard").gameObject.SetActive(false);
        //_top.transform.FindChild("heCard").gameObject.SetActive(false);
        //_left.transform.FindChild("heCard").gameObject.SetActive(false);

        //_leftCard.transform.FindChild("hand").gameObject.SetActive(true);
        //_leftCard.transform.FindChild("other").gameObject.SetActive(false);

        //_topCard.transform.FindChild("hand").gameObject.SetActive(true);
        //_topCard.transform.FindChild("other").gameObject.SetActive(false);

        //_rightCard.transform.FindChild("hand").gameObject.SetActive(true);
        //_rightCard.transform.FindChild("other").gameObject.SetActive(false);

        //_selfCard.transform.FindChild("hand").gameObject.SetActive(true);
        //_selfCard.transform.FindChild("other").gameObject.SetActive(false);

    }
    private void weixinInvite()
    {
        Debug.Log("微信邀请");
    }
    private void toReady()
    {
        EventDispatcher.Instance.Dispatch(GameEventConst.READY_TO_PALY);
        //ProtoReq.Ready();
    }
}
