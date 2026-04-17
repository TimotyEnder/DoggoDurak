using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _thisAnim;

    void Awake()
    {
        _thisAnim = GetComponent<Animator>();
    }

    public async Task SpinWithVerdict(bool IsGrate)
    {
        await UniTask.Delay(500);
        _thisAnim.SetTrigger(IsGrate ? "Grate" : "Eagle");
        await UniTask.Delay(1000);
        Destroy(this.gameObject);
    }
}
