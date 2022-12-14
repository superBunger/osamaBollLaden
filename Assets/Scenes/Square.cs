using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField]
    public float force;
    public Rigidbody2D rb2d;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
        timer += Time.deltaTime;
        if (timer < 4)
        {
            rb2d.AddForce(Vector3.right * force * Time.deltaTime);
        }
        else if (timer > 4 && timer < 10)
        {
            rb2d.AddForce(Vector3.left * force * Time.deltaTime);

        }
        else if (timer > 10)
        {
            timer = 0;
        }
    }
}