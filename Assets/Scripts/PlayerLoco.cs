using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerLoco : MonoBehaviour
{
    public float speed = 6f;
    public float rotateSpeed = 720f;

    Vector2 moveInput;
    Vector2 lookInput;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

    }

     void FixedUpdate()
     {
        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y));
        rb.velocity = moveDirection * speed  + new Vector3 (0, rb.velocity.y, 0);

        AudioPlayer.isWalking = moveDirection.sqrMagnitude > 0;

        if (lookInput.sqrMagnitude > 0.01f ) //prevents jittering when stick is neutral 
        {
            Vector3 lookDirection = new Vector3(lookInput.x, 0, lookInput.y).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
        }
        
        //look at flashfright to see how we configured rotation so its not inverted 
     }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
