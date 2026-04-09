using UnityEngine;

public class TutorialInitHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private CardHandArea chAttackInfo;
    [SerializeField]
    private CardHandArea chTrumpInfo;

    [SerializeField]
    private CardHandArea chDefendkInfo;

    [SerializeField]
    private CardHandArea chReverse;
    [SerializeField]
    private TrumpCardIndicator _trumpIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _trumpIndicator.SelectTrump(1);
        _trumpIndicator.Appear();
    }

    //mUpdate is called once per frame
    void Update()
    {

    }
}
