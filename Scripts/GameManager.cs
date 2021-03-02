using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Material[] skyBox;
    private int index;
    private int swap;
    public bool isGameActive;
    private PlayerController playerController;
    public AudioSource audioSource;
    public AudioClip gameOverClip;
    public AudioClip buttonClick;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveText;
    private int scoreCount;
    public int liveCount;
    private PlayerController playerControllerScript;
    public int magnetCountDown;
    public int shieldCountDown;
    public int dollarCount;
    public TextMeshProUGUI magnetText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI dollarText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private GameObject gameMenu;
    private SpawnManger1 spawnManger;
    public GameObject invertedText;
    public GameObject[] memeTexts;
    public GameObject pauseButton;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        index = 0;
        swap = 0;
        isGameActive = false;
        playerController = GameObject.Find("Falcon9").GetComponent<PlayerController>();
        playerControllerScript = GameObject.Find("Falcon9").GetComponent<PlayerController>();
        scoreCount = 0;
        dollarCount = 0;
        liveCount = 5;
        magnetCountDown = 10;
        shieldCountDown = 10;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameMenu = GameObject.Find("GameMenu");
        spawnManger = GameObject.Find("SpawnManger").GetComponent<SpawnManger1>();
        
    }


    public IEnumerator MagnetPowersCountDown()
    {
        for (int i = 0; i <= 10; i++)
        {
            yield return new WaitForSeconds(1);
            magnetCountDown = magnetCountDown - 1;
            magnetText.text = "MAGNET TIMER: " + magnetCountDown;

            if (magnetCountDown == 5)
            {
                magnetText.color = Color.red;
            }

            if (magnetCountDown == 0)
            {
                playerControllerScript.magnetPower = false;
                magnetText.color = Color.green;
                magnetCountDown = 11;
            }

        }

    }

    public IEnumerator ShieldPowersCountDown()
    {
        for (int i = 0; i <= 10; i++)
        {
            yield return new WaitForSeconds(1);
            shieldCountDown = shieldCountDown - 1;
            shieldText.text = "SHIELD TIMER: " + shieldCountDown;

            if (shieldCountDown == 5)
            {
                shieldText.color = Color.red;
            }

            if (shieldCountDown == 0)
            {
                playerControllerScript.invisibilityPower.gameObject.SetActive(false);
                shieldText.color = Color.green;
                shieldCountDown = 11;
            }

        }
    }

    public IEnumerator MemeTextCountDown1()
    {
        yield return new WaitForSeconds(5);
        memeTexts[0].gameObject.SetActive(false);
    }

    public IEnumerator MemeTextCountDown2()
    {
        yield return new WaitForSeconds(5);
        memeTexts[1].gameObject.SetActive(false);
    }

    public IEnumerator MemeTextCountDown3()
    {
        yield return new WaitForSeconds(5);
        memeTexts[2].gameObject.SetActive(false);
    }

    public void StartEasyGame()
    {
        audioSource.Stop();
        spawnManger.InvokeGoodAndBadObjects(2, 5);
        audioSource.PlayOneShot(buttonClick, 2);
        isGameActive = true;
        gameMenu.SetActive(false);
    }

    public void StartMediumGame()
    {
        audioSource.Stop();
        spawnManger.InvokeGoodAndBadObjects(1, 0.5f);
        audioSource.PlayOneShot(buttonClick, 2);
        isGameActive = true;
        gameMenu.SetActive(false);
    }

    public void StartHardGame()
    {
        audioSource.Stop();
        spawnManger.InvokeGoodAndBadObjects(5, 0.07f);
        audioSource.PlayOneShot(buttonClick, 2);
        isGameActive = true;
        gameMenu.SetActive(false);
    }

    public void GameOver()
    {
        isGameActive = false;
        playerController.audioSource.Pause();
        audioSource.PlayOneShot(gameOverClip, 2);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        audioSource.PlayOneShot(buttonClick, 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void Exit()
    {
        audioSource.PlayOneShot(buttonClick, 2);
        SceneManager.LoadScene("MenuStartScene");
    }

    public void Pause()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioSource.PlayOneShot(buttonClick, 2);
    }

    public void CalculateScore()
    {
        scoreCount += 5;//ana 3amlha 5 3ashan 3andee 2 bullets kol wahda ba 5 fa lama 2adrb el score yazeed 10 w dah el ana 3ayzo
        scoreText.text = "SCORE: " + scoreCount;

        if (scoreCount == 100)
        {
            memeTexts[0].gameObject.SetActive(true);
            StartCoroutine(MemeTextCountDown1());
        }

        if (scoreCount == 200)
        {
            memeTexts[1].gameObject.SetActive(true);
            StartCoroutine(MemeTextCountDown2());
        }

        if (scoreCount == 300)
        {
            memeTexts[2].gameObject.SetActive(true);
            StartCoroutine(MemeTextCountDown3());
        }
        
    }

    public void CalculateLives()
    {
        liveCount = liveCount - 1;
        liveText.text = "LIVES: " + liveCount;


        if (liveCount == 4)
        {
            playerControllerScript.PlaneHitOnce();

        }

        if (liveCount == 3)
        {
            playerControllerScript.PlaneHitOnce();

        }

        if (liveCount == 2)
        {
            playerControllerScript.EngineDown();

        }

        if (liveCount == 1)
        {
            playerControllerScript.EngineDown();
            liveText.color = Color.red;

        }

        if (liveCount == 0)
        {
            GameOver();
        }

    }

    public void MagnetCountDown()
    {
        StartCoroutine(MagnetPowersCountDown());
    }

    public void ShieldCountDown()
    {
        StartCoroutine(ShieldPowersCountDown());
    }

    public void CalculateDollars()
    {
        dollarCount = dollarCount + 1;
        dollarText.text = "$ " + dollarCount;
    }

    public void ChooseBackGround()
    {
        audioSource.PlayOneShot(buttonClick, 2);
        index = index + 1;
        RenderSettings.skybox = skyBox[index];
        if (index >= 9)
        {
            index = 0;
        }
    }

    public void SwapControls()
    {
        audioSource.PlayOneShot(buttonClick, 2);
        swap = swap + 1;

        if (swap == 1)
        {
            playerControllerScript.switchControl = true;
            invertedText.SetActive(true);
        }
        if (swap == 2)
        {
            playerControllerScript.switchControl = false;
            invertedText.SetActive(false);
        }

        if (swap >= 3)
        {
            swap=0;
        }

    }
}
