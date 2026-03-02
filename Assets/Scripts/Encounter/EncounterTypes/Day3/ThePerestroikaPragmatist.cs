
using UnityEngine;
using Cysharp.Threading.Tasks;
[CreateAssetMenu(fileName = "ThePerestroikaPragmatist", menuName = "Encounters/Day3/ThePerestroikaPragmatist")]
public class ThePerestroikaPragmatist : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Perestroika Pragmatist";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        this.description="Everything will be rebuilt!";
        hasRules=true;
    }
    public override void AddRules()
    {
       AddRule("At the end of each turn, discard your entire hand."); //0
       AddRule("You recieve"+StylisticClass.DamageNumber(5)+" for each card <b>discarded for your hand</b>");//1
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        
    }

    public override void OnPlayedCard(Card card)
    {
        
    }

    public override void OnReverse(Card card)
    {
        
    }

    public async override void OnTurnEnd(int turnState)
    {
        for(int i=0;i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            GameHandler.Instance.PlayerDiscard(0,1);
            await UniTask.Delay(100);
        }
        ShakeRule(0);
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        if(!card._opponentCard)
        {
          GameHandler.Instance.DamagePlayer(5);
          ShakeRule(1);
        }
    }
}