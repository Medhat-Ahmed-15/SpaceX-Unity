using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundObjectsMovement : MonoBehaviour
{
    private Rigidbody backGroundObjectRb;
    private float planeForwordSpeed = 5000;
    void Start()
    {
        backGroundObjectRb = GetComponent<Rigidbody>();
        backGroundObjectRb.AddForce(Vector3.back * planeForwordSpeed);//background objects  Moves BackWords;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
