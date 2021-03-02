using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject[] backCamera;
    public AudioSource audioSource;
   
   
    private ParticlesMovement particlesMovement;
    private bool planeIsFlying;
    private GameManager gameManger;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger.isGameActive == true)
        {
            if (Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.B))
            {
                transform.position = backCamera[1].transform.position;
                transform.rotation = backCamera[1].transform.rotation;
            }
            else
            {
                transform.position = backCamera[0].transform.position;
                transform.rotation = backCamera[0].transform.rotation;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = backCamera[2].transform.position;
                transform.rotation = backCamera[2].transform.rotation;
            }

        }
    }
}