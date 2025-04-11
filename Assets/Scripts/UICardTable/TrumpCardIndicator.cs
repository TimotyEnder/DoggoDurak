using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrumpCardIndicator : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 _revealPos;
    private Vector2 _hoverPos;
    private List<string> _trumps=new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _revealPos = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x - 55f, this.gameObject.GetComponent<RectTransform>().anchoredPosition.y);
        _hoverPos = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x - 100f, this.gameObject.GetComponent<RectTransform>().anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void InitTrumps() 
    {
        _trumps.Add("Clubs");
        _trumps.Add("Diamonds");
        _trumps.Add("Spades");
        _trumps.Add("Hearts");
    }
    public string SelectTrump() 
    {
        InitTrumps();
        int trumpSelected = Random.Range(0, _trumps.Count);
        string trumpStringSelected = _trumps[trumpSelected];
        Sprite cardSprite = Resources.Load<Sprite>("Grafics/Trumps/" + trumpStringSelected);
        this.gameObject.GetComponent<Image>().sprite = cardSprite;
        return trumpStringSelected.Substring(0,1);
    }
    public void Appear()
    {
       StartCoroutine(MoveToPosition(_revealPos, 0.5f,5f));
    }
    public IEnumerator MoveToPosition(Vector2 targetPosition, float duration, float targetRotationZ = 0f)
    {
        RectTransform rectTransform = this.gameObject.GetComponent<RectTransform>();

        Vector2 startPos = rectTransform.anchoredPosition;
        Quaternion startRot = rectTransform.rotation;
        Quaternion endRot = Quaternion.Euler(0f, 0f, targetRotationZ);

        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;

            rectTransform.anchoredPosition = Vector2.Lerp(startPos, targetPosition, t);
            rectTransform.rotation = Quaternion.Lerp(startRot, endRot, t);

            time += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        rectTransform.rotation = endRot;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       this.gameObject.GetComponent<RectTransform>().localScale = Vector3.one * 1.3f;
        StartCoroutine(MoveToPosition(_hoverPos, 0.2f, 10));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
        StartCoroutine(MoveToPosition(_revealPos, 0.2f, 5));
    }
}
