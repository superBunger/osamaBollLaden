using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField]
    public float force;
    public Rigidbody2D rb2d;
    float timer;
    [SerializeField]
    //Projectile
    public GameObject player;
    public float speed;
    private float distance;
    public bool isGrounded;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            rb2d.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }

        // Jaga spelaren - Alexander
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();


        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward);

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
    }
}