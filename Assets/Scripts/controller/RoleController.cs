using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleController :Singleton<RoleController> {

    private List<Player> _playerList;


    public RoleController()
    {
        _playerList = new List<Player>();

    }
     
}
