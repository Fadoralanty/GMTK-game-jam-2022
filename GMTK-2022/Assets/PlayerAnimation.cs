using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunningSides(bool isRunning)
    {
        _animator.SetBool("IsRunningsSides", isRunning);
    }
    public void RunningUP(bool isRunningUp)
    {
        _animator.SetBool("RuninngUP", isRunningUp);
    }
    public void RunningDown(bool isRunningDown)
    {
        _animator.SetBool("RunningDown", isRunningDown);
    }

}
