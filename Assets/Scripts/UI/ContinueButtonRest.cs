using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButtonRest: MonoBehaviour
{
    private Button _continueButton;
    [SerializeField]
    private ShopItemContent _shopContent;
    [SerializeField]
    LifeTotal _playerLifeTotal;
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
        GameHandler.Instance.GetGameState()._freeShopRerolls = GameHandler.Instance.GetGameState()._maxFreeShopRerolls;
        GameHandler.Instance.GetGameState()._shopUnlocked=false;
        GameHandler.Instance.GetGameState()._gadalkaUnlocked=false;
        GameHandler.Instance.GetGameState()._shopItems= new System.Collections.Generic.List<ItemContainer>();
        GameHandler.Instance.GetGameState()._gadalkaBlessings= new System.Collections.Generic.List<GadalkaEffectContainer>();
        _playerLifeTotal.reportHealth();
        _shopContent.RemoveAllGrid();
        GameHandler.Instance.Next();
    }
}
