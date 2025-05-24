using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelInfo : MonoBehaviour
{
    private Level _currentLevel;
    
    private PlayerJump _levelZeroScript;
    private PlayerChargeJump _levelOneScript;
    private GrappleHook _levelTwoScript;
    private PlayerJumpAndDash _levelThreeScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _levelZeroScript = GetComponent<PlayerJump>();
        _levelOneScript = GetComponent<PlayerChargeJump>();
        _levelTwoScript = GetComponent<GrappleHook>();
        _levelThreeScript = GetComponent<PlayerJumpAndDash>();
        SetLevelInitial();
        
    }
    
    public void IncreaseLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;

        switch (levelName)
        {
            case "Level_0":
                _currentLevel = Level.Level_1;
                break;
            case "Level_1":
                _currentLevel = Level.Level_2;
                break;
            case "Level_2":
                _currentLevel = Level.Level_3;
                break;
            case "Level_3":
                _currentLevel = Level.Level_3;
                break;
            default:
                break;
        }

        UpdateLevel();
    }

    private void SetLevelInitial()
    {
        string levelName = SceneManager.GetActiveScene().name;

        switch (levelName)
        {
            case "Level_0":
                _currentLevel = Level.Level_0;
                break;
            case "Level_1":
                _currentLevel = Level.Level_1;
                break;
            case "Level_2":
                _currentLevel = Level.Level_2;
                break;
            case "Level_3":
                _currentLevel = Level.Level_3;
                break;
            default:
                break;
        }

        UpdateLevel();
    }

    private void UpdateLevel()
    {
        switch (_currentLevel)
        {
            case Level.Level_0:
                DisableAllScripts();
                _levelZeroScript.enabled = true;
                break;
            case Level.Level_1:
                DisableAllScripts();
                _levelOneScript.enabled = true;
                break;
            case Level.Level_2:
                DisableAllScripts();
                _levelTwoScript.enabled = true;
                break;
            case Level.Level_3:
                DisableAllScripts();
                _levelThreeScript.enabled = true;
                break;
            
        }
    }

    private void DisableAllScripts()
    {
        _levelZeroScript.enabled = false;
        _levelOneScript.enabled = false;
        _levelTwoScript.enabled = false;
        _levelThreeScript.enabled = false;
    }

    public enum Level
    {
        Level_0 = 0,
        Level_1 = 1,
        Level_2 = 2,
        Level_3 = 3
    }
}
