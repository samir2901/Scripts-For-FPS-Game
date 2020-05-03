using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public AudioClip jumpSound, landingSound, movingSound, healthPickupSound, hurtSound;    
    public AudioSource audioSrc;
    public Camera fpsCamera;

    public int health = 100;
    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    Vector3 startPosition;
    bool isOnGround;
    bool isOnGroundLastFrame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isOnGround && velocity.y < 0f)
        {
            velocity.y = -2f;

        }
        
        if (isOnGround == true && isOnGroundLastFrame == false)
        {
            audioSrc.PlayOneShot(movingSound);
        }
        isOnGroundLastFrame = isOnGround;
        if (isOnGround && Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jumping");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            audioSrc.PlayOneShot(movingSound);
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion * speed * Time.deltaTime);

              

        if (isOnGround && controller.velocity.magnitude > 2f && audioSrc.isPlaying == false)
        {
            audioSrc.PlayOneShot(movingSound);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(transform.position.y < -10)
        {
            transform.position = startPosition;
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.CompareTag("Health"))
        {
            if (health < 100)
            {
                health = 100;
                audioSrc.PlayOneShot(healthPickupSound);
                Destroy(other.gameObject);
            }
        }else if (other.CompareTag("Enemy"))
        {
            audioSrc.PlayOneShot(hurtSound);
            StartCoroutine(fpsCamera.GetComponent<MouseLook>().CameraShake(0.15f,1f));
        }
    }

    
}

