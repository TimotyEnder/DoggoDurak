using UnityEngine;

public class DiscardPilePositions : MonoBehaviour
{
    [SerializeField]
    private int _range_x;
    [SerializeField]
    private int _range_y;

    private RectTransform _myRect;
    void Start()
    {
        _myRect = GetComponent<RectTransform>();
    }
    public Vector2 GetDiscardPileCardPosition()
    {
        float randomX = Random.Range(_myRect.anchoredPosition.x - _range_x, _myRect.anchoredPosition.x + _range_x);
        float randomY = Random.Range(_myRect.anchoredPosition.y - _range_y, _myRect.anchoredPosition.y + _range_y);
        return new Vector2(randomX, randomY);
    }
    public Quaternion GetRandomRotation()
    {
        float randomZ = Random.Range(-60f, 60f);
        return Quaternion.Euler(0, 0, randomZ);
    }
}
