using UnityEngine;
using UnityEngine.UI;

public class OpponentEncounterBG : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch(GameHandler.Instance.GetCurrEncounter().GetDay())
        {
            case 0:
                GetComponent<Image>().color = StylisticClass.Day1Encounter;
                break;
            case 1:
                GetComponent<Image>().color = StylisticClass.Day2Encounter;
                break;
            case 2:
                GetComponent<Image>().color = StylisticClass.Day3Encounter;
                break;
            default:
                GetComponent<Image>().color = Color.white; // Default color
                break;
        }
        if(GameHandler.Instance.GetCurrEncounter().IsBoss())
        {
            GetComponent<Image>().color = StylisticClass.BossEncounter;
        }
    }
}
