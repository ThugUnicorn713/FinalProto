using UnityEngine;
using UnityEngine.InputSystem;

public enum AnimalState
{
    Human,
    Half,
    Lycan
}
public class PlayerLoco : MonoBehaviour
{
    public AnimalState transformState = AnimalState.Human;

    public AudioSource lycanRunSource;
    public AudioClip lycanRun;

    public float speed = 6f;
    public float halfSpeed = 3f;
    public float lycanSpeed = 10f;
    public float crouchHeight = 0.5f;
    public float currentHeight;

    public float rotateSpeed = 720f;

    Vector2 moveInput;
    Vector2 lookInput;

    public GameObject deadAnimal2;

    public Rigidbody rb;

    private bool xPressed = false;
    private bool oPressed = false;
    private bool canMove = true;

    private string lastbutton = "O";

    private float ogHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        deadAnimal2.SetActive(false);

        ogHeight = transform.localScale.y;

    }

    void Update()
    {

        switch (transformState)
        {
            case AnimalState.Half:
                
                if (xPressed && moveInput.sqrMagnitude > 0)
                {
                    canMove = true;
                    SetHalfSpeed();
                    ResetButtons();
                }
                else
                {
                    canMove = false;
                }

            break;

            case AnimalState.Lycan:

               if (moveInput.sqrMagnitude > 0)
               {
                    if ((lastbutton == "X" && oPressed) || (lastbutton == "O" && xPressed) && moveInput.sqrMagnitude > 0)
                    {
                        canMove = true;
                        SetLycanMovement(crouchHeight);
                        lastbutton = xPressed ? "X" : "O";
                        ResetButtons();
                    }
                    else
                    {
                        canMove = false;
                       
                        //SetToOGHeight(ogHeight);
                    }
               }
               else
               {
                    canMove = false;
               }

            break;

                default:
                    
                    canMove = true;

                break;
        }

       
    }
    
        
    

    void FixedUpdate()
    {
        if (lookInput.sqrMagnitude > 0.01f) //prevents jittering when stick is neutral 
        {
            Vector3 lookDirection = new Vector3(lookInput.x, 0, lookInput.y).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
        }

        if (!canMove)  // Skip movement if conditions are not met
        {
            AudioPlayer.isWalking = false;
            return;
        } 

        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y));
        rb.velocity = moveDirection * speed  + new Vector3 (0, rb.velocity.y, 0);

        AudioPlayer.isWalking = moveDirection.sqrMagnitude > 0;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }


    public void OnXPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            xPressed = true;

        }
    }

    public void OnOPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            oPressed = true;
        }
    }

    public void SetHalfSpeed()
    {
        speed = halfSpeed;
    }

    public void SetLycanMovement(float newHeight)
    {
        if (!lycanRunSource.isPlaying)  // Check if the sound is not already playing
        {
            lycanRunSource.PlayOneShot(lycanRun);
        }

        speed = lycanSpeed;
        Vector3 scale = transform.localScale;
        scale.y = newHeight;
        transform.localScale = scale;
    }

    public void SetToOGHeight(float newHeight)
    {
        lycanRunSource.Stop();
        Vector3 scale = transform.localScale;
        scale.y = newHeight;
        transform.localScale = scale;
    }

    private void ResetButtons()
    {
        xPressed = false;
        oPressed = false;
    }

    
}
