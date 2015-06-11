using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour
{
    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;
    public bool standing;
    public float standingThreshold = 1f;

    Rigidbody2D _body2d;

    void Awake()
    {
        _body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        actionButton = Input.anyKeyDown;
    }

    void FixedUpdate()
    {
        absVelX = Mathf.Abs(_body2d.velocity.x);
        absVelY = Mathf.Abs(_body2d.velocity.y);

        standing = absVelY <= standingThreshold;
    }
}
