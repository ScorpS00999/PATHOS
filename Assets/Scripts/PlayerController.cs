using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Player Attribute : ")]
    [SerializeField] private float mSpeed = 0.1f;
    [SerializeField] float currentSpeed;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] float bounceForce = 10f;

    private int maxJump = 1;
    private int jumpNumber = 0;

    bool jumpPressed = false;
    bool canJump = true;

    private Vector2 mMoveVector;
    private Rigidbody2D rgbd2D;

    bool isOnBounce = false;

    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        currentSpeed = mSpeed;
    }


    void FixedUpdate()
    {
        Move();

        if (jumpPressed && canJump)
        {
            Jump();
        }

        if (isOnBounce)
        {
            Bounce();
        }
    }

    

    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        mMoveVector = context.ReadValue<Vector2>();
    }

    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        // Read jump input (pressed or released)
        if (context.performed && canJump)
        {

            if (jumpNumber < maxJump)
            {
                jumpPressed = true;
                jumpNumber += 1;
                //m_Animator.SetBool("isJumpin", true);
            }
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }



    


    private void Move()
    {
        // Find the direction
        Vector2 direction = new Vector2(mMoveVector.x, mMoveVector.y).normalized;

        if (direction.magnitude >= 1.0f)
        {
            print(direction);
            rgbd2D.position += direction * currentSpeed;
            if (direction.x < 0)
            {
                //spriteRenderer.flipX = true;
            }
            else if (direction.x > 0)
            {
                //spriteRenderer.flipX = false;
            }
        }
    }



    public void Jump()
    {
        // Apply jump force if grounded
        rgbd2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpPressed = false;
        //m_Animator.SetBool("IsOnGround", false);

    }

    public void Bounce()
    {

        //Animator mushroomAnimator = mushroom.GetComponent<Animator>();

        //if (mushroomAnimator != null)
        //{
        //    // Activer l'animation du rebond sur le champignon
        //    mushroomAnimator.SetBool("hasBounce", true);
        //
        //    // R�initialise la vitesse verticale � 0 avant d'ajouter la force du rebond
        //    rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, 0f);
        //    rgbd2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        //
        //    mushroomAnimator.SetBool("hasBounce", false);
        //}
        //else
        //{
        //    Debug.LogWarning("Animator non trouv� sur l'objet Mushroom");
        //}


        //---------------------------------------------------

        //mushroomAnimator.SetBool("hasBounce", true);

        // R�initialise la vitesse verticale � 0 avant d'ajouter la force du rebond
        rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, 0f);
        rgbd2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

        //mushroomAnimator.SetBool("hasBounce", false);
    }









    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpNumber = 0;
            canJump = true;
        }
        if (collision.gameObject.CompareTag("objBounce"))
        {
            isOnBounce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnBounce = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ralentissement"))
        {
            currentSpeed = 0.01f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentSpeed = mSpeed;
    }

}
