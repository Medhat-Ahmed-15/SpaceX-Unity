using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationMovement : MonoBehaviour
{
    private Rigidbody spaceStationRb;
    private float planeForwordSpeed = 500;
    void Start()
    {
        spaceStationRb = GetComponent<Rigidbody>();

    }

    public void SpaceStationMove()
    {
        spaceStationRb.AddForce(Vector3.back * planeForwordSpeed);//SpaceStation Moves BackWords;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
