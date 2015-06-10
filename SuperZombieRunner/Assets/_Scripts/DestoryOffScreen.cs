using UnityEngine;
using System.Collections;

public class DestoryOffScreen : MonoBehaviour
{
    // This is the default value for how far off the screen before the object gets destoryed.
    public float offset = 16f;

    bool _isOffscreen;
    float _offscreenX = 0f;

    Rigidbody2D _body2d;

    void Awake()
    {
        _body2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
	void Start ()
	{
        // This works out, given our computed scale, where the center point of the screen is based on different resolutions.
        // The offset is additional space offset for some leeway.
	    _offscreenX = (Screen.width/PixelPerfectCamera.pixelToUnits) / 2f + offset;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var posX = transform.position.x;
        // This is the direction the object is travelling in. This could be positive or negative depending on what side of the screen the game object is.
	    var dirX = _body2d.velocity.x;

	    if (Mathf.Abs(posX) > _offscreenX)
	    {
	        // This accounts for the object being in any direction (positive or negative).
	        if (dirX < 0 && posX < -_offscreenX)
	            _isOffscreen = true;
	        else if (dirX > 0 && posX > _offscreenX)
	            _isOffscreen = true;
	    }
	    else
	        _isOffscreen = false;

	    if (_isOffscreen)
	        OnOutOfBounds();
	}

    public void OnOutOfBounds()
    {
        // This is for re-using objects later.
        _isOffscreen = false;
        GameObjectUtility.Destroy(gameObject);
    }
}
