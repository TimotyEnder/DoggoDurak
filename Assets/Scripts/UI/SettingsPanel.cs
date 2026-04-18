using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button _settingsPanelCloseButton;

    [SerializeField]
    private GameObject _settingsPanel;

    [SerializeField]
    private Animator _settingsPanelAnim;

    [SerializeField]
    private TMP_Dropdown _screenDropDown;
    private Resolution _fullScreenRes;
    private List<TMP_Dropdown.OptionData> _screenOptions;

    void Start()
    {
        _fullScreenRes = Screen.currentResolution;
        _settingsPanelCloseButton.onClick.AddListener(SettingsCloseOnClick);
        _screenDropDown.ClearOptions();
        _screenOptions = new List<TMP_Dropdown.OptionData>();
        _screenOptions.Add(new TMP_Dropdown.OptionData("Exclusive Fullscreen"));
        _screenOptions.Add(new TMP_Dropdown.OptionData("Fullscreen Window"));
        _screenOptions.Add(new TMP_Dropdown.OptionData("Windowed"));
        _screenDropDown.AddOptions(_screenOptions);
        _screenDropDown.onValueChanged.AddListener(ScreenOptionsDropDownHandler);
    }

    private void ScreenOptionsDropDownHandler(int selectedIndex)
    {
        // selectedIndex corresponds to your dropdown order:
        // 0 = "Fullscreen" (default/current)
        // 1 = "Exclusive Fullscreen"
        // 2 = "Fullscreen Window"
        // 3 = "Windowed"

        Resolution nativeResolution = Screen.currentResolution;

        switch (selectedIndex)
        {
            case 0: // "Exclusive Fullscreen"
                Screen.SetResolution(
                    nativeResolution.width,
                    nativeResolution.height,
                    FullScreenMode.ExclusiveFullScreen
                );
                break;

            case 1: // "Fullscreen Window" (borderless window at desktop resolution)
                Screen.SetResolution(
                    nativeResolution.width,
                    nativeResolution.height,
                    FullScreenMode.FullScreenWindow
                );
                break;

            case 2: // "Windowed"
                // You might want to store and restore a specific window size
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                break;
        }

        Debug.Log($"Switched to: {_screenOptions[selectedIndex].text} (Index: {selectedIndex})");
    }

    async void SettingsCloseOnClick()
    {
        _settingsPanelAnim.SetTrigger("Shrink");
        await UniTask.Delay(300);
        _settingsPanel.SetActive(false);
    }
}
