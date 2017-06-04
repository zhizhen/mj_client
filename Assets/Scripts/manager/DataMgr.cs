using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataMgr : Singleton<DataMgr> {

    public List<int> _leftCardList;//zuo起的类型牌
    public List<int> _leftPengCardList;//zuo碰的类型牌
    public List<int> _leftGangCardList;//zuo扛的类型牌

    public List<int> _topCardList;//shang起的类型牌
    public List<int> _topPengCardList;//shang碰的类型牌
    public List<int> _topGangCardList;//shang扛的类型牌

    public List<int> _rightCardList;//you起的类型牌
    public List<int> _rightPengCardList;//you碰的类型牌
    public List<int> _rightGangCardList;//you扛的类型牌

    public List<int> _selfCardList;

    public Dictionary<int, Dictionary<int,GameObject>> _everyPeng;

    public int _curCard;

    public int leftCardNum = 13;
    public int rightCardNum = 13;
    public int topCardNum = 13;

    public int leftOtherPos = 0;
    public int TopOtherPos = 0;
    public int rightOtherPos = 0;
    public int selfOtherPos = 0;

    public int[] heCardIndex = { 0, 0, 0, 0 };
    public int curHeIndex = 0;

    public int curRound = 1;
    public int zhuangId = 0;


    public DataMgr()
    {
        _leftCardList = new List<int>();
        _leftPengCardList = new List<int>();
        _leftGangCardList = new List<int>();

        _topCardList = new List<int>();
        _topPengCardList = new List<int>();
        _topGangCardList = new List<int>();

        _rightCardList = new List<int>();
        _rightPengCardList = new List<int>();
        _rightGangCardList = new List<int>();

        _selfCardList = new List<int>();

        _everyPeng = new Dictionary<int, Dictionary<int, GameObject>>();
    }
}
