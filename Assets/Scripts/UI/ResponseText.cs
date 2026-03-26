using TMPro;
using UnityEngine;

class ResponseText:MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _responseText;
    public void AddToResponseText(string textToAdd) 
    {
        _responseText.text += "<wave  a=0.1>" + textToAdd + "</wave>\n";
    }  
    public void WipeResponseText() 
    {
        _responseText.text = "";
    } 
}