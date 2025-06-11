using UnityEngine;

public class RestoringCardMod : CardModifier
{
    public void OnAquire()
    {
       
    }

    public void OnDefendCard(Card defendee, Card defended)
    {
        if (!defendee.GetCard()._opponentCard)
        {
            GameHandler.Instance.HealPlayer(Mathf.Abs(defendee.GetCard()._number - defended.GetCard()._number));
        }
        else 
        {
            GameHandler.Instance.HealOpponent(Mathf.Abs(defendee.GetCard()._number - defended.GetCard()._number));
        }
    }

    public void OnPlayedCard(Card card)
    {
       
    }

    public void OnReverse(Card card)
    {
      
    }
}
