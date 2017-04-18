using UnityEngine;
using System.Collections;
using System;
public class Card: IComparable<Card>
{
    private int _cardType;
    private int _cardNum;
    private bool _isOut;
    public Card()
    {
            
    }
    public Card(int type, int num)
    {
        _cardType = type;
        _cardNum = num;
    }
    public int CompareTo(Card card)
    {
        int result;
        if (_cardType == card.CardType && _cardNum == card.CardNum)
        {
            result = 0;
        }
        else
        {
            if (_cardType > card.CardType)
            {
                result = 1;
            }
            else if (_cardType == card._cardType && _cardNum > card._cardNum)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
        }
        return result;
    }
    public int CardType
    {
        get
        {
            return _cardType;
        }

        set
        {
            _cardType = value;
        }
    }

    public int CardNum
    {
        get
        {
            return _cardNum;
        }

        set
        {
            _cardNum = value;
        }
    }

    public bool IsOut
    {
        get
        {
            return _isOut;
        }

        set
        {
            _isOut = value;
        }
    }
}
