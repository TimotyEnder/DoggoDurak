using TMPro;
using UnityEngine;
using UnityEngine.UI;

class GadalkaPanel:MonoBehaviour
{
    [SerializeField]
    private GameObject _cursesPanel;
    [SerializeField]
    private GameObject _blessingsPanel;
    [SerializeField]
    private TextMeshProUGUI _pointsText;
    [SerializeField]
    private GameObject _gadalkaEffectPrefab;
    private int _points;
    [SerializeField]
    private Button _confirmButton;
    void  Awake()
    {
        _points=0;
    }
    public void SetGadalkaEffects()
    {
        foreach(RectTransform e in _blessingsPanel.transform)
        {
            Destroy(e.gameObject);
        }
         foreach(RectTransform e in _cursesPanel.transform)
        {
            Destroy(e.gameObject);
        }
        foreach(GadalkaEffectInfo gInfo in GameHandler.Instance.CompileBlessings())
        {
            GameObject gEffect= Instantiate(_gadalkaEffectPrefab,_blessingsPanel.transform);
            gEffect.GetComponent<GadalkaEffect>().MakeGEffect(gInfo);
        }
        foreach(GadalkaEffectInfo gInfo in GameHandler.Instance.CompileCurses())
        {
            GameObject gEffect= Instantiate(_gadalkaEffectPrefab,_cursesPanel.transform);
            gEffect.GetComponent<GadalkaEffect>().MakeGEffect(gInfo);
        }
    }
}