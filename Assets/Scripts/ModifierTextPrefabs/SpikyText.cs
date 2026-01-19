using System.Collections;
using UnityEngine;

public class SpikyText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo, Canvas _canvas)
    {
        Vector2 randDirMod = this.GetSemiCircleNormVect();
        Rigidbody2D rbInst = this.gameObject.GetComponent<Rigidbody2D>();;
        rbInst.linearVelocity = randDirMod * (_canvas.pixelRect.width*0.15f);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(this.gameObject, 1f);
    }

}
