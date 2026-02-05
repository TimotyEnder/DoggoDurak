using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressBarIndicator : MonoBehaviour
{
    private float[] _indicatorPositions={56,120,167,167,255,320,370,370,456,519,568,568};
    [SerializeField]
    private RectTransform _myRect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _myRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        int movePosition=GameHandler.Instance.GetGameState()._encounter-1;
        StartCoroutine(MoveToWidth(_indicatorPositions[movePosition],0.5f));
    }
    public IEnumerator MoveToWidth(float targetWidth, float duration)
    {

        float startWidth = _myRect.rect.width;

        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            _myRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(startWidth,targetWidth,t));

            time += Time.deltaTime;
            yield return null;
        }

        _myRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
    }
}
