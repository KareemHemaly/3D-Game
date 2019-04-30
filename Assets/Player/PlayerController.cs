using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static Animator anim;
    public float speed = 6.0f;
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey("left shift"))
        {
            anim.SetBool("is_running", true);
            speed = 14.0f;

            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("is_jumping");
            }
        }
        else
        {
            speed = 6.0f;
            anim.SetBool("is_running", false);
        }

        if (translation > 0)
        {
            anim.SetBool("is_walking", true);

        } else if(translation < 0)
        {
            anim.SetBool("is_back", true);

        }
        else
        {
            anim.SetBool("is_running", false);
            anim.SetBool("is_walking", false);
            anim.SetBool("is_back", false);

            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("is_jump");
            }
        }

    } // End of update function
}
