using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public GameObject jumpSound;
    public GameObject landingSound;
    public AudioSource movingSound;

    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    Vector3 velocity;
    bool isOnGround;
    bool isOnGroundLastFrame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isOnGround && velocity.y < 0f)
        {
            velocity.y = -2f;
            
        }

        if(isOnGround == true && isOnGroundLastFrame == false)
        {
            Instantiate(landingSound, transform.position, Quaternion.identity);
        }
        isOnGroundLastFrame = isOnGround;
        if(isOnGround && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Instantiate(jumpSound, transform.position, Quaternion.identity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion * speed * Time.deltaTime);

        if(isOnGround && controller.velocity.magnitude > 2f && movingSound.isPlaying == false)
        {
            movingSound.Play();
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
