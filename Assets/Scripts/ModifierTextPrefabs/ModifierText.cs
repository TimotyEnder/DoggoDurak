using System.Collections;
using UnityEngine;

public abstract class ModifierText : MonoBehaviour
{
    public abstract IEnumerator DoYourThing(CardInfo cardInfo, Canvas _canvas);

    protected Vector2 GetSemiCircleNormVect()
    {
        float startAngle=30f;
        float endAngle=150f;
        Vector2 toRet=Random.insideUnitCircle.normalized;
         // Get its angle and magnitude
        float originalAngle = Mathf.Atan2(toRet.y, toRet.x);
        float magnitude = toRet.magnitude;
    
        // Remap angle to our semicircle segment
        float normalizedAngle = (originalAngle + Mathf.PI) / (2f * Mathf.PI); // Convert to 0-1
        float targetAngle = Mathf.Lerp(startAngle * Mathf.Deg2Rad, endAngle * Mathf.Deg2Rad, normalizedAngle);
        toRet=new Vector2(Mathf.Cos(targetAngle), Mathf.Sin(targetAngle)).normalized;
        return toRet;
    }
}
