using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrumpCardIndicator : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 _revealPos;
    private Vector2 _hoverPos;
    private List<string> _trumps=new List<string>();
    private List<string> _trumpColors=new List<string>(){"White","Red","White","Red"};
    private int _trumpSelected;
    private bool _appeared=false;
    [SerializeField]
    GameObject _trumpTextPrefab;
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
        this.GetComponent<ToolTip>().SetTooltipActiveState(false);
        _trumpSelected = -1;
        switch (GameHandler.Instance.GetCurrEncounter().GetTrumpSuit()) 
        {
            case 'C':
                _trumpSelected = 0;
                break;
            case 'D':
                _trumpSelected = 1;
                break;
            case 'S':
                _trumpSelected = 2;
                break;
            case 'H':
                _trumpSelected = 3;
                break;
            default:
                 _trumpSelected = Random.Range(0, _trumps.Count);
                break;
        }
        string trumpStringSelected = _trumps[_trumpSelected];
        Sprite cardSprite = Resources.Load<Sprite>("Grafics/Trumps/" + trumpStringSelected);
        this.gameObject.GetComponent<Image>().sprite = cardSprite;
        return trumpStringSelected.Substring(0, 1);
    }
    public void Appear()
    {
        StartCoroutine(TrumpAppear());
    }
    private IEnumerator TrumpAppear()
    {
        RectTransform myRect = GetComponent<RectTransform>();
        myRect.anchoredPosition = new Vector2(-962,0);
        GameObject trumpTxt= Instantiate(_trumpTextPrefab, this.transform.parent);
        trumpTxt.GetComponent<TrumpSuitText>().SetText(GetTrumpText());
         trumpTxt.GetComponent<TrumpSuitText>().Init(null, this.gameObject.GetComponentInParent<Canvas>());
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoveToPosition(_revealPos, 0.5f,5f));
        this.GetComponent<ToolTip>().SetToolTipText(GetToolTip());
        this.GetComponent<ToolTip>().SetTooltipActiveState(true);
        _appeared=true;
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
      if(_appeared){ this.gameObject.GetComponent<RectTransform>().localScale = Vector3.one * 1.3f;
        StartCoroutine(MoveToPosition(_hoverPos, 0.2f, 10));}
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       if(_appeared){this.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
        StartCoroutine(MoveToPosition(_revealPos, 0.2f, 5));}
    }
    public string GetToolTip()
    {
        return  $"<size="+SettingsState.ToolTipFontSizeTitle+"><align=center>"+"The trump suit is "+"<color="+_trumpColors[_trumpSelected]+">"+_trumps[_trumpSelected]+ "!</color></align></size>";
    }
    public string GetTrumpText()
    {
        return  $"<align=center>"+"The trump suit is "+"<color="+_trumpColors[_trumpSelected]+">"+_trumps[_trumpSelected]+ "!</color></align></size>";
    }
}
