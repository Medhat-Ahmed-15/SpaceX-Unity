using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupIndicatorBehaviour : MonoBehaviour
{
    private GameObject falcon9;
    void Start()
    {
        falcon9 = GameObject.Find("Falcon9");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = falcon9.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("FireBall") || other.gameObject.CompareTag("SwampBall"))
        {
            Destroy(other.gameObject);
            
        }
    }
}
