using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPassButton : MonoBehaviour
{
    private Button thisButt;

    void Awake()
    {
        thisButt = this.gameObject.GetComponent<Button>();
        thisButt.onClick.AddListener(PassButtHandler);
    }

    void PassButtHandler()
    {
        SceneManager.LoadScene(0);
    }
}
