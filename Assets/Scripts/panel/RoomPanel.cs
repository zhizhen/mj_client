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




    private GameObject _always;
    private GameObject _before;
    private GameObject _after;

    private GameObject _card;

    private GameObject _self;
    private GameObject _top;
    private GameObject _left;
    private GameObject _right;

    private Button _hu;
    private Button _gang;
    private Button _peng;
    private Button _pass;

    private GameObject _selfCard;
    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _always = uiSprite.FindChild("always").gameObject;
        _before = uiSprite.FindChild("before").gameObject;
        _after = uiSprite.FindChild("after").gameObject;

        _card = uiSprite.FindChild("card").gameObject;
        _self = _card.transform.FindChild("self").gameObject;
        _top = _card.transform.FindChild("top").gameObject;
        _left = _card.transform.FindChild("left").gameObject;
        _right = _card.transform.FindChild("right").gameObject;

        _hu = _after.transform.FindChild("hu").GetComponent<Button>();
        _gang = _after.transform.FindChild("gang").GetComponent<Button>();
        _peng = _after.transform.FindChild("peng").GetComponent<Button>();
        _pass = _after.transform.FindChild("pass").GetComponent<Button>();

        _selfCard = uiSprite.FindChild("selfCard").gameObject;
        inittest();
        initCard();
        addClick();
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
        CardController.Instance.init();
        int index = 0;
        for (int i = 0; i < CardController.Instance._myCardList.Length; i++)
        {
            for (int j = 0; j < CardController.Instance._myCardList[i].Count; j++)
            {
                IconMgr.Instance.SetImage(_selfCard.transform.FindChild("hand/grid").transform.GetChild(index).FindChild("value").GetComponent<Image>(), "zm1_"+CardConst.GetCardBigNum(i,CardController.Instance._myCardList[i][j]));
                index++;
            }
        }
        //_list.SetActive(true);
    }

    private void addClick()
    {
        //for (int i = 0; i < _grid.transform.childCount; i++)
        //{
        //    int num = i;
        //    Transform button = _grid.transform.GetChild(num);
        //    button.GetComponent<Button>().onClick.AddListener(delegate
        //    {

        //        string name = button.FindChild("value").GetComponent<Image>().sprite.name;
        //        string[] str = name.Split('_');
        //        CardController.Instance.delCard(int.Parse(str[0]), int.Parse(str[1]));
        //        CardController.Instance.addCard(CardConst.getCardInfo(_curCard).type, CardConst.getCardInfo(_curCard).value);
        //        _last.SetActive(false);
        //        initCard();
        //    });
        //}

        //_last.GetComponent<Button>().onClick.AddListener(delegate
        //{
        //    _last.SetActive(false);
        //});

        _hu.onClick.AddListener(delegate
        {
            //CardController.Instance.hu
        });
        _gang.onClick.AddListener(delegate {
            CardController.Instance.gang(0,0);
        });
        _peng.onClick.AddListener(delegate {
            CardController.Instance.peng(0, 0);
        });

        _pass.onClick.AddListener(delegate {
            
        });
    }
}
