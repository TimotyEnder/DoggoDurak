using System;
using UnityEngine;
[CreateAssetMenu(fileName = "GadalkaEffect", menuName = "Scriptable Objects/GadalkaEffect")]
[Serializable]
public abstract class GadalkaEffectInfo:ScriptableObject
{
    protected string DescriptionText;
    protected bool _blessing;
    public abstract void InitEffect();
    public abstract void ExecuteEffect();
    public string GetDescription()
    {
        return DescriptionText;
    }
    public bool IsBlessing()
    {
        return _blessing;
    }

}