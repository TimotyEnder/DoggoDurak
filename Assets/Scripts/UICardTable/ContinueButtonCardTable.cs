using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonCardTable : MonoBehaviour
{
    private Button _continueButton;
    void Start()
    {
        _continueButton = this.GetComponent<Button>();
        _continueButton.onClick.AddListener(ConitnueButtonOnClick);
    }
    void ConitnueButtonOnClick()
    {
        GameHandler.Instance.Next();
    }
}
