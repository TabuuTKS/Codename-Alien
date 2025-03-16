using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 40f;
    [SerializeField] AudioSource walk, run, jump, hurt;
    [SerializeField] LevelEvents levelEvents;
    public AudioSource coin;

    private CharacterController2D controller;
    private Animator animator;
    private new Rigidbody2D rigidbody;

    private float xAxis;
    private bool isMoving = false;
    private bool isJumping = false;
    public bool isCrouching = false;
    public float Health = 100f;

    //these values i got after a lot of experiment
    private float HurtStrengthX = 1500f;
    private float HurtStrengthY = 100f;
    private float bounceStrength = 500f;
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        walk.Stop();
        run.Stop();
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && !isCrouching)
        {
            isJumping = true;
            animator.SetTrigger("jump");
            jump.Play();
        }
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }
        Audio();
        Animate();

        //Debug Hurt
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hurt();
        }*/
    }

    void Animate()
    { 
        isMoving = (xAxis != 0) ? true : false;

        animator.SetFloat("move", Mathf.Abs(xAxis));
        animator.SetBool("crouch", isCrouching);
    }

    private void Audio()
    {
        if (xAxis != 0f && controller.m_Grounded) {
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
        animator.SetBool("dead", true);
    }
    public void DisableMovements()
    {
        animator.enabled = false;
        Speed = 0;
        isCrouching = true;
    }

    public void HitEnemyUsingJump()
    {
        rigidbody.AddForceY(bounceStrength);
    }
}
