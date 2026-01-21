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
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        while (Vector2.Distance(transform.position, targetPosition) > 20f)
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float currentDistance = Vector2.Distance(transform.position, targetPosition);
            float progress = (1 - (currentDistance / totalDistance))+0.1f;
            float speed = 2000f* progress;
            rb.linearVelocity = direction * speed;
            
            yield return null;
        }
            Destroy(gameObject);
        }
    }
