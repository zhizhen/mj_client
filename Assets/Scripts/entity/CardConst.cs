using UnityEngine;
using System.Collections;

public class CardConst {
    public static CardInfo getCardInfo(int num)
    {
        CardInfo info = new CardInfo();
        if (num >= 1 && num <= 9)
        {
            info.type = CARD_TYPE.万;
            info.value = num;
        }
        else if (num >= 10 && num <= 18)
        {
            info.type = CARD_TYPE.饼;
            info.value = num - 9;
        }
        else if (num >= 19 && num <= 27)
        {
            info.type = CARD_TYPE.条;
            info.value = num - 18;
        }
        else if (num >= 28 && num <= 31)
        {
            info.type = CARD_TYPE.风;
            info.value = num - 27;
        }
        else if (num >= 32 && num <= 35)
        {
            info.type = CARD_TYPE.ZFB;
            info.value = num - 31;
        }
        return info;
    }
}

public class CARD_TYPE
{
    public const int ZFB = 0;
    public const int 风 = 1;
    public const int 万 = 2;
    public const int 条 = 3;
    public const int 饼 = 4;
}

public class CARD_STATE
{
    public const bool CARD_GET = true;
    public const bool CARD_PUT = false;
}
public class CardInfo
{
    public int type;
    public int value;
}

