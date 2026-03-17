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
            //Make the button visually change when you press space
            ExecuteEvents.Execute(passButton.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            
            //invoke its onClick from here
            passButton.onClick.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Return to normal state
            ExecuteEvents.Execute(passButton.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
        }
    }
}