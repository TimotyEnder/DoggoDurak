using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GmaxHealthDecEffect", menuName = "GadalkaEffect/Curse/GmaxHealthDecEffect")]
class GmaxHealthDecEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._maxhealth-=SelectedAmount;
        if(GameHandler.Instance.GetGameState()._health>GameHandler.Instance.GetGameState()._maxhealth)
        {
            GameHandler.Instance.SetHealth(GameHandler.Instance.GetGameState()._maxhealth);
        }
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=roll;
        SelectedAmount= 20 * roll;
        this.effectId="GmaxHealthDecEffect";
        this.descriptionText=$"Max health -{SelectedAmount}";
    }
}