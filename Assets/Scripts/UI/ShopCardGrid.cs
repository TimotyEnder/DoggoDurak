using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShopCardGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardPrefab;

    public void SetCardGrid()
    {
        for (int i = 0; i < 6; i++)
        {
            int modsForCard = Random.Range(1, GameHandler.Instance.GetGameState()._maxCardModsInShop);
            CardInfo toAdd = new CardInfo(CardInfo.RandomSuit(), Random.Range(6, 14));
            int modsAdded = 0;
            while (modsAdded < modsForCard)
            {
                string ModTypeToAdd = CardInfo.modifierMaxCopies.Keys.ToArrayPooled()[Random.Range(0, CardInfo.modifierMaxCopies.Count)];
                int ModTypeMaxStacks = 0;
                CardInfo.modifierMaxCopies.TryGetValue(ModTypeToAdd, out ModTypeMaxStacks);
                if ((ModTypeMaxStacks == 1 && !toAdd._modifierStacks.ContainsKey(ModTypeToAdd)) || (ModTypeMaxStacks > 1))
                {
                    toAdd.AddModifier(ModTypeToAdd);
                    modsAdded++;
                }
            }
            int roll= Random.Range(0,100);
            if(roll<GameHandler.Instance.GetGameState()._laikaCardInShopChance)
            {
                toAdd.MakeLaika();
                modsAdded++;//aditional cost becuase it is a Laika Card.
            }
            GameObject CardAdded = Instantiate(_cardPrefab, this.transform);
            CardAdded.GetComponent<Card>().MakeCard(toAdd, false, GameHandler.Instance.GetGameState()._shopCostPerCardMod * modsAdded);
        }
    }
    public void ReRoll()
    {
        foreach(RectTransform cards in this.transform)
        {
            Destroy(cards.gameObject);
        }
        SetCardGrid();
    }
}
