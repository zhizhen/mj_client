using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HallPanel : BasePanel
{
    private static HallPanel instance;
    public static HallPanel Instance
    {
        get
        {
            if (instance == null)
                instance = new HallPanel();
            return instance;
        }

    }
    private HallPanel()
    {
        base_name = PanelTag.HALL_PANEL;
    }

    private Button _create;
    private Button _join;
    private GameObject _input;
    private InputField _inputNum;
    private Button _button;

    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _create = uiSprite.transform.FindChild("create").GetComponent<Button>();
        _join = uiSprite.transform.FindChild("join").GetComponent<Button>();
        _input = uiSprite.transform.FindChild("input").gameObject;
        _inputNum = _input.transform.FindChild("InputField").GetComponent<InputField>();
        _button = _input.transform.FindChild("Button").GetComponent<Button>();

        _input.SetActive(false);

        _create.onClick.AddListener(delegate
        {
            createTable();
        });

        _join.onClick.AddListener(delegate
        {
            _input.SetActive(true);
        });

        _button.onClick.AddListener(delegate
        {
            int num = 0;
            int.TryParse(_inputNum.text, out num);
            if (num == 0)
            {
                Debug.Log("请输入正确房间号");
            }
            else
            {
                joinTable(num);
                Debug.Log("num" + num);
                //RoomPanel.Instance.load();
            }

        });
        

    }

    private void createTable()
    {
        //ProtoReq.CreateTable();
        RoomPanel.Instance.load();
    }
    private void joinTable(int id)
    {
        ProtoReq.JoinTable(id);
    }
}
