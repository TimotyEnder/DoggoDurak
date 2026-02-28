using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuleBoxUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _ruleText;
    private  List<GameObject> _ruleTexts=new List<GameObject>();
    void Start()
    {
        _ruleTexts= new List<GameObject>();
        foreach(string rule in GameHandler.Instance.GetCurrEncounter().GetRules())
        {
            AddRulesText(rule);
        }
    }
    public void AddRulesText(string text) 
    {
        GameObject newText = Instantiate(_ruleText, transform);
        newText.GetComponentInChildren<TextMeshProUGUI>().text = text;
        _ruleTexts.Add(newText);
    }
    public void ShakeRule(int index)
    {
        Debug.Log("Shaking rule at index: " + index);
        if(index>=0 && index<_ruleTexts.Count)
        {
            Debug.Log("Shaking rule: " + _ruleTexts[index].GetComponentInChildren<TextMeshProUGUI>().text);
            _ruleTexts[index].GetComponent<Animator>().SetTrigger("Shake");
        }
    }
}
