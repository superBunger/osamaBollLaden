using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bollMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public KeyCode right;

    public KeyCode left;

    public KeyCode jump;

    public float force;

    public float jumpForce;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (Input.GetKey(jump))
        {
            rb2d.AddForce(Vector3.up * jumpForce);
        }
    }
}
