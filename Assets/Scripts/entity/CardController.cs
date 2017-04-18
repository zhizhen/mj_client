using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardController{

    private List<int>[] _myCardList;//起的类型牌
    private List<int>[] _pengCardList;//碰的类型牌
    private List<int>[] _gangCardList;//扛的类型牌

    private Card _lastCard;//最后起的牌

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
    }
    public void init()
    { }
    //起牌,加入新牌并排序
    public bool addCard(int type,int num)
    {
        int size = _myCardList[type].Count;
        bool _find = false;
        for (int i = 0; i < size; i++)
        {
            if (_myCardList[type][i] > type)
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
    { return false; }
    //输出牌
    public void printAllCard()
    { }
    //输出某张牌
    public void printCard(int type, int num)
    { }
    //检测碰
    public bool checkPeng(int type, int num)
    {
        return false;
    }
    //碰
    public bool peng(int type, int num)
    {
        return false;
    }
    //检测扛
    public bool checkGang(int type, int num)
    {
        return false;
    }
    //扛
    public bool gang(int type,int num)
    { return false; }
    //输出可碰组合
    public void printPengChose()
    { }
    //输出可扛组合
    public void printGangChose()
    { }

    //检测是否胡牌
    private bool checkAACard(int type, int num)
    { return false; }
    //检测是否三连张
    private bool checkABCCard(int type, int num)
    { return false; }
    //检测是否散重张
    private bool checkAAACard(int type,int num)
    { return false; }
    //检测是否四重张
    private bool checkAAAACard(int type,int num)
    { return false; }
    //检测是否三连对
    private bool checkAABBCCCard(int type,int num)
    { return false; }
    //检测是否三连三
    private bool checkAAABBBCCCCard(int type,int num)
    { return false; }
    //检测是否三连刻
    private bool checkAAAABBBBCCCCCard(int type, int num)
    { return false; }
    //检测是否六对
    private bool checkAABBCCDDEEFFCard(int type, int num)
    { return false; }

    //带将牌检测------------------------------------------------------------------------------
    
    //检测是否胡牌
    private bool check5Card(int value1, int value2, int value3, int value4, int value5)
    { return false; }
    //检测是否胡牌
    private bool check8Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8)
    { return false; }
    //检测是否胡牌
    private bool check11Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11)
    { return false; }
    //检测是否胡牌
    private bool check14Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12, int value13, int value14)
    { return false; }
    //不带将检测-----------------------------------------------------------------
    
    //检测是否胡牌
    private bool check3Card(int value1, int value2, int value3)
    { return false; }
    //检测是否胡牌
    private bool check6Card(int value1, int value2, int value3, int value4, int value5, int value6)
    { return false; }
    //检测是否胡牌
    private bool check9Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9)
    { return false; }
    //检测是否胡牌
    private bool check12Card(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12)
    { return false; }
    //检测是否大四喜
    private bool checkD4X_HU()
    { return false; }
    //检测是否大三元
    private bool checkD3Y_HU()
    { return false; }
    //检测是否胡绿一色  
    private bool checkL1S_HU()
    { return false; }
    //检测是否胡九莲宝灯  
    private bool Check9LBD_HU()
    { return false; }
    //检测是否胡四杠  
    private bool Check4Gang_HU()
    { return false; }
    //检测是否胡连七对  
    private bool CheckL7D_HU()
    { return false; }
    //检测是否胡十三幺  
    private bool Chekc13Y_HU()
    { return false; }
    //检测是否胡清幺九  
    private bool CheckQY9_HU()
    { return false; }
    //检测是否胡小四喜  
    private bool CheckX4X_HU()
    { return false; }
    //检测是否胡小三元  
    private bool CheckX3Y_HU()
    { return false; }
    //检测是否胡字一色  
    private bool CheckZ1S_HU()
    { return false; }
    //检测是否四暗刻  
    private bool Check4AK_HU()
    { return false; }
    //检测是否一色双龙会  
    private bool Check1S2LH_HU()
    { return false; }
    //检测是否一色四同顺  
    private bool Check1S4TS_HU()
    { return false; }
    //检测是否一色四节高？  
    private bool Check1S4JG_HU()
    { return false; }
    //检测是否一色四步高？  
    private bool Check1S4BG_HU()
    { return false; }
    //检测是否三杠  
    private bool Check3Gang_HU()
    { return false; }
    //检测是否混幺九  
    private bool CheckHY9_HU()
    { return false; }
    //检测是否七对  
    private bool Check7D_HU()
    { return false; }
    //检测是否七星不靠  
    private bool Check7XBK_HU()
    { return false; }
    //检测是否全双刻？  
    private bool CheckQSK_HU()
    { return false; }
    //清一色  
    private bool CheckQ1S_HU()
    { return false; }
    //检测是否一色三同顺  
    private bool Check1S3TS_HU()
    { return false; }
    //检测是否一色三节高  
    private bool Check1S3JG_HU()
    { return false; }
    //检测是否全大  
    private bool CheckQD_HU()
    { return false; }
    //检测是否全中  
    private bool CheckQZ_HU()
    { return false; }
    //检测是否全小  
    private bool CheckQX_HU()
    { return false; }
    //检测是否青龙  
    private bool CheckQL_HU()
    { return false; }
    //检测是否三色双龙会  
    private bool Check3S2LH_HU()
    { return false; }
    //检测是否一色三步高  
    private bool Check1S3BG_HU()
    { return false; }
    //全带五  
    private bool CheckQD5_HU()
    { return false; }
    //三同刻  
    private bool Check3TK_HU()
    { return false; }
    //三暗刻  
    private bool Check3AK_HU()
    { return false; }
    //单钓将  
    private bool CheckDDJ_HU()
    { return false; }
    //检测胡  
    private bool CheckHU()
    { return false; }
    //听牌判断  -------------------------------------------

    //检测是否听九莲宝灯  
    private bool Check9LBD_TING()
    { return false; }
    //检测是否听十三幺  
    private bool Check13Y_TING()
    { return false; }
    //检测是否听四暗刻  
    private bool Check4AK_TING()
    { return false; }
    //检测是否听牌  
    private bool CheckTING()
    { return false; }

   
}
