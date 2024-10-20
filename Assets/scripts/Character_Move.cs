using UnityEngine;

public class Character_Move : MonoBehaviour
{
    public CharacterController controller;  
    public float speed = 6f;                
    public float gravity = -9.81f;          
    public float jumpHeight = 2f; 
    Vector3 velocity;                       
    bool isGrounded;                      

    public Transform groundCheck;          
    public float groundDistance = 0.4f;



    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        
        Vector3 move = transform.right * x + transform.forward * z;       
        controller.Move(move * speed * Time.deltaTime);

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }       
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }


}
