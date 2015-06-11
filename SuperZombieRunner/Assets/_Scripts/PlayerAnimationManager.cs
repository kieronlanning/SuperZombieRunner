using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator _animator;
    InputState _inputState;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputState = GetComponent<InputState>();
    }

    void Update()
    {
        var running = true;

        if (_inputState.absVelX > 0 && _inputState.absVelY < _inputState.standingThreshold)
        {
            // Not running...
            running = false;
        }

        _animator.SetBool("Running", running);
    }
}
