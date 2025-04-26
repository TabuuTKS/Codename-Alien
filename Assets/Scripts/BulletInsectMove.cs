using UnityEngine;

public class BulletInsectMove : MonoBehaviour
{
    enum MoveState {
        Move,
        Idle
    }

    RaycastHit2D hit2D;
    MoveState state = MoveState.Move;
    [SerializeField] float MaxInscetRange = 3f;
    [SerializeField] float MinInscetRange = .4f;
    [SerializeField] float SmoothSpeed = 5f;
    [SerializeField] GroundEnemyMoving BaseMoveScript;
    [SerializeField] LayerMask Mask;
    [SerializeField] BasicTimer waitTimer;
    [SerializeField] GameObject Bullet;

    private Vector2 dir;

    private float InscetRange = 1f;

    void Awake()
    {
        dir = new Vector2(BaseMoveScript.dir,0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(BaseMoveScript.dir,0).normalized;
        BaseMoveScript.canMove = (state == MoveState.Move) ? true : false;
        hit2D = Physics2D.Raycast(transform.position, dir, InscetRange, Mask);
        DynamicRaycast();
        DetectPlayer();
    }

    void DynamicRaycast() {
        
        if (hit2D.collider != null)
        {
            InscetRange = Mathf.Lerp(InscetRange, Mathf.Clamp(InscetRange, MinInscetRange, MaxInscetRange), SmoothSpeed * Time.deltaTime);
        }
        else {
            InscetRange = Mathf.Lerp(InscetRange, MaxInscetRange, SmoothSpeed * Time.deltaTime);
        }
        //see raycast in gameplay
        //Debug.DrawRay(transform.position, dir * InscetRange, Color.red);
    }

    void DetectPlayer() {
        if (hit2D && hit2D.collider.CompareTag("Player") && state == MoveState.Move)
        {
            state = MoveState.Idle;
            waitTimer.StartTimer();
        }
    }

    public void ShootBullit() {
        Bullet.GetComponent<Bullet>().dir = BaseMoveScript.dir;
        Bullet.transform.position = transform.position;
        Instantiate(Bullet);
        waitTimer.StopTimer();
        state = MoveState.Move;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (BaseMoveScript.dir * MaxInscetRange),transform.position.y,transform.position.z));        
    }
}
