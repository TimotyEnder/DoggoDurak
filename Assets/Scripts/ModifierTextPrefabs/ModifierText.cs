using System.Collections;
using UnityEngine;

public abstract class ModifierText : MonoBehaviour
{
    public abstract IEnumerator ExecuteBehaviour(CardInfo cardInfo, Canvas _canvas);

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
    public void Init(CardInfo cardInfo, Canvas _canvas)
    {
        StartCoroutine(this.ExecuteBehaviour(cardInfo,_canvas));
    }
    protected void MoveTowards(GameObject destination)
    {
        StartCoroutine(MoveTowardsCoroutine(destination));
    }
    protected IEnumerator MoveTowardsCoroutine(GameObject destination)
        {
            Vector2 initialPosition = transform.position;
            Vector2 targetPosition = destination.transform.position;
            float totalDistance = Vector2.Distance(initialPosition, targetPosition);
            
            while (transform.position != (Vector3)targetPosition)
            {
                // Calculate progress (0 to 1)
                float currentDistance = Vector2.Distance(transform.position, targetPosition);
                float progress = 1 - (currentDistance / totalDistance);
                
                // Move with speed that varies based on progress
                // Using Lerp for smoother movement, or MoveTowards for linear
                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    targetPosition, 
                    5f * progress * Time.deltaTime
                );
                
                yield return null; // Wait for next frame
            }
            
            Destroy(gameObject);
        }
}
