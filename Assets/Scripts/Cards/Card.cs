using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RectTransform _thisRect;
    private GameObject _cardHolder;
    private CardHandArea _cardHandArea;
    private Canvas _canvas;
    
    void Start()
    {
       InitGameComponents();
    }
    void InitGameComponents() 
    {
        _cardHolder = GameObject.Find("CardHandArea");
        _cardHandArea = _cardHolder?.GetComponent<CardHandArea>();
        _thisRect = this.GetComponent<RectTransform>();

        // init canvas
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
        InitGameComponents();
        this.GetComponent<RectTransform>().SetParent(_cardHolder.GetComponent<RectTransform>());
        _thisRect.anchoredPosition = _cardHandArea.AttachCard();
        //cardHandArea.RestackHand();
        this.GetComponent<RectTransform>().SetSiblingIndex(0);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TopPointer(eventData)) 
        {
            // sorting order, bitch :)
            this._thisRect.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        this._thisRect.localScale = new Vector3(1f, 1f, 1f);
    }
    private bool TopPointer(PointerEventData ped) 
    {
        List<RaycastResult>  results= new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        foreach(RaycastResult result in results) 
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
        return false;

    }
}

