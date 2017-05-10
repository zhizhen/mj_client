﻿using UnityEngine;
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

    public int _curCard;

    public int leftCardNum;
    public int rightCardNum;
    public int topCardNum;

    public int selfHeCardIndex = 0;
    public int leftHeCardIndex = 0;
    public int rightHeCardIndex = 0;
    public int topHeCardIndex = 0;

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
    }
}
