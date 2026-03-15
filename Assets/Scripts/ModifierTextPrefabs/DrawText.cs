using System.Collections;
using UnityEngine;

public class DrawText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo,Canvas _canvas)
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}
