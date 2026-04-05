using Cysharp.Threading.Tasks;
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
    private Toggle _fullScreenToggle;

    void Start()
    {
        _settingsPanelCloseButton.onClick.AddListener(SettingsCloseOnClick);
        _fullScreenToggle.onValueChanged.AddListener(OnFullScreenToggle);
        _fullScreenToggle.isOn = Screen.fullScreen;
    }
    async void SettingsCloseOnClick()
    {
        _settingsPanelAnim.SetTrigger("Shrink");
        await UniTask.Delay(300);
        _settingsPanel.SetActive(false);
    }
    void OnFullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
