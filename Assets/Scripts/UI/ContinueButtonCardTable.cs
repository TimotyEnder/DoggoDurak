using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButtonCardTable : MonoBehaviour
{
    private Button _continueButton;
    void Start()
    {
        _continueButton = this.GetComponent<Button>();
        _continueButton.onClick.AddListener(ContinueButtonOnClick);
    }
    void ContinueButtonOnClick()
    {
        if (GameHandler.Instance.GetGameState()._health>0)
        {
            GameHandler.Instance.GetGameState()._rubles += GameHandler.Instance.GetCurrReward().rubleReward;
            GameHandler.Instance.Next();
        }
        else 
        {
            SceneManager.LoadScene(0);
        }
    }
}
