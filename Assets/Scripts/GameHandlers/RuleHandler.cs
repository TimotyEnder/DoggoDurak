using UnityEngine;

public class RuleHandler : MonoBehaviour
{
    [SerializeField]
    private string _trumpSuit;
    public void SetTrumpSuit(string suit) 
    {
        _trumpSuit = suit;  
    }
    public string GetTrumpSuit() 
    {
        return _trumpSuit;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
