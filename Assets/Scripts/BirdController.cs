using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private static readonly int FlapTrigger = Animator.StringToHash("flapTrigger");

    [SerializeField] private Animator animator;
    [SerializeField] private float velocity = 3.5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            Flap();
    }

    private void FixedUpdate()
    {
        Jerk();
    }

    private void Flap()
    {
        animator.SetTrigger(FlapTrigger);
        rb.velocity = Vector2.up * velocity;
    }

    private void Jerk()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rb.velocity.y * rotationSpeed );
    }
}
