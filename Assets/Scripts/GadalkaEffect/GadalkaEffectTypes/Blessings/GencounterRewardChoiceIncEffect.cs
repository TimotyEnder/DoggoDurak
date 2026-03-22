using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GencounterRewardChoiceIncEffect", menuName = "GadalkaEffect/Blessing/GencounterRewardChoiceIncEffect")]
class GencounterRewardChoiceIncEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._maxRewardChoices++;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        this.cost=-2;
        this.effectId="GencounterRewardChoiceIncEffect";
        this.descriptionText=$"Encounter rewards will have {StylisticClass.HighLight}1{StylisticClass.HighLightClose} more choice to choose from";
    }
}