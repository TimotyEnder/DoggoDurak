using UnityEngine;

public class OpponentEncounterTooltipCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<ToolTip>().SetTooltipActiveState(true);
         this.GetComponent<ToolTip>().SetToolTipText(GameHandler.Instance.GetCurrEncounter().GetTooltipText());
    }
}
