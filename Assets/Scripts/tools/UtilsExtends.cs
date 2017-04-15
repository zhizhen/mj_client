using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class UtilsExtends {

    public static void Add<T1, T2, T3>(this Dictionary<T1, Dictionary<T2, T3>> dic, T1 t1, T2 t2, T3 t3)
    {
        if (!dic.ContainsKey(t1))
        {
            dic[t1] = new Dictionary<T2, T3>();
        }
        dic[t1].Add(t2, t3);
    }
    public static void Add<T1, T2>(this Dictionary<T1, List<T2>> dic, T1 t1, T2 t2)
    {
        if (!dic.ContainsKey(t1))
        {
            dic[t1] = new List<T2>();
        }
        dic[t1].Add(t2);
    }
    public static void Remove<T1, T2>(this Dictionary<T1, List<T2>> dic, T1 t1, T2 t2)
    {
        if (!dic.ContainsKey(t1))
        {
            return;
        }
        if (dic[t1].Contains(t2))
        {
            dic[t1].Remove(t2);
        }
    }

    public static void ResetReclaim(this GameObject kGo)
    {
        if (kGo.transform.parent != null)
        {
            kGo.transform.parent = null;
            Object.DontDestroyOnLoad(kGo);
        }
        kGo.ResetAll();
        kGo.SetActiveZExt(false);
    }
    public static void ResetAll(this GameObject kGO)
    {
        kGO.ResetLocalPosition();
        kGO.ResetLocalRotation();
        kGO.ResetLocalScale();
    }
    public static void ResetLocalPosition(this GameObject kGO)
    {
        kGO.transform.localPosition = Vector3.zero;
    }

    public static void ResetLocalRotation(this GameObject kGO)
    {
        kGO.transform.localRotation = Quaternion.identity;
    }

    public static void ResetLocalScale(this GameObject kGO)
    {
        kGO.transform.localScale = Vector3.one;
    }

    public static void SetActiveExt(this GameObject kGO, bool active = false)
    {
        if (kGO != null && kGO.activeSelf != active)
        {
            kGO.SetActive(active);
        }
    }
    public static void SetActiveZExt(this GameObject kGO, bool active = false)
    {
        if (kGO == null)
        {
            return;
        }
        if (active)
        {
            kGO.SetActiveExt(active);
        }
        Vector3 localPosition = kGO.transform.localPosition;
        if (!active)
        {
            localPosition.z = -10000;
        }
        else
        {
            localPosition.z = 0;
        }
        if (!localPosition.Equals(kGO.transform.localPosition))
        {
            kGO.transform.localPosition = localPosition;
        }
    }

    public static void SetActiveSelf(this GameObject kGO, bool active = false)
    {
        if (kGO != null && kGO.activeSelf != active)
        {
            if (!active)
            {
                kGO.transform.position += 10000 * Vector3.one;
            }
            else
            {
                kGO.transform.position -= 10000 * Vector3.one;
            }
        }
    }
}
