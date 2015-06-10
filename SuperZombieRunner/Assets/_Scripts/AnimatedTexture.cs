using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;

    Vector2 _offset = Vector2.zero;
    Material _material;

	// Use this for initialization
	void Start ()
	{
	    _material = GetComponent<Renderer>().material;
	    _offset = _material.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _offset += speed*Time.deltaTime;

        _material.SetTextureOffset("_MainTex", _offset);
	}
}
