using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RectTransform _thisRect;
    private GameObject _cardHolder;
    private CardHandArea _cardHandArea;
    void Start()
    {
        _thisRect = this.GetComponent<RectTransform>();
        _cardHolder = GameObject.Find("CardHandArea");
        _cardHandArea = _cardHolder.GetComponent<CardHandArea>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DrawCardImage(string cardChars) 
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Grafics/Cards/" + cardChars);
    }
    public void OnDraw() 
    {
        _cardHolder = GameObject.Find("CardHandArea");
        _cardHandArea = _cardHolder.GetComponent<CardHandArea>();
        this.GetComponent<RectTransform>().SetParent(_cardHolder.GetComponent<RectTransform>());
        _thisRect.anchoredPosition = _cardHandArea.AttachCard();
        //cardHandArea.RestackHand();
        this.GetComponent<RectTransform>().SetSiblingIndex(0);
    }
    public void OnPointerEnter(PointerEventData eventData) 
    {
        //this._thisRect.SetSiblingIndex(0);
       // this._thisRect.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       // this._cardHandArea.RestackHand();
       // this._thisRect.localScale = new Vector3(1f, 1f, 1f);
    }
}

