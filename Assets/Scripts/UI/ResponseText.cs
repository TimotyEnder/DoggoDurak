using TMPro;
using UnityEngine;

class ResponseText:MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _responseText;
    int BufferSize=0;
    public void AddToResponseText(string textToAdd) 
    {
        BufferSize++;
        if(BufferSize<3)
        {
            WipeResponseText();
            BufferSize=0;
        }
        _responseText.text += "<wave  a=0.1>" + textToAdd + "</wave>\n";
    }  
    public void WipeResponseText() 
    {
        _responseText.text = "";
    } 
}