using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    //walk speed
    private float w_speed = 0.05f;
    //rotation speed
    private float rot_speed = 1.0f;

    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true; //indicate that we are in the ground
    }

    void movementControl(string state)
    {
        switch (state)
        {
            case "WalkingForward":
                anim.SetBool("is_walking", true);
                anim.SetBool("is_running", false);
                anim.SetBool("is_back", false);
                break;
            case "WalkingBackward":
                anim.SetBool("is_back", true);
                anim.SetBool("is_walking", false);
                anim.SetBool("is_running", false);
                break;
            case "Running":
                anim.SetBool("is_running", true);
                //anim.SetBool("is_walking", false);
                //anim.SetBool("is_back", false);
                break;
            default:
                anim.SetBool("is_running", false);
                anim.SetBool("is_walking", false);
                anim.SetBool("is_back", false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            //moving forward and backward
            if (Input.GetKey(KeyCode.W))
            {
                speed = w_speed;
                movementControl("WalkingForward");

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = w_speed + 10.0f;
                    movementControl("Running");
                } else
                {
                    speed = w_speed;
                    movementControl("WalkingForward");
                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                speed = w_speed;
                movementControl("WalkingBackward");
            }
            else
            {
                movementControl("Idle");
            }
            //moving right and left
            if (Input.GetKey(KeyCode.A))
            {
                rotSpeed = rot_speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rotSpeed = rot_speed;
            }
            else
            {
                rotSpeed = 0;
            }

            var z = Input.GetAxis("Vertical") * speed;
            var y = Input.GetAxis("Horizontal") * rotSpeed;
            transform.Translate(0, 0, z);
            transform.Rotate(0, y, 0);
            //jumping function
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                anim.SetTrigger("is_jump");
                rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
                isGrounded = false;
            }
        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
