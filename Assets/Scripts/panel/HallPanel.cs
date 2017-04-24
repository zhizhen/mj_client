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

    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _create = uiSprite.transform.FindChild("create").GetComponent<Button>();
        _join = uiSprite.transform.FindChild("join").GetComponent<Button>();

        _create.onClick.AddListener(delegate
        {
            createTable();
        });

        _join.onClick.AddListener(delegate
        {
            joinTable(1);
        });

    }

    private void createTable()
    {
        ProtoReq.CreateTable();
    }
    private void joinTable(int id)
    {
        ProtoReq.JoinTable(id);
    }
}
