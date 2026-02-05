using System.Collections;
using TMPro;
using UnityEngine;

public class MaxPlayerHealthText : MonoBehaviour
{
    private int _maxHp;
    private TextMeshProUGUI _mhpText;
    public GameObject healTextPrefab;
    private RuleHandler _rh;
    void Start()
    {
        GameObject rhObj= GameObject.Find("RuleHandler");
        if(rhObj!=null)
        {
            _rh = rhObj.GetComponent<RuleHandler>();
        }
        _maxHp=GameHandler.Instance.GetGameState()._maxhealth;
        UpdateHealth();
    }
    public void Increase(int amount)
    {
        _maxHp += amount;
        TextMeshProUGUI healText = Instantiate(healTextPrefab, this.transform.position, this.transform.rotation, this.transform.parent).GetComponent<TextMeshProUGUI>();
        StartCoroutine(DestroyText(healText));
        healText.text = amount.ToString();
        healText.fontSize = _mhpText.fontSize;
        if (_maxHp > GameHandler.Instance.GetGameState()._maxhealth) 
        {
            _maxHp = GameHandler.Instance.GetGameState()._maxhealth;
        }
        UpdateHealth();
    }
    void UpdateHealth() 
    {
        _mhpText = this.gameObject.GetComponent<TextMeshProUGUI>();
        _mhpText.text = "/"+_maxHp.ToString();
    }
    public IEnumerator DestroyText(TextMeshProUGUI DamageText)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(DamageText.gameObject);
    }
}
