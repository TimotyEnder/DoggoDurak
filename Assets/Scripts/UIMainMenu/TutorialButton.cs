using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    private Button _thisButton;

    void Start()
    {
        _thisButton = this.gameObject.GetComponent<Button>();
        _thisButton.onClick.AddListener(tutorialButtonOnClick);
    }

    void tutorialButtonOnClick()
    {
        GameHandler.Instance.TutorialInit();
    }
}
