using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Pool;
using Random = Unity.Mathematics.Random;

public class Creature : MonoBehaviour
{
    private PooledObject<Creature> _reference;
    public void Initialization(PooledObject<Creature> reference)
    {
        _reference = reference;
    }
    private void OnEnable()
    {
        StartTask();
    }
    
    private async void StartTask()
    {
        await ReleaseTask();
    }
    
    async UniTask ReleaseTask()
    {
        await UniTask.Delay(5000);
        using (_reference)
        { }
    }
    
    
}
