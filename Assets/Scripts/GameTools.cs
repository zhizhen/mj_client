using UnityEngine;
using System.Collections;

public class GameTools {

    public static int getCardNumByName(string name)
    {
        string str = name.Substring(name.Length - 2);
        if (str.StartsWith("_"))
            str = str.Substring(1);
        return int.Parse(str);
    }

}
