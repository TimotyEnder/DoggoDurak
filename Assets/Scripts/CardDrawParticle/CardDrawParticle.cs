using UnityEngine;

public class CardDrawParticle : MonoBehaviour
{
    private Transform _target;
    private Vector2 _initPos;
    private RectTransform _myRect;   
    private Vector2 _prevPos;
    private float _currentSpeed = 0f;
    private float _acceleration = 10000f; 
    
    public void SetTarget(Transform target)
    {
        _target = target;
        _initPos = _myRect.anchoredPosition;
        _currentSpeed = 0f; 
    }  
    
    private void Awake()
    {
        _myRect = GetComponent<RectTransform>();
        _initPos = _myRect.anchoredPosition;
        _prevPos = _initPos;
    }

    void Update()
    {
        if(_target != null)
        {
            RectTransform targetRect = _target.GetComponent<RectTransform>();
            Vector2 targetAnchoredPos = targetRect.anchoredPosition;
            
            float remainingDistance = Vector2.Distance(_myRect.anchoredPosition, targetAnchoredPos);
            float totalDistance = Vector2.Distance(_initPos, targetAnchoredPos);
            float distancePercent = 1f - (remainingDistance / totalDistance);
            
            _currentSpeed += _acceleration * Time.deltaTime;
            
            
            _myRect.anchoredPosition = Vector2.MoveTowards(
                _myRect.anchoredPosition, 
                targetAnchoredPos, 
                _currentSpeed * Time.deltaTime
            );
            
            Vector2 currentPosition = _myRect.anchoredPosition;
            Vector2 movementDirection = currentPosition - _prevPos;
            
            if (movementDirection.sqrMagnitude > 0.01f)
            {
                float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
                _myRect.localRotation = Quaternion.Euler(0, 0, angle);
            }
            
            _prevPos = currentPosition;
            
            if (remainingDistance < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}