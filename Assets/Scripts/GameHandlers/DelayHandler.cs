using Cysharp.Threading.Tasks;
using System;

public static class DelayHandler
{
    public static float DelayTimeModifierEffectDamage = 0.05f; //later on just take the global settings number
    public static float DelayTimeModifierEffectAnim = 0.15f;
    //yep, this method exists just becuase i cant wait for a float amount of time with Task.Delay(), sigh...
    // Fixed version using UniTask
    public static float GiveDelayTimeAnim()
    {
        return DelayTimeModifierEffectAnim;
    }
        public static float GiveDelayTimeDamage()
    {
        return DelayTimeModifierEffectDamage;
    }
    
}
