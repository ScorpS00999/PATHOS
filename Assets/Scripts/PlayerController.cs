using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Player Attribute : ")]
    [SerializeField] private float mSpeed = 0.1f;
    [SerializeField] private float jumpForce = 5f;

    private Vector2 mMoveVector;
    private RigidBody2D rgbd2D;

    void Reset()
    {
        //rgbd2D = GetComponent
    }
    void FixedUpdate()
    {
        Move();
    }

    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        mMoveVector = context.ReadValue<Vector2>();
    }
     private void Move()
    {
        // Find the direction
        Vector2 direction = new Vector2(mMoveVector.x, mMoveVector.y).normalized;

        if (direction.magnitude >= 1.0f)
        {
            rgbd2D.position += direction * mSpeed;
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

}
