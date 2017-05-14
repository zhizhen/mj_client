using UnityEngine;
using System.Collections;

public class Player{

    private int _id;
    private string _name;
    private int _pos;
    private bool _isReady = false;

    public Player(int id,string name,int pos)
    {
        Id = id;
        Name = name;
        Pos = pos;    
    }
    public Player()
    {

    }
    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public int Pos
    {
        get
        {
            return _pos;
        }

        set
        {
            _pos = value;
        }
    }

    public bool IsReady
    {
        get
        {
            return _isReady;
        }

        set
        {
            _isReady = value;
        }
    }
}
