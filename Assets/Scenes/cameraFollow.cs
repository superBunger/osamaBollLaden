using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform followTransform;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x, 0, this.transform.position.z);
    }
}
