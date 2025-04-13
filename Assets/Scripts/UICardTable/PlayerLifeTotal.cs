using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLifeTotal : MonoBehaviour
{
    private int _hpPlayer;
    private TextMeshProUGUI _playerHpText;
    void Start()
    {
        _playerHpText = this.gameObject.GetComponent<TextMeshProUGUI>();
        _hpPlayer = 40;
        UpdatePlayerHealth();
    }
    void Update()
    {
        
    }
    void UpdatePlayerHealth() 
    {
        _playerHpText.text = _hpPlayer.ToString();
    }
    public void Damage(int damage) 
    {
        _hpPlayer -=damage;
    }
    public void Heal(int amount)
    {
        _hpPlayer += amount;
    }
}
