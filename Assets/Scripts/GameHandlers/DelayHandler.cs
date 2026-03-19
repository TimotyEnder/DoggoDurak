using Cysharp.Threading.Tasks;
using System;

public static class DelayHandler
{
    public static float DelayTimeModifierEffectDamage = 0.05f; //later on just take the global settings number
    public static float DelayTimeModifierEffectAnim = 0.15f;
    //yep, this method exists just becuase i cant wait for a float amount of time with Task.Delay(), sigh...
    // Fixed version using UniTask
    public static float GiveDelayTimeAnim(int times=0)
    {
        // Half-life decay formula: initialValue * (0.5)^(times / halfLife)      // Starting damage value
        float halfLife = 3f;             // Number of steps to reduce by half
        
        if (times <= 0)
            return DelayTimeModifierEffectAnim;
        
        return DelayTimeModifierEffectAnim * MathF.Pow(0.5f, times / halfLife);
    }
    public static float GiveDelayTimeDamage(int times = 0)
    {
        return DelayTimeModifierEffectDamage;
    }
    
}
