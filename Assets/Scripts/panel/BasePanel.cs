using UnityEngine;
using System.Collections;

public class BasePanel{

    public GameObject base_self;
    public string base_name = "";
    public bool _exist;
    public GameObject _root = GameObject.Find("UIRoot/UICanvas");
    public bool _isLoading;

    public void ClosePanel()
    {
        if(base_self!=null)
            base_self.SetActive(false);
        OnClose();
    }
    public void DestoryPanel()
    {
        _exist = false;
        RemoveListener();
        GameObject.Destroy(base_self);
    }

    public virtual void InitPanel(Transform uiSprite)
    {
        
    }

    public void load()
    {
        if (_isLoading)
            return;
        if (!_exist)
        {
            _isLoading = true;
            ResourceManager.Instance.DownLoadBundle(URLConst.GetUI(base_name), delegate(object obj)
            {
                OnLoadBack(obj);
            }, ResourceManager.UI_PRIORITY);
        }
        else
        {
            base_self.transform.SetAsLastSibling();
            base_self.SetActive(true);
            startUp(null);
        }
    }

    public void load(object obj)
    {
        if (_isLoading)
            return;
        if (!_exist)
        {
            _isLoading = true;
            ResourceManager.Instance.DownLoadBundle(URLConst.GetUI(base_name), delegate(object objc)
            {
                OnLoadBack(objc);
            }, ResourceManager.UI_PRIORITY);
        }
        else
        {
            base_self.transform.SetAsLastSibling();
            base_self.SetActive(true);
            startUp(obj);
        }
    }

    public virtual void OnClose()
    { 
        
    }

    public void OnLoadBack(object obj)
    {
        base_self = ResourceManager.GetGameObject(URLConst.GetUI(base_name),false);
        Transform component = base_self.GetComponent<Transform>();
        component.gameObject.SetActive(true);
        component.parent = _root.transform;
        component.name = base_name;
        
        component.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        component.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

        InitPanel(component);
        startUp(obj);
        _exist = true;
        _isLoading = false;
        AddListener();
    }

    public void ShowPanel()
    {
        if (base_self != null)
        {
            base_self.SetActive(true);
            base_self.transform.SetAsLastSibling();
        }
    }

    public virtual void startUp(object obj = null)
    {
        for (int i = 0; i < _root.transform.childCount - 1; i++)
        {
            _root.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public virtual void AddListener()
    { 
        
    }
    public virtual void RemoveListener()
    {


    }
}
