using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using cn.sharesdk.unity3d;

public class GameApp : MonoBehaviour {

    private static GameObject _gameObject;
    private const int aspet = 0;
    private float otherStep;
    private int step, resStep, resTotal = 4;
    private readonly int otherTotal = 2 + aspet;
    public readonly Action[] frameActions = new Action[]{
        InitSound,InitSimpleLoader,InitPlugin,InitUIRoot
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
        GameObject rootCanvas = ResourceManager.GetGameObject(URLConst.GetUI("UIRoot"));
        Transform canvas = rootCanvas.transform.FindChild("UICanvas");
        GameObject tips = rootCanvas.transform.FindChild("TipsLayer").gameObject;
        QuickTips.InitQuickTipsLayer(tips, 100);
        rootCanvas.SetActive(true);
        rootCanvas.transform.localScale = Vector3.one;
        GameObject.DontDestroyOnLoad(rootCanvas);

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
    private static void setUIRoot()
    {
        Transform tran = GameObject.Find("UIRoot").transform;
    }
    private static void InitSimpleLoader()
    {
        if (_gameObject.GetComponent<SimpleLoader>() == null)
        {
            _gameObject.AddComponent<SimpleLoader>();
        }
    }

    public static void InitPlugin()
    {
        _gameObject.AddComponent<SDKMgr>();
#if UNITY_ANDROID
        _gameObject.AddComponent<PluginTool>();
#elif UNITY_IPHONE
        _gameObject.AddComponent<PluginIOSTool>();
#endif
    }
	// Use this for initialization
	void Start () {
        Debug.Log("游戏开始");
        GameConst.driver = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.Instantiate(Resources.Load<UnityEngine.Object>("UILoading"));
        OnLoadUILoading();
        ProtoRes.GetInstance();
        IconMgr.GetInstance();
        StartCoroutine("YbLoadMusic", "beijing-fangjian");
    }

    IEnumerator YbLoadMusic(string str)
    {
        //string path = URL.GetFileSymbol() + URL.localResPath+ "Assetbundles/" + URLConst.SOUND_PATH + str+".mp3";
        ////AudioClip audio = Resources.LoadAsync<AudioClip>()
        //WWW www = new WWW(path);
        //yield return www;
        //AudioClip a = null;
        //if ((a = www.GetAudioClip(true,true))!=null)
        //    GameConst._bigAudio.Add(str, a);
        string path = "GameAsset/Assetbundles/Musics/"+str;
        var a = Resources.LoadAsync<AudioClip>(path);
        yield return a;
        GameConst._bigAudio.Add(str, a.asset as AudioClip);
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
        TextureMgr.Instance.StartLoading();
        setUIRoot();
        //TestPanel.Instance.load();
        SoundMgr._instance.bgmPlay("beijing_dating");
        LoginPanel.Instance.load();
    }

    
}
