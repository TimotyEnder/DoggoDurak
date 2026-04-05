using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private GameObject _settingsPanel;
    [SerializeField]
    private Animator _settingsPanelAnim;

    void Start()
    {
        _settingsButton.onClick.AddListener(SettingsOnClick);
    }
    void SettingsOnClick()
    {
        // Force animator to initialize properly
        _settingsPanelAnim.Rebind();
        _settingsPanelAnim.Update(0);
        _settingsPanel.SetActive(true);
        _settingsPanelAnim.SetTrigger("Extend");
    }
}
