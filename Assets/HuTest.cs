using UnityEngine;
using System.Collections;

public class HuTest : MonoBehaviour {



    private int[] cards = new int[34];
    string str = "";
	// Use this for initialization
	void Start () {

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = 0;
        }

        CardController.Instance.addCard(0, 2);
        CardController.Instance.addCard(0, 2);
        CardController.Instance.addCard(0, 2);

        CardController.Instance.addCard(0, 5);
        CardController.Instance.addCard(0, 5);
        CardController.Instance.addCard(0, 5);

        CardController.Instance.addCard(0, 6);
        CardController.Instance.addCard(0, 6);
        CardController.Instance.addCard(0, 6);

        CardController.Instance.addCard(0, 9);
        CardController.Instance.addCard(0, 9);

        Debug.Log(CardController.Instance.checkCard(true));


        UIEventHandlerBase.AddListener(gameObject, UIEventType.ON_POINTER_CLICK, delegate
        {
            Debug.Log("单击");
        });
        UIEventHandlerBase.AddListener(gameObject, UIEventType.ON_POINTER_DOUBLE_CLICK, delegate
        {
            Debug.Log("双击");
        });


    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnGUI()
    {
        GUILayout.BeginHorizontal();

        for (int i = 0; i < 9; i++)
        {
            GUILayout.Label((i + 1) + "万");
            cards[i] =int.Parse(GUILayout.TextField(cards[i].ToString(), GUILayout.Width(30)));
        }
        
  
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        for (int i = 9; i < 18; i++)
        {
            GUILayout.Label((i - 8) + "条");
            cards[i] = int.Parse(GUILayout.TextField(cards[i].ToString(), GUILayout.Width(30)));
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        for (int i = 18; i < 27; i++)
        {
            GUILayout.Label((i - 17) + "饼");
            cards[i] = int.Parse(GUILayout.TextField(cards[i].ToString(), GUILayout.Width(30)));
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("东");
        cards[27] = int.Parse(GUILayout.TextField(cards[27].ToString(), GUILayout.Width(30)));
        GUILayout.Label("南");
        cards[28] = int.Parse(GUILayout.TextField(cards[28].ToString(), GUILayout.Width(30)));
        GUILayout.Label("西");
        cards[29] = int.Parse(GUILayout.TextField(cards[29].ToString(), GUILayout.Width(30)));
        GUILayout.Label("北");
        cards[30] = int.Parse(GUILayout.TextField(cards[30].ToString(), GUILayout.Width(30)));

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("中");
        cards[31] = int.Parse(GUILayout.TextField(cards[31].ToString(), GUILayout.Width(30)));
        GUILayout.Label("發");
        cards[32] = int.Parse(GUILayout.TextField(cards[32].ToString(), GUILayout.Width(30)));
        GUILayout.Label("白");
        cards[33] = int.Parse(GUILayout.TextField(cards[33].ToString(), GUILayout.Width(30)));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("测试",GUILayout.Width(50),GUILayout.Height(20)))
        {
            CardController.Instance.cleanUp();
            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = 0; j < cards[i]; j++)
                {
                    CardController.Instance.addCard(CardConst.getCardInfo(i + 1).type, CardConst.getCardInfo(i + 1).value);
                }
            }
            bool bo = CardController.Instance.checkCard(true);
            if (bo)
                str = "能胡";
            else
                str = "不能胡";

        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("<color='#ff0000'>"+str+"</color>");
        GUILayout.EndHorizontal();
    }
}
