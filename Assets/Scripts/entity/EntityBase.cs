using UnityEngine;
using System.Collections;
using System;

public class EntityBase{

    private GameObject _kGO;
    private bool _isLoaded;
    private bool _isReleased;
    private Transform _transform;
    private Transform _defaultTransform;
    private string _prefabId;
    private int _roleKey;
    private string _strUrl;
    private bool _isDead;

    
    public static EntityBase Creator()
    {
        return new EntityBase();
    }
    public EntityBase()
    { 
        
    }
    public void LoadRes(string prefabId, Action<GameObject> OnComplete = null, bool resetRes = false)
    {
        _prefabId = prefabId;
        _strUrl = URLConst.GetModel(_prefabId);
        ModelMgr.Instance.GetModel(_strUrl, delegate(GameObject kGo, object arg)
        {
            _kGO = kGo;
            _kGO.name = _prefabId + "|" + _roleKey;
            _transform = _kGO.transform;
            _isLoaded = true;
            if (OnComplete != null)
            {
                OnComplete(kGo);
            }
            LoadResCompleted();
        },null,ResourceManager.DEFAULT_PRIORITY,false);
    }
    public virtual void LoadResCompleted()
    {
        EntityMgr.Instance.AddTransformDic(this);
        setActive(true);
    }
    public void setActive(bool boo)
    {
        _kGO.SetActiveExt(boo);
        //创建
    }
    public void ModelRelease(bool cache = true)
    {
        ModelMgr.Instance.StopResLoad(_strUrl);
        if (_kGO != null)
        {
            _kGO.ResetReclaim();
        }
        ModelMgr.Instance.Reclaim(_strUrl, _kGO);
#if UNITY_EDITOR
        _kGO.name = _prefabId+"|已回收";
        _kGO.transform.SetAsLastSibling();
#endif
        _transform = null;
        _kGO = null; 
    }
    public void Reset()
    {
        _isReleased = false;
        _isDead = false;
    }
    public void OnUpdate(float dt)
    {
        if (_isReleased)
            return;
        //各种update
    }
    public virtual void Reclaim()
    {
        EntityMgr.Instance.Reclaim(this);
    }
    public virtual void Release(bool cache = true)
    {
        if (_isLoaded || _isDead)
        {
            return;
        }
        _isReleased = true;
        _isDead = true;
        _isLoaded = false;
        //各种销毁
    }
    public int RoleKey
    {
        get { return _roleKey; }
        set { _roleKey = value; }
    }

    public string PrefabId
    {
        get { return _prefabId; }
        set { _prefabId = value; }
    }
    public bool IsReleased
    {
        get { return _isReleased; }
        set { _isReleased = value; }
    }

    public bool IsLoaded
    {
        get { return _isLoaded; }
        set { _isLoaded = value; }
    }
    public GameObject KGO
    {
        get { return _kGO; }
        set { _kGO = value; }
    }

    public Transform transform
    {
        get
        {
            if (_transform == null)
            {
                if (_defaultTransform == null)
                {
                    _defaultTransform = DefaultModelPools.GetGameObject(string.Empty).transform;
                }
                return _defaultTransform;
            }
            return _transform;
        }
        set
        {
            _transform = value;
            _defaultTransform = value;
        }
    }
    public Vector3 position
    {
        get
        {
            return transform.position;
        }
        set
        {
           transform.position = value;
        }
    }
    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }
}
