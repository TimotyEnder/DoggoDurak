using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSpaceHandler : MonoBehaviour
{
    [SerializeField]
    public Button passButton;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //invoke its onClick from here
            passButton.onClick.Invoke();
        }
    }
}