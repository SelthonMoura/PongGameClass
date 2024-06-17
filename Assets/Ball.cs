using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public float speed;
    public SpriteRenderer[] spriteRenderers;
    public Rigidbody2D rb;
    public UnityEvent onHit;
    private void OnEnable()
    {
        Reset();
        GameManager.onPointScored += Reset;
    }

    private void Reset()
    {
        transform.position = Vector2.zero;
        rb.velocity = new Vector2(Random.value < 0.5f ? 1 : -1, Random.value < 0.5f ? 1 : -1).normalized * speed;
        foreach (var spriteRenderer in spriteRenderers)
        spriteRenderer.flipX = rb.velocity.x < 0;
    }

    private void OnDisable()
    {
        GameManager.onPointScored -= Reset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onHit.Invoke();
        if (collision.collider.CompareTag("Paddle"))
        {
            //rb.velocity += new Vector2(0, transform.position.y - collision.collider.transform.position.y)*speed;
        }
        rb.velocity = rb.velocity.normalized * speed;
        foreach (var spriteRenderer in spriteRenderers)
            spriteRenderer.flipX = rb.velocity.x < 0;
    }
}
