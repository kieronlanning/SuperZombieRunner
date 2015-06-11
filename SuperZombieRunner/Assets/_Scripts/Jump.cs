using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 240f;
    public float forwardSpeed = 20f;

    Rigidbody2D _body2d;
    InputState _inputState;

    void Awake()
    {
        _body2d = GetComponent<Rigidbody2D>();
        _inputState = GetComponent<InputState>();
    }

    void Update()
    {
        if (_inputState.standing)
        {
            if (_inputState.actionButton)
            {
                _body2d.velocity = new Vector2(
                    transform.position.x < 0
                        ? forwardSpeed
                        : 0, jumpSpeed);
            }
        }
    }
}
