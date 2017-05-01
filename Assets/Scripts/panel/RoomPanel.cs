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
    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _zhunbei = uiSprite.FindChild("Button").GetComponent<Button>();
        _get = uiSprite.FindChild("get").GetComponent<Button>();
        _list = uiSprite.FindChild("list").gameObject;
        _grid = _list.transform.FindChild("grid").gameObject;
        _last = uiSprite.FindChild("last").gameObject;
        _otherCardClick = uiSprite.FindChild("OtherCardClick").GetComponent<Button>();
        _last.SetActive(false);
        _list.SetActive(false);

        _zhunbei.onClick.AddListener(delegate
        {
            //ProtoReq.Ready();
            CardController.Instance.init();
            //CardController.Instance.printAllCard();
            initCard();
        });
        _get.onClick.AddListener(delegate {
            int value = Random.Range(1, 35);
            _curCard = value;
            IconMgr.Instance.SetImage(_last.transform.FindChild("value").GetComponent<Image>(),CardConst.getCardInfo(value).type+"_"+CardConst.getCardInfo(value).value);
            _last.SetActive(true);
        });
        addClick();



        _always = uiSprite.FindChild("always").gameObject;
        _before = uiSprite.FindChild("before").gameObject;
        _after = uiSprite.FindChild("after").gameObject;


    }

    private void initCard()
    {
        int index = 0;
        for (int i = 0; i < CardController.Instance._myCardList.Length; i++)
        {
            for (int j = 0; j < CardController.Instance._myCardList[i].Count; j++)
            {
                IconMgr.Instance.SetImage(_grid.transform.GetChild(index).FindChild("value").GetComponent<Image>(), i + "_" + CardController.Instance._myCardList[i][j]);
                index++;
            }
        }
        _list.SetActive(true);
    }

    private void addClick()
    {
        for (int i = 0; i < _grid.transform.childCount; i++)
        {
            int num = i;
            Transform button = _grid.transform.GetChild(num);
            button.GetComponent<Button>().onClick.AddListener(delegate
            {

                string name = button.FindChild("value").GetComponent<Image>().sprite.name;
                string[] str = name.Split('_');
                CardController.Instance.delCard(int.Parse(str[0]), int.Parse(str[1]));
                CardController.Instance.addCard(CardConst.getCardInfo(_curCard).type, CardConst.getCardInfo(_curCard).value);
                _last.SetActive(false);
                initCard();
            });
        }

        _last.GetComponent<Button>().onClick.AddListener(delegate
        {
            _last.SetActive(false);
        });
    }
}
