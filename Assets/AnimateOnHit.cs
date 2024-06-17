using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AnimateOnHit : MonoBehaviour
{
    public Animator animator;
    public string tagToHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(tagToHit))
            animator.SetTrigger("Hit");
    }
}
