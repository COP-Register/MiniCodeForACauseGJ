using UnityEngine;
using UnityEngine.UIElements;

public class IngameUI : MonoBehaviour
{
    public VisualElement ui;

    private Label _timerText;
    private VisualElement _timerElement;
    private VisualElement _messageBoxElement;
    private Label _messageBoxText;
    
    private const string _level_0_msg_box = "You've overcame your fear.\nCharged Jump unlocked.";
    private const string _level_1_msg_box = "You've overcame your fear. \nGrapple Hook unlocked.";
    private const string _level_2_msg_box = "You've overcame your fear. \nFalling Dash unlocked.";
    private const string _level_3_msg_box = "Message Box Text 3";

    private float _levelTimer = 60f;
    private bool _countdownActive = true;
    private bool _playedSound;
    
    [SerializeField] private AudioClip deathSound;

    private void Update()
    {
        if(_countdownActive) _levelTimer -= Time.deltaTime;
        if (_levelTimer < 0f) LevelFailed();
        if (_levelTimer < 3f && !_playedSound)
        {
            SoundManager.Instance.PlaySound(deathSound, transform, 100);
            _playedSound = true;
        }
        CountdownUpdate();
    }

    public void HideMessageBox()
    {
        _messageBoxElement.visible = false;
        _messageBoxText.visible = false;
    }

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _timerText = ui.Q<Label>("countdown");
        _messageBoxText = ui.Q<Label>("message-box-text");
        
        _timerElement = ui.Q<VisualElement>("level-timer-panel");
        _messageBoxElement = ui.Q<VisualElement>("message-box");
        HideMessageBox();
    }

    public void StopTimer() => DisableTimer();

    private void DisableTimer()
    {
        _countdownActive = false;
        _timerElement.visible = false;
        _timerText.text = "";
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
    
    private void CountdownUpdate()
    {
        if(_countdownActive) _timerText.text = _levelTimer.ToString("F0");
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void LevelFailed()
    {
        var sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
        sceneSwitcher.ReloadCurrentScene();
    }

}
