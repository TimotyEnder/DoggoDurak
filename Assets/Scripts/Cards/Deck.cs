using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject _card;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Draw() 
    {
        Debug.Log("Pressed");
        GameObject CardDrawn=Instantiate(_card);
        CardDrawn.GetComponent<Card>().OnDraw();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Draw();
    }
}
