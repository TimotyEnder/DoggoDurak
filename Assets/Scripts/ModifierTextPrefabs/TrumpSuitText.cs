using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TrumpSuitText : ModifierText
{
    public override IEnumerator ExecuteBehaviour(CardInfo cardInfo, Canvas _canvas)
    {
        //cardinfo is not used in this behaviour, but it is still required to be passed in as a parameter to match the signature of the base class method
        Vector2 randDirMod = Vector2.up;
        Rigidbody2D rbInst = this.gameObject.GetComponent<Rigidbody2D>();
        rbInst.linearVelocity = randDirMod * (_canvas.pixelRect.width*0.2f);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(this.gameObject, 0.5f);
    }
    public  void SetText(String text)
    {
        this.GetComponent<TextMeshProUGUI>().text ="<wave a=0.3>"+ text +"</wave>";
    }
}
