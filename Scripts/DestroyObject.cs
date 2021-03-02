using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
  
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SensorWall"))
            {
            Destroy(gameObject);//any object contains this script  will be destroyed  whenever it hits the sensor wall
            }
            
    }
}
