using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private static readonly int FlapTrigger = Animator.StringToHash("flapTrigger");

    public static Action OnLost;

    [SerializeField] private Animator animator;
    [SerializeField] private float velocity = 3.5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform startPosition;

    private Rigidbody2D rb;

    private bool _isActive;

    private bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;

            rb.simulated = _isActive;

            if (value)
                return;

            ResetPosition();
            OnLost?.Invoke();
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    public void StartGame()
    {
        IsActive = true;
    }

    private void Update()
    {
        if (!_isActive)
            return;

        if (Input.GetKeyDown("space"))
            Flap();
    }

    private void FixedUpdate()
    {
        ProcessRotation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Obstacles"))
            return;

        IsActive = false;
    }

    private void ResetPosition()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
        rb.velocity = Vector2.zero;
    }

    private void Flap()
    {
        animator.SetTrigger(FlapTrigger);
        rb.velocity = Vector2.up * velocity;
    }

    private void ProcessRotation()
    {
        if (!_isActive)
            return;

        transform.rotation = Quaternion.Euler(0f, 0f, rb.velocity.y * rotationSpeed);
    }
}