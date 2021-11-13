using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    //[SerializeField] private float jumpCounter = 0f;
    public bool canDoubleJump = false;

    private enum MovementState { idle, running, jumping }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        //jumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);



        if (Input.GetKeyDown("space") && IsGrounded())
        {
            //jumpCounter++;
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            canDoubleJump = true;

            //if(jumpCounter <= 2)
            //{
            //    jumpCounter++;
            //    GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            //}
        }

        else if (Input.GetKeyDown("space") && canDoubleJump == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            canDoubleJump = false;
            //jumpCounter = 0;
        }


        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }


        anim.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);


    }
}