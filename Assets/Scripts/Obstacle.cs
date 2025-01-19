using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
        
        if(transform.position.x < -30f)
            Destroy(gameObject);
    }
}
