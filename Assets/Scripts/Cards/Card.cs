using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,IDragHandler, IEndDragHandler

{
    private RectTransform _thisRect;
    private GameObject _cardHolder;
    private CardHandArea _cardHandArea;
    private int _oldSiblingIndex;
    private GameObject _cardImage;
    private Canvas _canvas;


    void Start()
    {
       InitGameComponents();
    }
    void InitGameComponents() 
    {
        //card holder init
        _cardHolder = GameObject.Find("CardHandArea");
        _cardHandArea = _cardHolder.GetComponent<CardHandArea>();

        //RectTransform is commonly used so we init it
        _thisRect = this.GetComponent<RectTransform>();


        //sibling index
        this._oldSiblingIndex = -1;

    }
    // Update is called once per frame
    void Update()
    {
    }
    public void DrawCardImage(string cardChars)
    {
        InitGameComponents();
        _cardImage = _thisRect.Find("CardImage").gameObject;
        Sprite cardSprite= Resources.Load<Sprite>("Grafics/Cards/" + cardChars); 
        _cardImage.GetComponent<Image>().sprite=cardSprite;
    }
    public void OnDraw() 
    {
        this.GetComponent<RectTransform>().SetParent(_cardHolder.GetComponent<RectTransform>());
        _thisRect.anchoredPosition = _cardHandArea.AttachCard();
        //cardHandArea.RestackHand();
        this.GetComponent<RectTransform>().SetSiblingIndex(0);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TopPointer(eventData)) 
        {
            _oldSiblingIndex = _thisRect.GetSiblingIndex();
            _thisRect.SetAsLastSibling();
            _cardImage.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_oldSiblingIndex != -1) 
        {
            _thisRect.SetSiblingIndex(_oldSiblingIndex);
        }
        _cardImage.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
    }
    private bool TopPointer(PointerEventData ped)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Card>() != null)
            {
                if (result.gameObject == this.gameObject)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _thisRect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }
}

