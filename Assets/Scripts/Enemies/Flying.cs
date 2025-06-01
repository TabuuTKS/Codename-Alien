using UnityEngine;

public class Flying : MonoBehaviour
{
    public float PathSize = 5f;
    float Min, Max;
    [SerializeField] float speed = 2f;
    Rigidbody2D rigidbody;
    enum flyingState
    {
        UP,
        DOWN
    }

    flyingState state;
    void Start()
    {
        Min = transform.position.y - PathSize;
        Max = transform.position.y + PathSize;
        state = flyingState.UP;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        changeDir();
    }

    private void Move()
    {
        if (state == flyingState.UP)
        {
            rigidbody.linearVelocity = new Vector2(0, speed);
        }
        else if (state == flyingState.DOWN)
        {
            rigidbody.linearVelocity = new Vector2(0, -speed);
        }
    }

    void changeDir()
    {
        if (transform.position.y >= Max)
        {
            state = flyingState.DOWN;
        }
        else if (transform.position.y <= Min)
        {
            state = flyingState.UP;
        }
    }
    private void OnDrawGizmosSelected()
    {
        //variables
        Min = transform.position.y - PathSize;
        Max = transform.position.y + PathSize;
        Vector3 minpos = new Vector3(transform.position.x, Min, transform.position.z);
        Vector3 maxpos = new Vector3(transform.position.x, Max, transform.position.z);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(minpos,maxpos);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(maxpos, .1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(minpos, .1f);
    }
}
