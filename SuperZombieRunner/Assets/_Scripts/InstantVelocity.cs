using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour
{
    public Vector2 velocity = Vector2.zero;

    Rigidbody2D _body2d;

	void Awake ()
	{
	    _body2d = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        _body2d.velocity = velocity;
    }
}
