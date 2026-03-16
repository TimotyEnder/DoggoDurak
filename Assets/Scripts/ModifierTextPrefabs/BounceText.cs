using System.Collections;
using UnityEngine;

public class BounceText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo, Canvas _canvas)
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(this.gameObject, 1f);
    }

}
