using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleController :Singleton<RoleController> {

    public Dictionary<int, Player> _playerDic;

    public RoleController()
    {
        _playerDic = new Dictionary<int, Player>();

    }

    public void addPlayer(Table.Role role)
    {
        Player player = new Player(role.id, role.name, role.pos);
        if (_playerDic.ContainsKey(role.id))
        {
            _playerDic.Remove(role.id);

        }
        _playerDic.Add(role.id, player);
    }

    public Player getPlayerById(int id)
    {
        return _playerDic[id];
    }

    public int getPlayerPos(int id)
    {
        return getPlayerById(id).Pos;
    }

    public Player getPlayerByPos(int pos)
    {
        foreach (var item in _playerDic)
        {
            if (item.Value.Pos == pos)
                return item.Value;
        }
        return null;
    }
}
