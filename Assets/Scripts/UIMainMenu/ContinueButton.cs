using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public Button _ctButton;
    void Start()
    {
        _ctButton = this.gameObject.GetComponent<Button>();
        _ctButton.onClick.AddListener(ContinueButtonOnClick);
        if (!GameHandler.Instance.HasSave()) 
        {
            _ctButton.interactable = false;
        }
    }
    void ContinueButtonOnClick()
    {
        GameHandler.Instance.Continue();
    }
}
