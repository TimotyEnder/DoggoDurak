

using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GopponentHandSizeIncEffect", menuName = "GadalkaEffect/Curse/GopponentHandSizeIncEffect")]
class GopponentHandSizeIncEffect : GadalkaEffectInfo
{
    int selectedHandsize;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._enemyHandSize+=selectedHandsize;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll = UnityEngine.Random.Range(1,3);
        selectedHandsize=roll*1;
        this.cost=roll+1;
        this.effectId="GopponentHandSizeIncEffect";
        this.descriptionText=$"All opponents handsize +{selectedHandsize}";
        
    }
}