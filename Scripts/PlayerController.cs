using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    /*public float speed = 10f;
    float pitch;
    float roll;*/



    private Rigidbody planexRb;
    public bool engineIsOn;
    public bool planeIsFlying;
    public bool pressSpaceKeyOnce;
    public bool pressEKeyOnce;
    public bool magnetPower;
    public float planeSideWaysSpeed = 50;
    public bool switchControl;



    private GameObject planeX;
    public GameObject leftGun;
    public GameObject rightGun;
    public GameObject bulletPrefab;
    public GameObject fireBall;
    public GameObject swampBall;
    public GameObject invisibilityPower;


    public AudioClip laserAudio;
    public AudioClip coinSound;
    public AudioClip engineDown;
    public AudioClip planeEngineIsOn;
    public AudioClip planehitOnce;
    public AudioClip magnetSound;
    public AudioClip invisibilitySound;
    public AudioSource audioSource;


    public ParticleSystem leftFireEngineParticle;
    public ParticleSystem rightFireEngineParticle;
    public ParticleSystem glitterCoin;
    public ParticleSystem engineSmoke;

    private SpaceStationMovement spaceStationMovement;
    private GameManager gameManger;


    void Start()
    {

        planexRb = GetComponent<Rigidbody>();
        planeX = GameObject.Find("PlaneX");
        audioSource = GetComponent<AudioSource>();
        spaceStationMovement = GameObject.Find("SpaceStation").GetComponent<SpaceStationMovement>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        pressSpaceKeyOnce = true;
        pressEKeyOnce = true;
        magnetPower = false;
        gameObject.SetActive(true);



    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound, 2);
            glitterCoin.Play();
            gameManger.CalculateDollars();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Magnet"))
        {
            audioSource.PlayOneShot(magnetSound, 2);
            Destroy(other.gameObject);
            magnetPower = true;
            gameManger.MagnetCountDown();
        }

        if (other.gameObject.CompareTag("InvisibilityBall"))
        {
            audioSource.PlayOneShot(invisibilitySound, 2);
            Destroy(other.gameObject);
            invisibilityPower.gameObject.SetActive(true);
            gameManger.ShieldCountDown();
        }
    }



    public void PlaneIsFlying()
    {
        if (Input.GetKey(KeyCode.E) && pressEKeyOnce == true)
        {
            engineIsOn = true;
            leftFireEngineParticle.Play();
            rightFireEngineParticle.Play();
            audioSource.PlayOneShot(planeEngineIsOn, 1);
            pressEKeyOnce = false;
        }
        if (engineIsOn)
        {
            if (Input.GetKey("space") && pressSpaceKeyOnce == true)
            {
                planeIsFlying = true;
                spaceStationMovement.SpaceStationMove();
                audioSource.Play();
                pressSpaceKeyOnce = false;
            }

        }
    }



    void FixedUpdate()
    {
        if (gameManger.isGameActive == true)
        {
            PlaneIsFlying();
            float upAndDown = Input.GetAxisRaw("Vertical");
            if (engineIsOn == true && planeIsFlying == true)
            {
                if (switchControl == false)
                {
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        planexRb.AddRelativeForce(Vector3.left * planeSideWaysSpeed);//plane moves right
                    }


                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        planexRb.AddRelativeForce(Vector3.right * planeSideWaysSpeed);//plane moves left
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        planexRb.AddRelativeTorque(Vector3.forward * planeSideWaysSpeed);//plane moves left
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        planexRb.AddRelativeTorque(Vector3.back * planeSideWaysSpeed);//plane moves left
                    }

                    planexRb.AddRelativeForce(Vector3.up * planeSideWaysSpeed * upAndDown);//plane goes up and down

                }

                if (switchControl == true)
                {
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        planexRb.AddRelativeForce(Vector3.right * planeSideWaysSpeed);//plane moves right
                    }


                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        planexRb.AddRelativeForce(Vector3.left * planeSideWaysSpeed);//plane moves left
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        planexRb.AddRelativeTorque(Vector3.back * planeSideWaysSpeed);//plane moves left
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        planexRb.AddRelativeTorque(Vector3.forward * planeSideWaysSpeed);//plane moves left
                    }

                    planexRb.AddRelativeForce(Vector3.down * planeSideWaysSpeed * upAndDown);//plane goes up and down
                }

                if (Input.GetKey(KeyCode.Z))
                {
                    Instantiate(bulletPrefab, leftGun.transform.position, leftGun.transform.rotation);
                    Instantiate(bulletPrefab, rightGun.transform.position, rightGun.transform.rotation);
                    audioSource.PlayOneShot(laserAudio, 1);
                }
            }



            BorderPosx();
            BorderPosy();
            BorderPosz();


        }

    }

    private void BorderPosx()
    {
        if (transform.position.x > 65)
        {
            transform.position = new Vector3(65, transform.position.y, transform.position.z);
            Debug.Log("RETURN TO AREA");
        }
        if (transform.position.x < -65)
        {
            transform.position = new Vector3(-65, transform.position.y, transform.position.z);
            Debug.Log("RETURN TO AREA");
        }
    }

    private void BorderPosy()
    {
        if (transform.position.y > 65)
        {
            transform.position = new Vector3(transform.position.x, 65, transform.position.z);
            Debug.Log("RETURN TO AREA");
        }
        if (transform.position.y < -65)
        {
            transform.position = new Vector3(transform.position.x, -65, transform.position.z);
            Debug.Log("RETURN TO AREA");
        }

    }

    private void BorderPosz()
    {
        if (transform.position.z > 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 20);
            Debug.Log("RETURN TO AREA");
        }
        if (transform.position.z < -20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -20);
            Debug.Log("RETURN TO AREA");
        }

    }

    public void EngineDown()
    {
        engineSmoke.Play();
        audioSource.PlayOneShot(engineDown, 5);
        leftFireEngineParticle.Pause();
        rightFireEngineParticle.Pause();

    }

    public void PlaneHitOnce()
    {
        audioSource.PlayOneShot(planehitOnce, 5);

    }

}

