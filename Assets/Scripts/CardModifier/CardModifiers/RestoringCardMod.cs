using UnityEngine;

public class RestoringCardMod : CardModifier
{
    public void OnAquire()
    {
       
    }

    public void OnDefendCard(Card defendee, Card defended)
    {
        GameHandler.Instance.Heal(Mathf.Abs(defendee.GetCard()._number - defended.GetCard()._number));
    }

    public void OnPlayedCard(Card card)
    {
       
    }

    public void OnReverse(Card card)
    {
      
    }
}
