using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Room;

public class RoomController : Singleton<RoomController> {

    private List<RoomInfo> _roomList;

    public RoomController()
    {
        _roomList = new List<RoomInfo>();
    }

    public void InitRoomList()
    { 
            
    }
}
