using UnityEngine;
using UnityEngine.UIElements;

public class IngameUI : MonoBehaviour
{
    public VisualElement ui;

    private Label _timerText;
    private VisualElement _messageBoxElement;
    private Label _messageBoxText;
    
    private const string _level_0_msg_box = "Message Box Text 0";
    private const string _level_1_msg_box = "Message Box Text 1";
    private const string _level_2_msg_box = "Message Box Text 2";
    private const string _level_3_msg_box = "Message Box Text 3";

    private float _levelTimer = 60f;

    private void Update()
    {
        _levelTimer -= Time.deltaTime;
        if (_levelTimer < 0f) LevelFailed();
        CountdownUpdate();

    }

    private void LevelFailed()
    {
        // LOAD ENTRY SCENE HERE
    }

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _timerText = ui.Q<Label>("countdown");
        _messageBoxText = ui.Q<Label>("message-box-text");
        _messageBoxElement = ui.Q<VisualElement>("message-box");
        HideMessageBox();
    }

    public void ShowMessageBox(PlayerLevelInfo.Level level)
    {
        switch (level)
        {
            case PlayerLevelInfo.Level.Level_0:
                _messageBoxText.text = _level_0_msg_box;
                _messageBoxElement.visible = true;
                _messageBoxText.visible = true;
                break;
            case PlayerLevelInfo.Level.Level_1:
                _messageBoxText.text = _level_1_msg_box;
                _messageBoxElement.visible = true;
                _messageBoxText.visible = true;
                break;
            case PlayerLevelInfo.Level.Level_2:
                _messageBoxText.text = _level_2_msg_box;
                _messageBoxElement.visible = true;
                _messageBoxText.visible = true;
                break;
            case PlayerLevelInfo.Level.Level_3:
                _messageBoxText.text = _level_3_msg_box;
                _messageBoxElement.visible = true;
                _messageBoxText.visible = true;
                break;
        }
    }

    public void HideMessageBox()
    {
        _messageBoxElement.visible = false;
        _messageBoxText.visible = false;
    }

    private void CountdownUpdate()
    {
        _timerText.text = _levelTimer.ToString("F0");
    }
}
