using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameConst {

    public static MonoBehaviour driver;
    public static int tableId;
    public static int timeCount = 15;

    public static int zhuangPos = 0;
    public static bool zhuang = true;

    public static int selfPos = 0;

    public static Dictionary<string, AudioClip> _bigAudio = new Dictionary<string, AudioClip>();
}
