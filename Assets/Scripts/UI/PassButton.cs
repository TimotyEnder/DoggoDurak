using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PassButton : MonoBehaviour
{
    [SerializeField]
    private Button _passTurnButton;
    [SerializeField]
    private OpponentLogic _opp;
    [SerializeField]
    private Animator _anim;
    
    void Start()
    {
        _passTurnButton = this.GetComponent<Button>();
        _opp = GameObject.Find("Opponent").GetComponent<OpponentLogic>();
        _passTurnButton.onClick.AddListener(OnEndTurnClick);
    }
    void OnEndTurnClick() 
    {
        SetJiggle(false);
        StartCoroutine(_opp.EnemyPlay());
    }
    public void SetJiggle(bool state)
    {
        if(state)
        {
            _anim.SetBool("Jiggle",true);
        }
        else
        {
             _anim.SetBool("Jiggle",false);
        }
    }
}
