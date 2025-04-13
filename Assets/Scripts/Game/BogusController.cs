using System;
using UnityEngine;
using VContainer;

//Nothing burger controller
public class BogusController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    
    [Inject] private ILogger Logger { get; set; }

    void Start()
    {
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("Trigger");
        }
        //Logger.Log(name);
    }
}
