using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private PlayerController playerControllerScript;
    private Rigidbody coinRb;
    private GameObject falcon9;

    void Start()
    {
        playerControllerScript = GameObject.Find("Falcon9").GetComponent<PlayerController>();
        coinRb = GetComponent<Rigidbody>();
        falcon9 = GameObject.Find("Falcon9");
    }

   
    void Update()
    {
        if (playerControllerScript.magnetPower == false)
        {
            transform.Translate(Vector3.back * speed);
        }
        if (playerControllerScript.magnetPower == true)
        {
            coinRb.AddForce((falcon9.transform.position - transform.position).normalized * 100);
           
        }
    }


}
