using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{  // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button _ngButton;
    void Start()
    {
        _ngButton = this.gameObject.GetComponent<Button>();
        _ngButton.onClick.AddListener(NewGameButtonOnClick);
    }
    void NewGameButtonOnClick()
    {
        GameHandler.Instance.NewGame();
    }
}
