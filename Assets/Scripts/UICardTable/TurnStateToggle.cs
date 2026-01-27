using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class TurnStateToggle : MonoBehaviour
{
    private bool _def;
    private Vector2 _defPos;
    private Vector2 _atkPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _def = true;
        _atkPos = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x+113f, this.gameObject.GetComponent<RectTransform>().anchoredPosition.y);
        _defPos = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Toggle() 
    {
        if (_def)
        {
            StartCoroutine(MoveToPosition(_atkPos, 0.5f));
            _def = false;
        }
        else 
        {
            StartCoroutine(MoveToPosition(_defPos, 0.5f));
            _def = true;
        }
    }
    public IEnumerator MoveToPosition(Vector2 target, float duration)
    {
        Vector2 start = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        float time = 0f;

        while (time < duration)
        {
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(start, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        this.gameObject.GetComponent<RectTransform>().anchoredPosition = target;
    }
}
