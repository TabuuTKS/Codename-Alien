using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 40f;
    [SerializeField] AudioSource walk, run, jump, hurt;
    [SerializeField] LevelEvents levelEvents;

    //this access the Inputs file which has all inputs set.
    public Inputs inputs;
    public AudioSource coin;

    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rigidbody;

    private float xAxis;
    private bool isMoving = false;
    private bool canMove = true;
    private bool isJumping = false;
    public bool isCrouching = false;
    public float Health = 100f;

    //these values i got after a lot of experiment
    private float HurtStrengthX = 1500f;
    private float HurtStrengthY = 100f;
    private float bounceStrength = 500f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        walk.Stop();
        run.Stop();
    }

    private void Awake() {
        //to use new input system. its best to use input object and controller in awake.
        inputs = new Inputs();
        controller = GetComponent<CharacterController2D>();
    }

    private void OnEnable()
    {
        /*
            here += are used to add functionality to actions of new input system.
            ctx is a context which has some action properties. is used to assign function.
            and => finallay assign the function short handly.
        */
        inputs.Player.Move.performed += ctx => xAxis = ctx.ReadValue<float>();
        inputs.Player.Move.canceled += ctx => xAxis = 0;
        inputs.Player.Jump.performed += ctx => isJumping = (Time.timeScale != 0) ? true : false;
        inputs.Player.Crouch.performed += ctx => isCrouching = true;
        inputs.Player.Crouch.canceled += ctx => isCrouching = false;
        inputs.Player.Enable();
    }
    private void OnDisable()
    {
        inputs.Player.Disable();
    }

    public void SetXAxis(float value) => xAxis = value;
    public void TriggerJump() => isJumping = true;
    public void setCrouch(bool value) => isCrouching = value; 
    
    void Update()
    {
        PlayerInput();
        Audio();
        Animate();

        if (levelEvents.MobilePort && Time.timeScale == 0)
        {
            xAxis = 0;
        }

        //Debug Hurt
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hurt();
        }*/
    }

    void PlayerInput() {
        if (isJumping && !isCrouching && canMove)
        {
            animator.SetTrigger("jump");
            jump.Play();
        }
        if (isCrouching && canMove)
        {
            isJumping = false;
        }
    }

    void Animate()
    { 
        isMoving = (xAxis != 0) ? true : false;

        animator.SetFloat("move", Mathf.Abs(xAxis));
        animator.SetBool("crouch", isCrouching);
    }

    private void Audio()
    {
        if (xAxis != 0f && controller.m_Grounded && Time.timeScale != 0) {
            if (!run.isPlaying && !isCrouching)
            {
                run.Play();
            }
            else if (!walk.isPlaying && isCrouching)
            {
                walk.Play();
            }
        }
        else
        {
            run.Pause();
            walk.Pause();
        }
    }

    public void GravitySwitching() {
        controller.m_JumpForce *= -1;
        rigidbody.gravityScale *= (-1);
        transform.Rotate(new Vector3(0,0,180));
        transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
    }
    private void FixedUpdate()
    {
        controller.Move(xAxis * Speed * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }

    public void Hurt(int Damage)
    {
        levelEvents.PH3_Percentage -= Damage;
        animator.SetTrigger("hurt");
        hurt.Play();
        if (controller.m_Grounded)
        {
            rigidbody.AddForceX(transform.localScale.normalized.x * HurtStrengthX);
        }
        else
        {
            Vector2 force = new Vector2(transform.localScale.normalized.x * HurtStrengthX, HurtStrengthY);
            rigidbody.AddForce(force);
        }
    }

    public void Dead()
    {
        DisableMovements();
        animator.SetBool("dead", canMove);
    }
    public void DisableMovements()
    {
        canMove = false;
        rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void HitEnemyUsingJump()
    {
        rigidbody.AddForceY(bounceStrength * rigidbody.gravityScale);
    }
}
