using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private const string MainMenuSceneName = "MainMenuScene";
    private const string GameSceneName = "gameScene";

    public bool IsGamePlaying { get; private set; }

    public GameObject mainMenuPanel;
    public GameObject skinSelectPanel;
    public GameObject levelSelectPanel;
    public GameObject creditPanel;
    public GameObject InGamePanel;
    public GameObject InGameSettingPanel;
    public GameObject GameEndPanel;

    public Attacked flsdkrk;

    private void Awake()
    {
        IsGamePlaying = SceneManager.GetActiveScene().name == GameSceneName;

        if (IsGamePlaying)
        {
            ShowOnly(null, true, false);
        }
        else
        {
            ShowOnly(mainMenuPanel, false, false);
        }
    }

    public void OpenSkinSelect()
    {
        ShowOnly(skinSelectPanel, false, false);
    }

    public void OpenLevelSelect()
    {
        ShowOnly(levelSelectPanel, false, false);
    }

    public void OpenCreditSelect()
    {
        ShowOnly(creditPanel, false, false);
    }

    public void BackToMainMenu()
    {
        if (SceneManager.GetActiveScene().name == GameSceneName)
        {
            EndTheGame();
            return;
        }

        IsGamePlaying = false;
        ShowOnly(mainMenuPanel, false, false);
    }

    public void OpenInGameSetting()
    {
        if (!IsGamePlaying) return;

        Time.timeScale = 0f;
        ShowOnly(null, false, true);
    }

    private bool _gameEnd = false;

    private void Update()
    {
        if (flsdkrk != null && flsdkrk.Dead && !_gameEnd)
        {
            _gameEnd = true;
            Time.timeScale = 0f;
            ShowOnly(GameEndPanel, false, false);
        }
    }

    public void CloseInGameSetting()
    {
        if (!IsGamePlaying) return;

        Time.timeScale = 1f;
        ShowOnly(null, true, false);
    }

    public void StartGame()
    {
        IsGamePlaying = false;

        if (flsdkrk != null)
        {
            flsdkrk.Dead = false;
        }
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameSceneName);
    }

    public void EndTheGame()
    {
        Time.timeScale = 1f;
        IsGamePlaying = false;
        SceneManager.LoadScene(MainMenuSceneName);
    }

    private void ShowOnly(GameObject menuPanelToShow, bool showInGameUi, bool showSettings)
    {
        SetActive(mainMenuPanel, menuPanelToShow == mainMenuPanel);
        SetActive(skinSelectPanel, menuPanelToShow == skinSelectPanel);
        SetActive(levelSelectPanel, menuPanelToShow == levelSelectPanel);
        SetActive(creditPanel, menuPanelToShow == creditPanel);
        SetActive(InGamePanel, showInGameUi);
        SetActive(InGameSettingPanel, showSettings);
        SetActive(GameEndPanel, menuPanelToShow == GameEndPanel);
    }

    private static void SetActive(GameObject target, bool active)
    {
        if (target != null)
        {
            target.SetActive(active);
        }
    }
}