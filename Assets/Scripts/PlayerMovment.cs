using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private ParticleSystem part;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float dirX = 0f;
    static public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    //[SerializeField] private float jumpCounter = 0f;
    public bool canDoubleJump = false;

    private bool facingRight = true;

    static public bool speedBuff;
    static public bool slowness;



    private enum MovementState { idle, running, jumping }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        part = GetComponent<ParticleSystem>();

        facingRight = true;

        speedBuff = false;
        slowness = false;

        //part.Play();

        //jumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        if (speedBuff == true)
        {
            if(!part.isPlaying) part.Play();
            moveSpeed = 12f;
            
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        else if (slowness == true)
        {
            if (!part.isPlaying) part.Play();
            moveSpeed = 4f;

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        }

        else
        {
            moveSpeed = 7f;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            if (part.isPlaying) part.Stop();
        }


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

            if (!facingRight)
            {
                flip();
                facingRight = true;
            }
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            
            if(facingRight)
            {
                flip();
            }
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

    private void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180f, 0f);
    }
}
