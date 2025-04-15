using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LifeTotal : MonoBehaviour
{
    private int _hp;
    private TextMeshProUGUI _hpText;
    void Start()
    {
        _hpText = this.gameObject.GetComponent<TextMeshProUGUI>();
        _hp = 40;
        UpdateHealth();
    }
    void Update()
    {
        
    }
    void UpdateHealth() 
    {
        _hpText.text = _hp.ToString();
    }
    public void Damage(int damage) 
    {
        _hp -=damage;
    }
    public void Heal(int amount)
    {
        _hp += amount;
    }
}
