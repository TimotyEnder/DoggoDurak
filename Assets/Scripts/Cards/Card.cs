using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Card : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DrawCard(string cardChars) 
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Grafics/Cards/" + cardChars);
    }
    public void OnDraw() 
    {
        RectTransform thisRect = this.GetComponent<RectTransform>();
        GameObject CardHolder = GameObject.Find("CardHandArea");
        CardHandArea cardHandArea = CardHolder.GetComponent<CardHandArea>();
        this.GetComponent<RectTransform>().SetParent(CardHolder.GetComponent<RectTransform>());
        thisRect.anchoredPosition = cardHandArea.AttachCard();
        //cardHandArea.RestackHand();
        this.GetComponent<RectTransform>().SetSiblingIndex(0);
    }
}

