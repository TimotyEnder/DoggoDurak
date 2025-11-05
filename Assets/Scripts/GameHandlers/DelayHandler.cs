using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class DelayHandler
{
    public static float DelayTimeModifierEffect = 0.1f; //later on just take the global settings number
    //yep, this method exists just becuase i cant wait for a float amount of time with Task.Delay(), sigh...
    public static async Task DelayFloat(float seconds)
    {
        var stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed.TotalMilliseconds < (seconds*1000))
        {
            await Task.Yield();
        }
    }
}
