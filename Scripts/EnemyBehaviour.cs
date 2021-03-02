using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 100;
    private GameManager gameManger;
    public ParticleSystem damagePlane;
    public AudioSource audioSource;
    private GameObject falcon9;
    void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        falcon9 = GameObject.Find("Falcon9");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Falcon9"))
        {
            
            gameManger.GameOver();
            audioSource.Play();
            damagePlane.Play();
            falcon9.SetActive(false);
           
        }
    }
}
