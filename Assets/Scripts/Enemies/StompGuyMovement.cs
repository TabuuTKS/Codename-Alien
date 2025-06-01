using UnityEngine;

public class StompGuyMovement : MonoBehaviour
{
    enum StompState { Idle, Down, Up }
    StompState state;
    Rigidbody2D rigidbody2D;
    RaycastHit2D hit2D;
    [SerializeField] float StompSpeed = 2.0f;
    Vector2 initPos;
    Animator animator;
    [SerializeField] LayerMask PlayerMask;
    [SerializeField] float RaycastLenght = 1f;
    Player player;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        initPos = rigidbody2D.position;
        state = StompState.Idle;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void FixedUpdate()
    {
        Move();
        DetectPlayer();

    }

    void Move()
    {
        switch (state)
        {
            case StompState.Idle:
                rigidbody2D.linearVelocity = Vector2.zero;
                break;

            case StompState.Down:
                rigidbody2D.linearVelocity = new Vector2(0, -StompSpeed);
                animator.SetTrigger("attack");
                break;

            case StompState.Up:
                rigidbody2D.linearVelocity = new Vector2(0, (StompSpeed/2));
                break;
        }
    }

    void DetectPlayer() {
        // Raycast to detect the player
        hit2D = Physics2D.Raycast(transform.position, Vector2.down, RaycastLenght, PlayerMask);
        if (hit2D && hit2D.collider.CompareTag("Player") && !(state == StompState.Up) && !player.isCrouching)
        {
            state = StompState.Down;
        }

        // Check if object has reached initPos to reset state
        if (Vector2.Distance(rigidbody2D.position, initPos) < 0.1f && state == StompState.Up)
        {
            state = StompState.Idle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state = StompState.Up;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * RaycastLenght);
    }
}
