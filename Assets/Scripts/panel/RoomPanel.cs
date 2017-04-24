using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomPanel : BasePanel {

    private static RoomPanel instance;
    public static RoomPanel Instance
    {
        get
        {
            if (instance == null)
                instance = new RoomPanel();
            return instance;
        }

    }
    private RoomPanel()
    {
        base_name = PanelTag.ROOM_PANEL;
    }

    private Button _zhunbei;
    public override void InitPanel(Transform uiSprite)
    {
        base.InitPanel(uiSprite);
        _zhunbei = uiSprite.FindChild("Button").GetComponent<Button>();

        _zhunbei.onClick.AddListener(delegate
        {
            ProtoReq.Ready();
        });
    }
}
