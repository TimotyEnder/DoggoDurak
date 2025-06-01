using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button _quitButton;
    void Start()
    {
        _quitButton= this.gameObject.GetComponent<Button>();
        _quitButton.onClick.AddListener(QuitButtonOnClick);
    }
    void QuitButtonOnClick() 
    {
        Application.Quit();
    }
}
