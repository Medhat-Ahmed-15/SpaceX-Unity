using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private PlayerController playerControllerScript;
    private GameManager gameManger;
    private GameObject falcon9;
    private AudioSource audioSource;
    public AudioClip dangerAlarm;
    private void Start()
    {
        playerControllerScript = GameObject.Find("Falcon9").GetComponent<PlayerController>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        falcon9 = GameObject.Find("Falcon9");
    }

     private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Falcon9"))
        {
            gameManger.CalculateLives();

        }
       
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed);

        float distanceBetweenPArticleAndFalcon9 = Vector3.Distance(falcon9.transform.position, transform.position);

        if ((distanceBetweenPArticleAndFalcon9 < 25 || distanceBetweenPArticleAndFalcon9 < 25) && gameManger.isGameActive==true)
        {

           // audioSource.PlayOneShot(dangerAlarm,0.5f); hal @aseeb el sensor wla la2
        }
    }

   
}
