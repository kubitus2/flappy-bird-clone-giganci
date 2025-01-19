using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private static readonly int FlapTrigger = Animator.StringToHash("flapTrigger");

    public static Action OnLost;
    public static Action OnFlap;

    [Header("Animator")] 
    [SerializeField] private Animator animator;
    
    [Header("Movement")] 
    [SerializeField] private float velocity = 3.5f;

    [Header("Starting position")] 
    [SerializeField] private Transform startPosition;

    private Rigidbody2D _rb;
    private bool _isActive;

    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;

            _rb.simulated = _isActive;

            if (value)
                return;

            ResetPosition();
            OnLost?.Invoke();
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.simulated = false;
    }

    public void StartGame()
    {
        IsActive = true;
    }

    private void Update()
    {
        if (!_isActive)
            return;
        
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            Flap();
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
        _rb.velocity = Vector2.zero;
    }

    private void Flap()
    {
        animator.SetTrigger(FlapTrigger);
        _rb.velocity = Vector2.up * velocity;
        OnFlap?.Invoke();
    }
}