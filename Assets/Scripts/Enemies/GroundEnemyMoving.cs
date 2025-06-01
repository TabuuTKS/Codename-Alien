using UnityEngine;

public class GroundEnemyMoving : MonoBehaviour
{

    [SerializeField] float speed = 2f;
    [HideInInspector] public bool canMove = true;
    Rigidbody2D rigidbody;
    [HideInInspector] public float dir = -1f;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 7)
        {
            dir *= -1f;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //MoveCode
        if(canMove) {
            rigidbody.linearVelocity = new Vector2(speed * dir, rigidbody.linearVelocityY);
        }
    }
}
