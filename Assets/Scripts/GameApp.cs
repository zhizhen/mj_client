using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class GameApp : MonoBehaviour {

    private static GameObject _gameObject;
    private const int aspet = 0;
    private float otherStep;
    private int step, resStep, resTotal = 4;
    private readonly int otherTotal = 2 + aspet;
    public readonly Action[] frameActions = new Action[]{
        InitSound,InitSimpleLoader,InitPlugin
    };

    private bool isInit = false;
    private bool showProgress = true;
    private bool isCompletedLoad;
    void Awake()
    {
        _gameObject = gameObject;
        addSomeCom();

    }
    private void addSomeCom()
    {
        gameObject.AddComponent<GlobleTimer>();
        gameObject.AddComponent<ResourceManager>();
    }

    public static void InitSound()
    {
        GameObject gameObject = GameObject.Find("soundManager");
        if (gameObject == null)
        {
            gameObject = new GameObject("soundManager");
            gameObject.AddComponent<AudioListener>();
            gameObject.AddComponent<SoundMgr>();
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    public static void InitUIRoot()
    {
        ResourceManager.Instance.DownLoadBundle(URLConst.UI_ROOT, delegate(object obj)
        {
            UIRootBack(obj);
        }, ResourceManager.UI_PRIORITY);
        GameObject eventSystem = GameObject.Find("EventSystem");
        if (eventSystem == null)
        {
            eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
            eventSystem.AddComponent<TouchInputModule>();
        }
        GameObject.DontDestroyOnLoad(eventSystem);
    }
    private static void UIRootBack(object obj)
    {
        GameObject UIRootCanvas = ResourceManager.GetGameObject(URLConst.UI_ROOT, false);
        UIRootCanvas.name = "UIRoot";
        GameObject.DontDestroyOnLoad(UIRootCanvas);
        GameObject UICanvas = UIRootCanvas.transform.FindChild("UICanvas").gameObject;
        TestPanel.Instance.load();
    }

    private static void InitSimpleLoader()
    {
        if (_gameObject.GetComponent<SimpleLoader>() == null)
        {
            _gameObject.AddComponent<SimpleLoader>();
            GameObject.Instantiate(Resources.Load<UnityEngine.Object>("UILoading"));
        }
    }

    public static void InitPlugin()
    {
        _gameObject.AddComponent<PluginTool>();
        _gameObject.AddComponent<PluginIOSTool>();
    }
	// Use this for initialization
	void Start () {
        Debug.Log("游戏开始");
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.Instantiate(Resources.Load<UnityEngine.Object>("UILoading"));
        OnLoadUILoading();
        ProtoRes.GetInstance();
        
	}

    void Update()
    {
        if (isInit == false)
            return;
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (showProgress)
        {
            OnProgress();
            if (resStep >= resTotal)
            {
                if (isCompletedLoad)
                {
                    OnCompleteLoaded();
                    return;
                }
                if (step < frameActions.Length)
                {
                    frameActions[step]();
                    step++;
                }
            }
        }
    }

    private void OnProgress()
    {
        var curStep = step + resStep + otherStep;
        var totalStep = resTotal + frameActions.Length + otherTotal;
        UILoading.percent = curStep * 1.0f / totalStep;
        if (curStep >= totalStep)
        {
            isCompletedLoad = true;
        }
    }

    private void OnLoadUILoading()
    {
        UILoading.subTitle = "正在加载,请耐心等待";
        UILoading.ShowLoading();
        isInit = true;
        LoadNeedRes();
    }

    private void LoadNeedRes()
    {
        ResourceManager.Instance.bundleVersionLoaded = () =>
          {
              otherStep++;
              ResourceManager.Instance.DownLoadBundles(URLConst.listInitGameRes.ToArray(),OnNeedResLoaded, ResourceManager.DEFAULT_PRIORITY, OnDownLoadCallBack);
          };

    }
    private void OnNeedResLoaded(object obj)
    {
        otherStep++;
        //StartGame();
    }
    private void OnDownLoadCallBack(Resource res, int listCount, int index)
    {
#if _DEBUG
        resTotal = listCount - 1;
#else
        resTotal = listCount+index;
#endif
        resStep = index;
    }

    private void OnCompleteLoaded()
    {
        showProgress = false;
        UILoading.CloseLoading();
        InitUIRoot();
    }
}
