using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public abstract class Item : ScriptableObject
{
    [SerializeField]
    protected int rarity; //0 commmon, 1 rare, 2 legendary
    [SerializeField]
    protected bool boss;
    protected string ItemId;//serialized already in the item container

    public abstract void InitItem();
    //happens when played loads a safe game. anything that needs to reapply its a affect of a default new character
    // and life total does it in it's OnLoad()
    public abstract void OnLoad(); 
    //when picked up
    public abstract void OnAquire();
    public abstract void OnDefendCard(Card defendee, Card defended);
    public abstract void OnPlayedCard(Card card);
    public abstract void OnReverse(Card card);

    public bool IsBoss() 
    {
        return boss;
    }
    public int GetRarity() 
    {
        return rarity;
    }
    public string GetId() 
    {
        return ItemId;
    }
}
