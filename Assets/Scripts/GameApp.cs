using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class GameApp : MonoBehaviour {

    public readonly Action[] frameActions = new Action[]{
        InitSound,InitUIRoot,
    };

    void Awake()
    {
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
	// Use this for initialization
	void Start () {
        Debug.Log("游戏开始");
        gameObject.AddComponent<PluginTool>();
        gameObject.AddComponent<PluginIOSTool>();
        GameObject.DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < frameActions.Length; i++)
            frameActions[i].Invoke();
        ProtoRes.GetInstance();
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
