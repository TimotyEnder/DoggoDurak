using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{  // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Button _ngButton;
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _leftButton;
    [SerializeField]
    private Button _rightButton;
    [SerializeField]
    private TextMeshProUGUI _characterNameText;
    [SerializeField]
    private Button _panelCloseButton;
    [SerializeField]
    private GameObject _invetoryPrefab;
    [SerializeField]
    private GameObject _characterSelectPanel;
    [SerializeField]
    private Animator _characterPanelAnim;

    void Start()
    {
        _ngButton = this.gameObject.GetComponent<Button>();

        _startButton.onClick.AddListener(StartGameOnClick);
        _ngButton.onClick.AddListener(NewGameButtonOnClick);
        _panelCloseButton.onClick.AddListener(CloseButtonOnClick);
    }
    void StartGameOnClick()
    {
        GameHandler.Instance.NewGame();
    }
    async void NewGameButtonOnClick()
    {
        _characterSelectPanel.SetActive(true);
        _characterPanelAnim.SetTrigger("Extend");
    }
    async void CloseButtonOnClick()
    {
        _characterPanelAnim.SetTrigger("Shrink");
        await UniTask.Delay(500);
        _characterSelectPanel.SetActive(false);
    }
}
