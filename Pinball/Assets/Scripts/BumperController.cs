using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public float multiplier;
    public float score;

    public Color color;

    private Animator animator;
    private Renderer colorRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        colorRenderer = GetComponent<Renderer>();

        colorRenderer.material.color = color;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = other.gameObject.GetComponent<Rigidbody>();
            ballRigidbody.velocity *= multiplier;

            animator.SetTrigger("Hit");
            AudioManager.Instance.PlayBumperSound(other.transform.position);
            EffectManager.Instance.PlayBumperEffect(other.transform.position);
            ScoreManager.Instance.AddScore(score);
        }
    }
}
