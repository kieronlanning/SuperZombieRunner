using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour
{
   // Pixel to units ratios setup for the artwork.
    static public float pixelToUnits = 1f;
    static public float scale = 1f;

    public Vector2 nativeResolution = new Vector2(240, 160);

    void Awake()
    {
        var camera = GetComponent<Camera>();
        if (camera.orthographic)
        {
            scale = Screen.height/nativeResolution.y;
            pixelToUnits *= scale;

            // Because 0,0 is at the center, we need half the height to work out the scale.
            camera.orthographicSize = (Screen.height/2f) / pixelToUnits;
        }
    }
}
