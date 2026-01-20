using System.Collections;
using UnityEngine;

public class BurnText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo,Canvas _canvas)
    {
        Vector2 randDirMod = this.GetSemiCircleNormVect();
        Rigidbody2D rbInst = this.gameObject.GetComponent<Rigidbody2D>();;
        rbInst.linearVelocity = randDirMod * (_canvas.pixelRect.width*0.15f);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        if(!cardInfo._opponentCard)
        {
            this.MoveTowards(GameObject.Find("OpponentsLifeTotal"));
        }
        else
        {
            this.MoveTowards(GameObject.Find("PlayerLifeTotal"));
        }
    }
}
