using System.Collections;
using UnityEngine;

public abstract class ModifierText : MonoBehaviour
{
    public abstract IEnumerator DoYourThing(CardInfo cardInfo);
}
