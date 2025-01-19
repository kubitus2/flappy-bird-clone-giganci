using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotationHandler : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    
    private BirdController _birdController;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _birdController = GetComponent<BirdController>();
    }

    private void FixedUpdate()
    {
        if (!_birdController.IsActive)
            return;
        transform.rotation = Quaternion.Euler(0f, 0f, _rb.velocity.y * rotationSpeed);
    }
}