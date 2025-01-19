using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private static readonly int FlapTrigger = Animator.StringToHash("flapTrigger");

    [SerializeField] private Animator animator;
    [SerializeField] private float velocity = 3.5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform startPosition;

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
        ProcessRotation();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Obstacles"))
            return;
        
        Debug.Log(other.gameObject.name);
        ResetPosition();
    }

    private void ResetPosition()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
        rb.velocity = Vector2.zero;
        rb.simulated = false;
    }
    
    private void Flap()
    {
        animator.SetTrigger(FlapTrigger);
        rb.velocity = Vector2.up * velocity;
    }

    private void ProcessRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rb.velocity.y * rotationSpeed );
    }
}
