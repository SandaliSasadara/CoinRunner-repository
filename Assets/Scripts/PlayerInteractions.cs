
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float fallLimitY = -10f;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Goal"))
        {
            GameManager.Instance.LevelComplete();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}

