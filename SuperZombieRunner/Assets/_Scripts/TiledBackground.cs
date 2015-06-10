using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour
{
    // This only works in powers of 2 - 32, 64, 128
    public int textureSize = 32;

    public bool scaleHorizontally = true;
    public bool scaleVertically = true;

    void Start()
    {
        var newWidth = scaleHorizontally ? Mathf.Ceil(Screen.width/(textureSize*PixelPerfectCamera.scale)) : 1;
        var newHeight = scaleVertically ? Mathf.Ceil(Screen.height/(textureSize*PixelPerfectCamera.scale)) : 1;

        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);
    }
}