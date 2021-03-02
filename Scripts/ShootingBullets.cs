using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public float bulletSpeed=20.2f;
    public AudioSource audioSource;
    public ParticleSystem damagePlane;
    private GameManager gameManger;
    void Start()
    {
        StartCoroutine(DestroyBullets());
        audioSource = GetComponent<AudioSource>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            audioSource.Play();
            damagePlane.Play();
            gameManger.CalculateScore();
        }
    }
    void Update()
    {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
            
    }

    IEnumerator DestroyBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }

    }
}
