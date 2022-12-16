using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key;
    

    GameObject BollLaden;
    bollMovement bollScript;

    // Start is called before the first frame update
    void Start()
    {
        BollLaden = GameObject.Find("boll laden");
        bollScript = BollLaden.GetComponent<bollMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bollScript.Keys == 1) 
        {
            key.SetActive(true);
        }

    }
}
