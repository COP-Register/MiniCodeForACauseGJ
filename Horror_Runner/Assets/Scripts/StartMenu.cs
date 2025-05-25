using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    private VisualElement ui;
    private Button _startBtn;
    private Button _quitBtn;
    
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _startBtn = ui.Q<Button>("start-btn");
        _quitBtn = ui.Q<Button>("quit-btn");
        _startBtn.clicked += StartBtnOnclicked;
        _quitBtn.clicked += QuitBtnOnclicked;
    }

    private void QuitBtnOnclicked()
    {
        Application.Quit();
    }

    private void StartBtnOnclicked()
    {
        SceneManager.LoadScene("Level_0_Titel");
    }
}
