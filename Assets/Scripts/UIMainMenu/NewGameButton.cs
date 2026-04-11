using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{ // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    private GameObject _itemContent;

    [SerializeField]
    private TextMeshProUGUI _startingRubles;

    [SerializeField]
    private Button _panelCloseButton;

    [SerializeField]
    private GameObject _invetoryPrefab;

    [SerializeField]
    private GameObject _characterSelectPanel;

    [SerializeField]
    private Animator _characterPanelAnim;

    [SerializeField]
    private GameObject _selectDotsContent;

    [SerializeField]
    private GameObject _selectDotPrefab;
    private Color _ogDotsColor;
    private Color _selectedDotsColor = Color.white;

    void Start()
    {
        _ngButton = this.gameObject.GetComponent<Button>();

        _startButton.onClick.AddListener(StartGameOnClick);
        _ngButton.onClick.AddListener(NewGameButtonOnClick);
        _panelCloseButton.onClick.AddListener(CloseButtonOnClick);
        _leftButton.onClick.AddListener(LeftOnClick);
        _rightButton.onClick.AddListener(RightOnClick);
        for (int i = 0; i < GameHandler.Instance.GetCharacterInfo().Size(); i++)
        {
            Instantiate(_selectDotPrefab, _selectDotsContent.transform);
        }
        _ogDotsColor = _selectDotsContent.transform.GetChild(0).GetComponent<Image>().color;
    }

    void StartGameOnClick()
    {
        GameHandler.Instance.NewGame();
    }

    async void NewGameButtonOnClick()
    {
        _characterSelectPanel.SetActive(true);
        _characterPanelAnim.SetTrigger("Extend");
        UpdateCharacterInfo();
    }

    private void UpdateCharacterInfo()
    {
        _selectDotsContent
            .transform.GetChild(GameHandler.Instance.GetCharacterInfo().hereIndex())
            .GetComponent<Image>()
            .color = _selectedDotsColor;
        Character chosen = GameHandler.Instance.GetCharacterInfo().here();
        _characterNameText.text = chosen.GetName();
        _startingRubles.text = chosen.GetStartRub().ToString() + StylisticClass.RubleSign;
        foreach (RectTransform item in _itemContent.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Item i in chosen.LoadItems())
        {
            GameObject iItem = Instantiate(_invetoryPrefab, _itemContent.transform);
            iItem.GetComponent<InventoryItem>().AssignItem(i);
        }
    }

    async void CloseButtonOnClick()
    {
        _characterPanelAnim.SetTrigger("Shrink");
        await UniTask.Delay(500);
        _characterSelectPanel.SetActive(false);
    }

    private async void LeftOnClick()
    {
        _characterPanelAnim.SetTrigger("Left");
        await UniTask.Delay(150);
        GameHandler.Instance.GetCharacterInfo().leftRet();
        UpdateCharacterInfo();
        _selectDotsContent
            .transform.GetChild(GameHandler.Instance.GetCharacterInfo().hereIndex())
            .GetComponent<Image>()
            .color = _selectedDotsColor;
        for (int i = 0; i < GameHandler.Instance.GetCharacterInfo().Size(); i++)
        {
            if (i != GameHandler.Instance.GetCharacterInfo().hereIndex())
            {
                _selectDotsContent.transform.GetChild(i).GetComponent<Image>().color = _ogDotsColor;
            }
        }
    }

    private async void RightOnClick()
    {
        _characterPanelAnim.SetTrigger("Right");
        await UniTask.Delay(150);
        GameHandler.Instance.GetCharacterInfo().rightRet();
        UpdateCharacterInfo();
        _selectDotsContent
            .transform.GetChild(GameHandler.Instance.GetCharacterInfo().hereIndex())
            .GetComponent<Image>()
            .color = _selectedDotsColor;
        for (int i = 0; i < GameHandler.Instance.GetCharacterInfo().Size(); i++)
        {
            if (i != GameHandler.Instance.GetCharacterInfo().hereIndex())
            {
                _selectDotsContent.transform.GetChild(i).GetComponent<Image>().color = _ogDotsColor;
            }
        }
    }
}
