using System;
using Cysharp.Threading.Tasks;
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
    private GameObject _settingsPanel;
    [SerializeField]
    private Animator _settingsPanelAnim;

    [SerializeField]
    private Button _mainMenuButton;

    [SerializeField]
    private Button _desktopButton;
    [SerializeField]
    private Animator _thisAnim;
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
    async void ShowPauseMenu()
    {
        _pauseMenu.SetActive(true);
        _thisAnim.SetTrigger("Extend");
        await UniTask.Delay(200);
    }
    async void HidePauseMenu()
    {
        _thisAnim.SetTrigger("Shrink");
        await UniTask.Delay(250);
        _pauseMenu.SetActive(false);
    }
    void resumeOnClick()
    {
        HidePauseMenu();
    }
    void settingsOnClick()
    {
         // Force animator to initialize properly
        _settingsPanelAnim.Rebind();
        _settingsPanelAnim.Update(0);
        _settingsPanel.SetActive(true);
        _settingsPanelAnim.SetTrigger("Extend");
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
