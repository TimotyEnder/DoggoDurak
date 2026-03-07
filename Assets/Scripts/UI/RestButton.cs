using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestButton : MonoBehaviour
{
    [SerializeField]
    private  Button _restButton;
    [SerializeField]
    private  RectTransform _costContent;
    [SerializeField]
    private GameObject _restPointPrefab;
    void Start()
    {
        _restButton = this.gameObject.GetComponent<Button>();
        _restButton.onClick.AddListener(RestButtonOnClick);
        SetRestCost();
    }
    private void SetRestCost()
    {
         foreach(RectTransform g in _costContent.transform)
        {
            Destroy(g.gameObject);
        }
        for(int i=0; i<GameHandler.Instance.GetGameState()._restRpointCost;i++)
        {
            GameObject restPoint= Instantiate(_restPointPrefab);
            restPoint.GetComponent<RectTransform>().localScale= Vector3.one;
            restPoint.transform.SetParent(_costContent);
        }
    }
    void RestButtonOnClick()
    {
        if (GameHandler.Instance.GetGameState()._restPoints >= GameHandler.Instance.GetGameState()._restRpointCost)
        {
            GameHandler.Instance.GetGameState()._restPoints -= GameHandler.Instance.GetGameState()._restRpointCost;
            GameHandler.Instance.HealPlayer(Mathf.RoundToInt(GameHandler.Instance.GetGameState()._maxhealth * 0.5f),true);
            GameObject.Find("RestHandler").GetComponent<RestHandler>().UpdateRestUI();
        }
        else 
        {
            //add red color blink to indicate operation impossible
        }
    }
}
