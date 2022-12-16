using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bollMovement : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb2d;
    public KeyCode right;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode bigJump;
    public KeyCode slam;
    public int Keys;
    public float force;
    public float jumpForce;
    public float bigJumpForce;
    public float slamForce;
    public bool isGrounded;
    public bool isSlamming;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(right))
        {
            rb2d.AddForce(Vector3.right * force * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            rb2d.AddForce(Vector3.left * force * Time.deltaTime);
        }

        if (Input.GetKeyDown(jump) && isGrounded == true)
        {
            rb2d.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
        if(Input.GetKey(slam) && isSlamming == false && isGrounded == false)
        {
            rb2d.AddForce(Vector3.down * slamForce);
            isSlamming = true;
        }

        if (Input.GetKey(bigJump) && isGrounded == true && timer > 5)
        {
            rb2d.AddForce(Vector3.up * bigJumpForce);
            isGrounded = false;
            timer = 0;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isSlamming = false;
        }
        if (collision.gameObject.tag == "Killeble")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Key")
        {
            Keys += 1;
            Destroy(collision.gameObject);
        }
    }
}
