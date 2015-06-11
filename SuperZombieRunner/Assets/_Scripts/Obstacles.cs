using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour, IRecycle
{
    public Sprite[] sprites;

    public Vector2 colliderOffset = Vector2.zero;

    public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];

        gameObject.SetActive(true);

        var collider = GetComponent<BoxCollider2D>();
        var spriteSize = renderer.bounds.size;

        spriteSize.y += colliderOffset.y;

        collider.size = spriteSize;
        collider.offset = new Vector2(-colliderOffset.x, collider.size.y/2 - colliderOffset.y);
    }

    public void Shutdown()
    {
        gameObject.SetActive(false);
    }
}
