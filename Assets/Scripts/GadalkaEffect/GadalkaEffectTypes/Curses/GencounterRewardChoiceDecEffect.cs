using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GencounterRewardChoiceDecEffect", menuName = "GadalkaEffect/Curse/GencounterRewardChoiceDecEffect")]
class GencounterRewardChoiceDecEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._maxRewardChoices--;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        this.cost=2;
        this.descriptionText=$"Encounter rewards will have {StylisticClass.HighLight}1{StylisticClass.HighLightClose} fewer choice to choose from";
    }
}