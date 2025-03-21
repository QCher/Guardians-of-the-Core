using System;
using UnityEngine;

//Nothing burger controller
public class BogusController : MonoBehaviour
{
    [SerializeField] Animator _animator;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("Trigger");
        }
    }
}
