using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LifeTotal : MonoBehaviour
{
    private int _hp;
    private TextMeshProUGUI _hpText;
    void Start()
    {
    }
    void UpdateHealth() 
    {
        _hpText = this.gameObject.GetComponent<TextMeshProUGUI>();
        _hpText.text = _hp.ToString();
    }
    public void SetHealth(int val) 
    {
        _hp = val;
        UpdateHealth();
    }
    public void Damage(int damage) 
    {
        _hp -=damage;
        UpdateHealth();
    }
    public void Heal(int amount)
    {
        _hp += amount;
        if (_hp > GameHandler.Instance.GetGameState()._maxhealth) 
        {
            _hp = GameHandler.Instance.GetGameState()._maxhealth;
        }
        UpdateHealth();
    }
    public int GetHealth() 
    {
        return _hp;
    }
    public void reportHealth() 
    {
        GameHandler.Instance.SetHealth(_hp);

    }
}
