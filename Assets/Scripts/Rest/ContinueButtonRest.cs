using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButtonRest: MonoBehaviour
{
    private Button _continueButton;
    void Start()
    {
        _continueButton = this.GetComponent<Button>();
        _continueButton.onClick.AddListener(ContinueButtonOnClick);
    }
    void ContinueButtonOnClick()
    {
        GameHandler.Instance.GetGameState()._restPoints = GameHandler.Instance.GetGameState()._maxrestPoints;
        GameHandler.Instance.GetGameState()._discardingCardInShopCost = GameHandler.Instance.GetGameState()._startingDiscardInShopCost;
        GameHandler.Instance.GetGameState()._shopRerollCost = GameHandler.Instance.GetGameState()._startingShopRerollCost;
        GameHandler.Instance.Next();
    }
}
