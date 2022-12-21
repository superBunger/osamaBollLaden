using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public bool lock1Unlocked;
    public bool lock2Unlocked;
    public bool lock3Unlocked;
    public bool allLocksUnlocked;
    public int Dynamites;

    void Start()
    {
        lock1Unlocked = false;
        lock2Unlocked = false;
        lock3Unlocked = false;
        allLocksUnlocked = false;
    }

    void Update()
    {
        if (Input.GetKey(right))
        {
            rb2d.AddForce(Vector3.right * force * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            rb2d.AddForce(Vector3.left * force * Time.deltaTime);
        }
        if (Input.GetKeyDown(slam) && isSlamming == false && isGrounded == false)
        {
            rb2d.AddForce(Vector3.down * slamForce);
            isSlamming = true;
        }
        if (Input.GetKeyDown(jump) && isGrounded == true && !Input.GetKey(bigJump))
        {
            rb2d.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
        if (Input.GetKey(bigJump) && isGrounded == true)
        {
            if (Input.GetKeyDown(jump) && isGrounded == true)
            {
                rb2d.AddForce(Vector3.up * jumpForce * bigJumpForce);
                isGrounded = false;
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(1);
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
        if (Keys == 1 && collision.gameObject.tag == "Lock1")
        {
            Destroy(collision.gameObject);
            Keys -= 1;
            lock1Unlocked = true;
        }
        if (Keys == 1 && collision.gameObject.tag == "Lock2")
        {
            Destroy(collision.gameObject);
            Keys -= 1;
            lock2Unlocked = true;
        }
        if (Keys == 1 && collision.gameObject.tag == "Lock3")
        {
            Destroy(collision.gameObject);
            Keys -= 1;
            lock3Unlocked = true;
        }
        if (allLocksUnlocked == true && collision.gameObject.tag == "LockedDoor")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "CellBars")
        {
            Destroy(collision.gameObject);
        }
        if (lock1Unlocked == true && lock2Unlocked == true && lock3Unlocked == true)
        {
            allLocksUnlocked = true;
        }
        if(collision.gameObject.tag == "Dynamite")
        {
            Dynamites += 1;
            Destroy(collision.gameObject);
        }
        if(Dynamites >= 1 && collision.gameObject.tag == "KompanjonCell")
        {
            Destroy(collision.gameObject);
            Dynamites -= 1;
        }
    }
}