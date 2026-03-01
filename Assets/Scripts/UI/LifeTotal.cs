using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LifeTotal : MonoBehaviour
{
    private int _hp;
    private TextMeshProUGUI _hpText;
    public GameObject damageTextPrefab;
    public GameObject healTextPrefab;

    private RuleHandler _rh;
    void Awake()
    {
        GameObject rhObj= GameObject.Find("RuleHandler");
        if(rhObj!=null)
        {
            _rh = rhObj.GetComponent<RuleHandler>();
        }
    }
    public void UpdateHealthUI() 
    {
        _hpText = this.gameObject.GetComponent<TextMeshProUGUI>();
        _hpText.text = _hp.ToString();
    }
    public void SetHealth(int val) 
    {
        _hp = val;
        UpdateHealthUI();
    }
    public void Damage(int damage) 
    {
        if(damage<0){damage=0;}
        _hp -= damage;
        if(_rh.CanEffectsSpawn())
        {
            TextMeshProUGUI damageText = Instantiate(damageTextPrefab, this.transform.position, this.transform.rotation, this.transform.parent).GetComponent<TextMeshProUGUI>();
            StartCoroutine(DestroyText(damageText));
            damageText.text = damage.ToString();
            damageText.fontSize = _hpText.fontSize;
        }
        UpdateHealthUI();
    }
    public void Heal(int amount)
    {
        _hp += amount;
        TextMeshProUGUI healText = Instantiate(healTextPrefab, this.transform.position, this.transform.rotation, this.transform.parent).GetComponent<TextMeshProUGUI>();
        StartCoroutine(DestroyText(healText));
        healText.text = amount.ToString();
        healText.fontSize = _hpText.fontSize;
        if (_hp > GameHandler.Instance.GetGameState()._maxhealth) 
        {
            _hp = GameHandler.Instance.GetGameState()._maxhealth;
        }
        UpdateHealthUI();
    }
    public void ShowNoDamage() //for effects that prevent damage.
    {
        if(_rh.CanEffectsSpawn())
        {
            TextMeshProUGUI damageText = Instantiate(damageTextPrefab, this.transform.position, this.transform.rotation, this.transform.parent).GetComponent<TextMeshProUGUI>();
            StartCoroutine(DestroyText(damageText));
            damageText.text = "Cannot Be Damaged!";
            damageText.fontSize = _hpText.fontSize*0.4f;
        }
    }
    public int GetHealth() 
    {
        return _hp;
    }
    public void reportHealth()
    {
        GameHandler.Instance.SetHealth(_hp);

    }
    public IEnumerator DestroyText(TextMeshProUGUI DamageText)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(DamageText.gameObject);
    }
}
