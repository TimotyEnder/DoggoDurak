using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class CardModifier
{
    public abstract bool OnAquire();
    public abstract bool OnDefendCard(Card defendee, Card defended);
    public abstract bool OnPlayedCard(Card card);
    public abstract bool OnReverse(Card card);
    public abstract bool OnBeingDefended(Card cardDefendingThis);

    public async void DelayedDamage(int amount, bool player)
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeDamage()));
        if (player)
        {
            GameHandler.Instance.DamagePlayer(amount);
        }
        else
        {
            GameHandler.Instance.DamageOpponent(amount);
        }
    }
    public async void  DelayedHeal(int amount,bool player)
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeDamage()));
        if (player)
        {
            GameHandler.Instance.HealPlayer(amount);
        }
        else
        {
            GameHandler.Instance.HealOpponent(amount);
        }
    }
}
