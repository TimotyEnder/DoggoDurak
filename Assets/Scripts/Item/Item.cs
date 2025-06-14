using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public abstract class Item : ScriptableObject
{
    protected int rarity; //0 commmon, 1 uncommon, 2 rare , 3 legendary
    protected bool boss;
    public abstract void InitItem();
    public abstract void OnAquire();
    public abstract void OnDefendCard(Card defendee, Card defended);
    public abstract void OnPlayedCard(Card card);
    public abstract void OnReverse(Card card);
    public abstract void OnBeingDefended(Card cardDefendingThis);

    public bool IsBoss() 
    {
        return boss;
    }
    public int GetRarity() 
    {
        return rarity;
    }
}
