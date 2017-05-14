using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardController:Singleton<CardController>{

    public List<int>[] _myCardList;//起的类型牌
    private List<int>[] _pengCardList;//碰的类型牌
    private List<int>[] _gangCardList;//扛的类型牌

    public Card _lastCard;//最后起的牌

    private bool _9LBD;//是否听连宝灯牌型
    private bool _13Y;//是否听13幺
    private bool _4AK;//是否听4暗刻
    private int _MKNum;//明刻数
    private int _AKNum;//暗刻数
    

    private List<Card> _tempPengCardList;//碰的可选组合;
    private List<Card> _tempGangCardList;//扛的可选组合;

    public CardController()
    {
        _9LBD = false;
        _13Y = false;
        _4AK = false;
        _AKNum = 0;
        _MKNum = 0;
        _myCardList = new List<int>[5];
        _pengCardList = new List<int>[5];
        _gangCardList = new List<int>[5];
        for (int i = 0; i < 5; i++)
        {
            List<int> list1 = new List<int>();
            _myCardList[i] = list1;
            List<int> list2 = new List<int>();
            _pengCardList[i] = list2;
            List<int> list3 = new List<int>();
            _gangCardList[i] = list3;
        }
        _lastCard = new Card();
        _tempPengCardList = new List<Card>();
        _tempGangCardList = new List<Card>();
        init();
    }
    public void init()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    int value = Random.Range(1, 34);
        //    addCard(CardConst.getCardInfo(value).type, CardConst.getCardInfo(value).value);
        //}
        //printAllCard();
    }
    //起牌,加入新牌并排序
    public bool addCard(int type,int num)
    {
        int size = _myCardList[type].Count;
        bool _find = false;
        for (int i = 0; i < size; i++)
        {
            if (_myCardList[type][i] > num)
            {
                _myCardList[type].Insert(i, num);
                _find = true;
                break;
            }
        }
        if (_find == false)
        {
            _myCardList[type].Add(num);
        }
        _lastCard.CardType = type;
        _lastCard.CardNum = num;

        return true;

    }
    //获取对应麻将的索引
    public int getCardIndex(int type, int num)
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < _myCardList[i].Count; j++)
            {
                if (type == i && _myCardList[i][j] == num)
                {
                    return count;
                }
                count++;
            }
        }
        return -1;
    }
    //打牌
    public bool delCard(int index)
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < _myCardList[i].Count; j++)
            {
                if (count == index)
                {
                    _myCardList[i].RemoveAt(j);
                    return true;
                }
                count++;
            }
        }
        return false;
    }
    //删除牌
    public bool delCard(int type, int num)
    {
        for (int i = 0; i < _myCardList[type].Count; i++)
        {
            _myCardList[type].Remove(num);
            return true;
        }
        return false;
    }
    //清空牌
    public void cleanUp()
    {
        for (int i = 0; i < 5; i++)
        {
            _myCardList[i].Clear();
            _pengCardList[i].Clear();
            _gangCardList[i].Clear();
        }
    }
    //检测是否胡牌
    public bool checkCard(bool getOrPut)
    {
        //if (getOrPut == CARD_STATE.CARD_GET)
        //{
            if (checkD4X_HU())
            {
                Debug.Log("胡大四喜");
                return true;
            }
            if (checkD3Y_HU())
            {
                Debug.Log("胡大三元");
                return true;
            }
            if (Check4Gang_HU())
                return true;
            if (CheckX4X_HU())
                return true;
            if (CheckX3Y_HU())
                return true;
            if (Check7D_HU())
                return true;
            if (CheckHU())
            {
                return true;
            }
       // }
        return false;
    }
    //输出牌
    public void printAllCard()
    {
        for (int i = 0; i < _myCardList.Length; i++)
        {
            for (int j = 0; j < _myCardList[i].Count; j++)
            {
                Debug.Log(i + "-" + _myCardList[i][j]);
            }
        }
    }
    //输出某张牌
    public void printCard(int type, int num)
    { }
    //检测碰
    public bool checkPeng(int type, int num)
    {
        _tempPengCardList.Clear();
        if (_myCardList[type].Count != 0)
        {
            int iSize = _myCardList[type].Count;
            if (iSize >= 2)
            {
                for (int i = 0; i < iSize - 1; i++)
                {
                    if ((_myCardList[type][i] == num) && (_myCardList[type][i + 1] == num))
                    {
                        Card card = new Card();
                        card.CardType = type;
                        card.CardNum = num;
                        _tempPengCardList.Add(card);
                        break;
                    }
                }
            }

            if (_tempPengCardList.Count > 0)
            {
                return true;
            }
        }
        return false;
    }
    //碰
    public bool peng(int type, int num)
    {
        addCard(type, num);
        foreach (var item in _tempPengCardList)
        {
            delCard(item.CardType, item.CardNum);
            delCard(item.CardType, item.CardNum);
            delCard(item.CardType, item.CardNum);

            _pengCardList[item.CardType].Add(item.CardNum);
            _pengCardList[item.CardType].Add(item.CardNum);
            _pengCardList[item.CardType].Add(item.CardNum);
            return true;
        }
        return false;
    }
    //检测扛
    public bool checkGang(int type, int num)
    {
        _tempGangCardList.Clear();
        if (_myCardList[type].Count != 0)
        {
            int iSize = _myCardList[type].Count;
            if (iSize >= 3)
            {
                for (int i = 0; i < iSize - 2; i++)
                {
                    if ((_myCardList[type][i] == num) && (_myCardList[type][i + 1] == num) && (_myCardList[type][i + 2] == num))
                    {
                        Card card = new Card(type, num);
                        _tempGangCardList.Add(card);
                        break;
                    }
                }
            }

            if (_tempGangCardList.Count > 0)
                return true;
        }

        return false;
    }
    //扛
    public bool gang(int type,int num)
    {
        addCard(type, num);
        foreach (var item in _tempGangCardList)
        {
            delCard(item.CardType, item.CardNum);
            delCard(item.CardType, item.CardNum);
            delCard(item.CardType, item.CardNum);
            delCard(item.CardType, item.CardNum);

            if (_gangCardList[item.CardType].Count == 0)
            {
                _gangCardList[item.CardType].Add(item.CardNum);
                _gangCardList[item.CardType].Add(item.CardNum);
                _gangCardList[item.CardType].Add(item.CardNum);
                _gangCardList[item.CardType].Add(item.CardNum);
            }
            else
            {
                //排序
                foreach (var gang in _gangCardList[item.CardType])
                {
                    if (gang > item.CardNum)
                    {
                        _gangCardList[item.CardType].Insert(gang, item.CardNum);
                        _gangCardList[item.CardType].Insert(gang, item.CardNum);
                        _gangCardList[item.CardType].Insert(gang, item.CardNum);
                        _gangCardList[item.CardType].Insert(gang, item.CardNum);
                        break;
                    }
                }
            }
            return true;
        }
        return false;
    }
    //检测是否胡牌
    private bool checkAACard(int value1, int value2)
    {
        if (value1 == value2)
            return true;
        return false;
    }
    //检测是否三连张
    private bool checkABCCard(int value1, int value2,int value3)
    {
        if (value1 == (value2 - 1) && value2 == (value3 - 1))
            return true;
        return false;
    }
    //检测是否三重张
    private bool checkAAACard(int value1,int value2,int value3)
    {
        if(value1==value2&&value2==value3)
            return true;
        return false;
    }
    //检测是否四重张
    private bool checkAAAACard(int value1, int value2, int value3,int value4)
    {
        if (value1 == value2 && value2 == value3 && value3 == value4)
            return true;
        return false;
    }
    //检测是否三连对
    private bool checkAABBCCCard(int value1,int value2,int value3,int value4,int value5,int value6)

    {
        if (value1 == value2 && value3 == value4 && value5 == value6)
        {
            if ((value1 == value3 - 1) && (value3 == value5 - 1))
                return true;
        }
        return false;
    }
    //检测是否三连三
    private bool checkAAABBBCCCCard(int value1, int value2, int value3, int value4, int value5, int value6,int value7,int value8,int value9)
    {
        if ((value1 == value2 && value2 == value3) && (value4 == value5 && value5 == value6) && value7 == value8 && value8 == value9)
        {
            if ((value1 == value4 - 1) && (value4 == value7 - 1))
                return true;
        }
        return false;
    }
    //检测是否三连刻
    private bool checkAAAABBBBCCCCCard(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9,int value10,int value11,int value12)
    {
        if((value1==value2&&value2==value3&&value3==value4)&&(value5==value6&&value6==value7&&value7==value8)&&(value9==value10&&value10==value11&&value11==value12))
        {

            if ((value1 == value5 - 1) && (value5 == value9 - 1))
                return true;

        }
        return false;
    }
    //检测是否六连对
    private bool checkAABBCCDDEEFFCard(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12)
    {
        if (value1 == value2 && value3 == value4 && value5 == value6 && value7 == value8 && value9 == value10 && value11 == value12)
        {
            if ((value1 == -value3 - 1) && (value3 == value5 - 1) && (value5 == value7 - 1) && (value7 == value9 - 1) && (value9 == value11 - 1))
            {
                return true;

            }
        }
        return false;
    }

    //带将牌检测------------------------------------------------------------------------------
    
    //检测是否胡牌
    private bool check5Card(int value1, int value2, int value3, int value4, int value5)
    {
        //如果左边两个为将，右边三张
        if (checkAACard(value1, value2))
        {
            if (check3Card(value3, value4, value5))
                return true;
        }
        //如果中间两个为将
        if (checkAAACard(value2, value3, value4))
        {
            if (checkABCCard(value1, value4, value5))
                return true;
        }

        //如果右边两个为将
        if (checkAACard(value4, value5))
        {
            if (check3Card(value1, value2, value3))
                return true;
        }
        return false;
    }
    //检测是否胡牌
    private bool check8Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8)
    {
        //左边两个将
        if (checkAACard(value1, value2))
        {
            return check6Card(value3, value4, value5, value6, value7, value8);
        }
        //中间两个将
        if (checkAACard(value4, value5))
        {
            return check3Card(value1, value2, value3) && check3Card(value6, value7, value8);
        }


        //右边两个将
        if (checkAACard(value7, value8))
        {
            return check6Card(value1, value2, value3, value4, value5, value6);
        }

        return false;
    }
    //检测是否胡牌
    private bool check11Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11)
    {
        //左将
        if (checkAACard(value1, value2))
        {
            return check9Card(value3, value4, value5, value6, value7, value8, value9,value10,value11);
        }
        //中将
        if (checkAACard(value4, value5))
        {
            if (check3Card(value1, value2, value3) && check6Card(value6, value7, value8, value9, value10, value11))
                return true;
        }
        //中将
        if (checkAACard(value7, value8))
        {
            return check3Card(value9, value10, value11) && check6Card(value1, value2, value3, value4, value5, value6);
        }

        //右将
        if (checkAACard(value10, value11))
            return check9Card(value1, value2, value3, value4, value5, value6,value7,value8,value9);
        return false;
    }
    //检测是否胡牌
    private bool check14Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12, int value13, int value14)
    {
        //左将
        if (checkAACard(value1, value2))
        {
            if (check12Card(value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14))
                return true;
            return false;
        }
        //中将
        if (checkAACard(value4, value5))
        {
            if (check3Card(value1, value2, value3) && check9Card(value6, value7, value8, value9, value10, value11, value12, value13, value14))
                return true;
            return false;
        }
        //中将
        if (checkAACard(value7, value8))
        {
            if (check6Card(value1, value2, value4, value4, value5, value6) && check6Card(value9, value10, value11, value12, value13, value14))
                return true;
            return false;
        }
        //中将
        if (checkAACard(value10, value11))
        {
            if (check3Card(value12, value13, value14) && check9Card(value1, value2, value3, value4, value5, value6, value7, value8, value9))
                return true;
            return false;
        }
        //右将

        if (checkAACard(value13, value14))
        {
            if (check12Card(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12))
                return true;
            return false;
        }
        return false;
    }
    //不带将检测-----------------------------------------------------------------
    
    //检测是否胡牌
    private bool check3Card(int value1, int value2, int value3)
    {
        if (checkABCCard(value1, value2, value3))
            return true;
        if (checkAAACard(value1, value2, value3))
            return true;
        return false;
    }
    //检测是否胡牌
    private bool check6Card(int value1, int value2, int value3, int value4, int value5, int value6)
    {
        if (check3Card(value1, value2, value3) && check3Card(value4, value5, value6))
            return true;
        if (checkAABBCCCard(value1, value2, value3, value4, value5, value6))
            return true;
        if (checkAAAACard(value2, value3, value4, value5))
            if (checkABCCard(value1, value2, value6))
                return true;
        return false;
    }
    //检测是否胡牌
    private bool check9Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9)
    {
        if (checkABCCard(value1, value2, value3) && check6Card(value4, value5, value6, value7, value8, value9))
            return true;
        if (checkAAACard(value1, value2, value3) && check6Card(value4, value5, value6, value7, value8, value9))
            return true;
        if (checkABCCard(value7, value8, value9) && check6Card(value1, value2, value3, value4, value5, value6))
            return true;
        if (checkAAACard(value7, value8, value9) && check6Card(value1, value2, value3, value4, value5, value6))
            return true;
        return false;
    }
    //检测是否胡牌
    private bool check12Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12)
    {
        if (checkABCCard(value1, value2, value3) && check9Card(value4, value5, value6, value7, value8, value9,value10,value11,value12))
            return true;
        if (checkAAACard(value1, value2, value3) && check9Card(value4, value5, value6, value7, value8, value9, value10, value11, value12))
            return true;
        if (checkABCCard(value10, value11, value12) && check9Card(value1, value2, value3, value4, value5, value6,value7,value8,value9))
            return true;
        if (checkAAACard(value10, value11, value12) && check9Card(value1, value2, value3, value4, value5, value6, value7, value8, value9))
            return true;
        if (check6Card(value1, value2, value3, value4, value5, value6) && check6Card(value7, value8, value9, value10, value11, value12))
            return true;
        return false;
    }
    //检测是否大四喜
    private bool checkD4X_HU()
    {
        if (_gangCardList[1].Count == 16)
        {
            for (int i = 0; i < 6; i++)
            {
                if (_myCardList[i][0] == _myCardList[i][1])
                {
                    return true;
                }
            }
        }
        return false;
    }
    //检测是否大三元
    private bool checkD3Y_HU()
    {
        if (_gangCardList[0].Count == 12)
        {
            for (int i = 0; i < 6; i++)
            {
                if (_myCardList[i].Count == 2)
                {
                    if (_myCardList[i][0] == _myCardList[i][1])
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    //检测是否胡四杠  
    private bool Check4Gang_HU()
    { return false; }
    //检测是否胡十三幺  
    private bool Chekc13Y_HU()
    {
        if (_13Y)
        {
            bool []i13YSize = new bool[13];
            for (int i = 0; i < 13; i++)
            {
                i13YSize[i] = false;
            }
            foreach (var item in _myCardList[CARD_TYPE.ZFB])
            {
                if (item == 1)
                    i13YSize[0] = true;
                if (item == 2)
                    i13YSize[1] = true;
                if (item == 3)
                    i13YSize[2] = true;
            }
            //东南西北风
            foreach (var item in _myCardList[CARD_TYPE.风])
            {
                if (item == 1)
                {
                    i13YSize[3] = true;
                }
                if (item == 2)
                    i13YSize[4] = true;
                if (item == 3)
                    i13YSize[5] = true;
                if (item == 4)
                    i13YSize[6] = true;
            }
            //一九万
            foreach (var item in _myCardList[CARD_TYPE.万])
            {
                if (item == 1)
                    i13YSize[7] = true;
                if (item == 9)
                    i13YSize[8] = true; 
            }

            //一九条
            foreach (var item in _myCardList[CARD_TYPE.条])
            {
                if (item == 1)
                    i13YSize[9] = true;
                if (item == 9)
                    i13YSize[10] = true;
            }

            //一九饼
            foreach (var item in _myCardList[CARD_TYPE.饼])
            {
                if (item == 1)
                    i13YSize[11] = true;
                if (item == 9)
                    i13YSize[12] = true;
            }

            int icount = 0;
            for (int i = 0; i < 13; i++)
            {
                if (i13YSize[i] == true)
                {
                    icount++;
                }
            }
            if (icount == 13)
                return true;
        }
        return false;
    }
    //检测是否胡小四喜  
    private bool CheckX4X_HU()
    {
        if (_gangCardList[1].Count == 12)
        {
            int iJingPos = -1;
            for (int i = 0; i < 6; i++)
            {
                if (_myCardList[i].Count == 5)
                {
                    if (check5Card(_myCardList[i][0], _myCardList[i][1], _myCardList[i][2], _myCardList[i][3], _myCardList[i][4]))
                    {
                        return true;
                    }
                }
                if (_myCardList[i].Count == 2)
                {
                    if (checkAACard(_myCardList[i][0], _myCardList[i][1]))
                    {
                        iJingPos = i;
                        break;
                    }
                }
            }

            if (iJingPos > 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i != iJingPos)
                    {
                        if (_myCardList[i].Count == 3)
                        {
                            if (check3Card(_myCardList[i][0], _myCardList[i][1], _myCardList[i][2]))
                                return true;
                        }
                    }
                }
            }


        }
        return false;
    }
    //检测是否胡小三元  
    private bool CheckX3Y_HU()
    {
        if (_gangCardList[0].Count == 8)
        {
            if (_myCardList[CARD_TYPE.ZFB].Count == 5)
            {
                if (check5Card(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2], _myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (_myCardList[CARD_TYPE.ZFB].Count == 2)
            {
                if (checkAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1]) == false)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return CheckHU();
        }
        return false;
    }
    //检测是否七对  
    private bool Check7D_HU()
    {
        int iDoubleNum = 0;
        for (int i = 0; i < 5; i++)
        {
            int iSize = _myCardList[i].Count;
            if (iSize % 2 == 1 || iSize == 0)
                return false;
            for (int j = 0; j < iSize-1; j++)
            {
                if (_myCardList[i][j] == _myCardList[i][j + 1])
                {
                    iDoubleNum++;
                    j++;
                }
            }
        }
        if (iDoubleNum == 7)
            return true;
        return false;
    }
    //检测胡  
    private bool CheckHU()
    {
        bool t_OK = false;
        int iJiangNum = 0;
        int iSize = _myCardList[CARD_TYPE.ZFB].Count;
        if (iSize > 0)
        {
            if (iSize == 2)
            {
                if (!checkAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1]))
                {
                    return false;
                }
                else
                {
                    iJiangNum++;
                }
            }
            else if (iSize == 3)
            {
                if (!checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]))
                {
                    return false;
                }
            }
            else if (iSize == 5)
            {
                if (checkAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][2], _myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4]))
                {
                    iJiangNum++;
                }
                else if (checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]) && checkAACard(_myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4]))
                {
                    iJiangNum++;
                }
                else
                {
                    return false;
                }
            }
            else if (iSize == 8)
            {
                if (checkAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][2], _myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][5], _myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7]))
                {
                    iJiangNum++;
                }
                else if (checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4], _myCardList[CARD_TYPE.ZFB][5]) && checkAACard(_myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7]))
                {
                    iJiangNum++;
                }
                else if (checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4], _myCardList[CARD_TYPE.ZFB][5]) && checkAACard(_myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7]))
                {
                    iJiangNum++;
                }
                else
                {
                    return false;
                }
            }
            else if (iSize == 11)
            {
                if (checkAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][2], _myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][5], _myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][8], _myCardList[CARD_TYPE.ZFB][9], _myCardList[CARD_TYPE.ZFB][10]))
                {
                    iJiangNum++;
                }
                else if (checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]) && checkAACard(_myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][5], _myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][8], _myCardList[CARD_TYPE.ZFB][9], _myCardList[CARD_TYPE.ZFB][10]))
                {
                    iJiangNum++;
                }
                else if (checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4], _myCardList[CARD_TYPE.ZFB][5]) && checkAACard(_myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][8], _myCardList[CARD_TYPE.ZFB][9], _myCardList[CARD_TYPE.ZFB][10]))
                {
                    iJiangNum++;
                }
                else if (checkAAACard(_myCardList[CARD_TYPE.ZFB][0], _myCardList[CARD_TYPE.ZFB][1], _myCardList[CARD_TYPE.ZFB][2]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][3], _myCardList[CARD_TYPE.ZFB][4], _myCardList[CARD_TYPE.ZFB][5]) && checkAAACard(_myCardList[CARD_TYPE.ZFB][6], _myCardList[CARD_TYPE.ZFB][7], _myCardList[CARD_TYPE.ZFB][8]) && checkAACard(_myCardList[CARD_TYPE.ZFB][9], _myCardList[CARD_TYPE.ZFB][10]))
                {
                    iJiangNum++;
                }
                else
                {
                    return false;
                }
            }
        }
            //东西南北
            iSize = _myCardList[CARD_TYPE.风].Count;
            if (iSize > 0)
            {
                if (iSize == 2)
                {
                    if (!checkAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1]))
                        return false;
                    else
                        iJiangNum++;
                }
                else if (iSize == 3)
                {
                    if (!checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]))
                    {
                        return false;
                    }
                }
                else if (iSize == 5)
                {
                    if (checkAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1]) && checkAAACard(_myCardList[CARD_TYPE.风][2], _myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4]))
                    {
                        iJiangNum++;
                    }
                    else if (checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]) && checkAACard(_myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4]))
                    {
                        iJiangNum++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (iSize == 8)
                {
                    if (checkAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1]) && checkAAACard(_myCardList[CARD_TYPE.风][2], _myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4]) && checkAAACard(_myCardList[CARD_TYPE.风][5], _myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7]))
                    {
                        iJiangNum++;
                    }
                    else if (checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]) && checkAACard(_myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4]) && checkAAACard(_myCardList[CARD_TYPE.风][5], _myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7]))
                    {
                        iJiangNum++;
                    }
                    else if (checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]) && checkAAACard(_myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4], _myCardList[CARD_TYPE.风][5]) && checkAACard(_myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7]))
                    {
                        iJiangNum++;
                    }
                    else
                        return false;
                }
                else if (iSize == 11)
                {
                    if (checkAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1]) && checkAAACard(_myCardList[CARD_TYPE.风][2], _myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4]) && checkAAACard(_myCardList[CARD_TYPE.风][5], _myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7]) && checkAAACard(_myCardList[CARD_TYPE.风][8], _myCardList[CARD_TYPE.风][9], _myCardList[CARD_TYPE.风][10]))
                    {
                        iJiangNum++;
                    }
                    else if (checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]) && checkAACard(_myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4]) && checkAAACard(_myCardList[CARD_TYPE.风][5], _myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7]) && checkAAACard(_myCardList[CARD_TYPE.风][8], _myCardList[CARD_TYPE.风][9], _myCardList[CARD_TYPE.风][10]))
                    {
                        iJiangNum++;
                    }
                    else if (checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]) && checkAAACard(_myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4], _myCardList[CARD_TYPE.风][5]) && checkAACard(_myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7]) && checkAAACard(_myCardList[CARD_TYPE.风][8], _myCardList[CARD_TYPE.风][9], _myCardList[CARD_TYPE.风][10]))
                    {
                        iJiangNum++;
                    }
                    else if (checkAAACard(_myCardList[CARD_TYPE.风][0], _myCardList[CARD_TYPE.风][1], _myCardList[CARD_TYPE.风][2]) && checkAAACard(_myCardList[CARD_TYPE.风][3], _myCardList[CARD_TYPE.风][4], _myCardList[CARD_TYPE.风][5]) && checkAAACard(_myCardList[CARD_TYPE.风][6], _myCardList[CARD_TYPE.风][7], _myCardList[CARD_TYPE.风][8]) && checkAACard(_myCardList[CARD_TYPE.风][9], _myCardList[CARD_TYPE.风][10]))
                    {
                        iJiangNum++;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            //万
            iSize = _myCardList[CARD_TYPE.万].Count;
            if (iSize > 0)
            {
                if (iSize == 2)
                {
                    if (!checkAACard(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 3)
                {
                    if (!checkAAACard(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2]))
                    {
                        if (!checkABCCard(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2]))
                        {
                            return false;
                        }
                    }
                }
                else if (iSize == 5)
                {
                    if (!check5Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 6)
                {
                    if (!check6Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4], _myCardList[CARD_TYPE.万][5]))
                    {
                        return false;
                    }
                }
                else if (iSize == 8)
                {
                    if (!check8Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4], _myCardList[CARD_TYPE.万][5], _myCardList[CARD_TYPE.万][6], _myCardList[CARD_TYPE.万][7]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 9)
                {
                    if (!check9Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4], _myCardList[CARD_TYPE.万][5], _myCardList[CARD_TYPE.万][6], _myCardList[CARD_TYPE.万][7], _myCardList[CARD_TYPE.万][8]))
                    {
                        return false;
                    }
                }
                else if (iSize == 11)
                {
                    if (!check11Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4], _myCardList[CARD_TYPE.万][5], _myCardList[CARD_TYPE.万][6], _myCardList[CARD_TYPE.万][7], _myCardList[CARD_TYPE.万][8], _myCardList[CARD_TYPE.万][9], _myCardList[CARD_TYPE.万][10]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 12)
                {
                    if (!check12Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4], _myCardList[CARD_TYPE.万][5], _myCardList[CARD_TYPE.万][6], _myCardList[CARD_TYPE.万][7], _myCardList[CARD_TYPE.万][8], _myCardList[CARD_TYPE.万][9], _myCardList[CARD_TYPE.万][10], _myCardList[CARD_TYPE.万][11]))
                    {
                        return false;
                    }
                }
                else if (iSize == 14)
                {
                    if (!check14Card(_myCardList[CARD_TYPE.万][0], _myCardList[CARD_TYPE.万][1], _myCardList[CARD_TYPE.万][2], _myCardList[CARD_TYPE.万][3], _myCardList[CARD_TYPE.万][4], _myCardList[CARD_TYPE.万][5], _myCardList[CARD_TYPE.万][6], _myCardList[CARD_TYPE.万][7], _myCardList[CARD_TYPE.万][8], _myCardList[CARD_TYPE.万][9], _myCardList[CARD_TYPE.万][10], _myCardList[CARD_TYPE.万][11], _myCardList[CARD_TYPE.万][12], _myCardList[CARD_TYPE.万][13]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else
                {
                    return false;
                }
            }

            //条
            iSize = _myCardList[CARD_TYPE.条].Count;
            if (iSize > 0)
            {
                if (iSize == 2)
                {
                    if (!checkAACard(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 3)
                {
                    if (!checkAAACard(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2]))
                    {
                        if (!checkABCCard(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2]))
                        {
                            return false;
                        }
                    }
                }
                else if (iSize == 5)
                {
                    if (!check5Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 6)
                {
                    if (!check6Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4], _myCardList[CARD_TYPE.条][5]))
                    {
                        return false;
                    }
                }
                else if (iSize == 8)
                {
                    if (!check8Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4], _myCardList[CARD_TYPE.条][5], _myCardList[CARD_TYPE.条][6], _myCardList[CARD_TYPE.条][7]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 9)
                {
                    if (!check9Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4], _myCardList[CARD_TYPE.条][5], _myCardList[CARD_TYPE.条][6], _myCardList[CARD_TYPE.条][7], _myCardList[CARD_TYPE.条][8]))
                    {
                        return false;
                    }
                }
                else if (iSize == 11)
                {
                    if (!check11Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4], _myCardList[CARD_TYPE.条][5], _myCardList[CARD_TYPE.条][6], _myCardList[CARD_TYPE.条][7], _myCardList[CARD_TYPE.条][8], _myCardList[CARD_TYPE.条][9], _myCardList[CARD_TYPE.条][10]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 12)
                {
                    if (!check12Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4], _myCardList[CARD_TYPE.条][5], _myCardList[CARD_TYPE.条][6], _myCardList[CARD_TYPE.条][7], _myCardList[CARD_TYPE.条][8], _myCardList[CARD_TYPE.条][9], _myCardList[CARD_TYPE.条][10], _myCardList[CARD_TYPE.条][11]))
                    {
                        return false;
                    }
                }
                else if (iSize == 14)
                {
                    if (!check14Card(_myCardList[CARD_TYPE.条][0], _myCardList[CARD_TYPE.条][1], _myCardList[CARD_TYPE.条][2], _myCardList[CARD_TYPE.条][3], _myCardList[CARD_TYPE.条][4], _myCardList[CARD_TYPE.条][5], _myCardList[CARD_TYPE.条][6], _myCardList[CARD_TYPE.条][7], _myCardList[CARD_TYPE.条][8], _myCardList[CARD_TYPE.条][9], _myCardList[CARD_TYPE.条][10], _myCardList[CARD_TYPE.条][11], _myCardList[CARD_TYPE.条][12], _myCardList[CARD_TYPE.条][13]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else
                {
                    return false;
                }

            }

            //饼  
            iSize = _myCardList[CARD_TYPE.饼].Count;
            if (iSize > 0)
            {
                if (iSize == 2)
                {
                    if (!checkAACard(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 3)
                {
                    if (!checkAAACard(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2]))
                    {
                        if (!checkABCCard(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2]))
                        {
                            return false;
                        }
                    }
                }
                else if (iSize == 5)
                {
                    if (!check5Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 6)
                {
                    if (!check6Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4], _myCardList[CARD_TYPE.饼][5]))
                    {
                        return false;
                    }
                }
                else if (iSize == 8)
                {
                    if (!check8Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4], _myCardList[CARD_TYPE.饼][5], _myCardList[CARD_TYPE.饼][6], _myCardList[CARD_TYPE.饼][7]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 9)
                {
                    if (!check9Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4], _myCardList[CARD_TYPE.饼][5], _myCardList[CARD_TYPE.饼][6], _myCardList[CARD_TYPE.饼][7], _myCardList[CARD_TYPE.饼][8]))
                    {
                        return false;
                    }
                }
                else if (iSize == 11)
                {
                    if (!check11Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4], _myCardList[CARD_TYPE.饼][5], _myCardList[CARD_TYPE.饼][6], _myCardList[CARD_TYPE.饼][7], _myCardList[CARD_TYPE.饼][8], _myCardList[CARD_TYPE.饼][9], _myCardList[CARD_TYPE.饼][10]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else if (iSize == 12)
                {
                    if (!check12Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4], _myCardList[CARD_TYPE.饼][5], _myCardList[CARD_TYPE.饼][6], _myCardList[CARD_TYPE.饼][7], _myCardList[CARD_TYPE.饼][8], _myCardList[CARD_TYPE.饼][9], _myCardList[CARD_TYPE.饼][10], _myCardList[CARD_TYPE.饼][11]))
                    {
                        return false;
                    }
                }
                else if (iSize == 14)
                {
                    if (!check14Card(_myCardList[CARD_TYPE.饼][0], _myCardList[CARD_TYPE.饼][1], _myCardList[CARD_TYPE.饼][2], _myCardList[CARD_TYPE.饼][3], _myCardList[CARD_TYPE.饼][4], _myCardList[CARD_TYPE.饼][5], _myCardList[CARD_TYPE.饼][6], _myCardList[CARD_TYPE.饼][7], _myCardList[CARD_TYPE.饼][8], _myCardList[CARD_TYPE.饼][9], _myCardList[CARD_TYPE.饼][10], _myCardList[CARD_TYPE.饼][11], _myCardList[CARD_TYPE.饼][12], _myCardList[CARD_TYPE.饼][13]))
                    {
                        return false;
                    }
                    else
                    {
                        iJiangNum++;
                    }
                }
                else
                {
                    return false;
                }
            } 
        if (iJiangNum == 1) return true;
        return false;
    }


}

