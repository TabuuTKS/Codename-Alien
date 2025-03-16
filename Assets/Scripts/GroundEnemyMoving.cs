using UnityEngine;

public class GroundEnemyMoving : MonoBehaviour
{

    [SerializeField] float speed = 2f;
    new Rigidbody2D rigidbody;
    float dir = -1f;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            dir *= -1f;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.linearVelocity = new Vector2(speed * dir, rigidbody.linearVelocityY);
    }
}
