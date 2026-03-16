using System.Collections;
using UnityEngine;

public class RestoringText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo,Canvas _canvas)
    {
       yield return new WaitForSeconds(1);
       Destroy(this.gameObject);
    }
}
