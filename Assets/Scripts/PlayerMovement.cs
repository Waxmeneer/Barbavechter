using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    public bool isFacingRight = true;
    public Animator animator;
    public bool canMove;
    public bool justHit = false;

    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private string horizontalAxis;
    private KeyCode jumpButton;
    public KeyCode attackButton;
    public KeyCode rangedAttackButton;

    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        SetControls();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        canMove = true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalAxis);

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (canMove)
        {
            if (Input.GetKeyDown(jumpButton) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                //animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (canMove & !justHit)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnLanding()
    {

    }

    public IEnumerator GotHit(float hitStun)
    {
        justHit = true;
        yield return new WaitForSeconds(hitStun);
        justHit = false;
        yield return null;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    private void SetControls()
    { 
        if (GetComponent<PlayerHealth>().player == 1)
        {
            horizontalAxis = "Horizontal";
            jumpButton = KeyCode.M;
            attackButton = KeyCode.Period;
            rangedAttackButton = KeyCode.Comma;
        }
        if (GetComponent<PlayerHealth>().player == 2)
        {
            horizontalAxis = "Player2Horizontal";
            jumpButton = KeyCode.Space;
            attackButton = KeyCode.Q;
            rangedAttackButton = KeyCode.E;
        }
        if (GetComponent<PlayerHealth>().player == 3)
        {
            horizontalAxis = "Player3Horizontal";
            jumpButton = KeyCode.Keypad0;
            attackButton = KeyCode.Keypad7;
            rangedAttackButton = KeyCode.Keypad9;
        }
        if (GetComponent<PlayerHealth>().player == 4)
        {
            horizontalAxis = "Player4Horizontal";
            jumpButton = KeyCode.Y;
            attackButton = KeyCode.U;
            rangedAttackButton = KeyCode.I;
        }
    }

}