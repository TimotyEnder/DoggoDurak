using System.Collections;
using UnityEngine;

public class BurnText : ModifierText
{
    public override IEnumerator DoYourThing(CardInfo cardInfo)
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(this.gameObject, 1f);
    }
}
