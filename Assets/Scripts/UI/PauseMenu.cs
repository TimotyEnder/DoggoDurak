using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private Button _resumeButton;

    [SerializeField]
    private Button _settingsButton;

    [SerializeField]
    private Button _mainMenuButton;

    [SerializeField]
    private Button _desktopButton;

    void Awake()
    {
        _resumeButton.onClick.AddListener(resumeOnClick);
        _settingsButton.onClick.AddListener(settingsOnClick);
        _mainMenuButton.onClick.AddListener(mainMenuOnClick);
        _desktopButton.onClick.AddListener(quitOnClick);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_pauseMenu.activeSelf){HidePauseMenu();}
            else{ShowPauseMenu();}
        }
    }
    void ShowPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
    void HidePauseMenu()
    {
        _pauseMenu.SetActive(false);
    }
    void resumeOnClick()
    {
        HidePauseMenu();
    }
    void settingsOnClick()
    {
        throw new Exception("Add later");
    }
    void mainMenuOnClick()
    {
        GameHandler.Instance.BackToMainMenu();
    }
    void quitOnClick()
    {
        GameHandler.Instance.BackToDesktop();
    }
}
