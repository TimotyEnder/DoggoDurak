using System.Collections;
using UnityEngine;

public class ParryText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo,Canvas _canvas)
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(this.gameObject, 1f);
    }
}
