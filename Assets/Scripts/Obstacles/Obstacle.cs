using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.left * (GameController.Instance.Velocity * Time.deltaTime);
        
        if(transform.position.x < -30f)
            Destroy(gameObject);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
