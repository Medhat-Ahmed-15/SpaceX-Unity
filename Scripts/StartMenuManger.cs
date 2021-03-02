using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManger : MonoBehaviour
{
    public AudioClip buttonClick;
    public AudioSource audioSource;
    public GameObject mainMenu;
    public GameObject signinPage;
    public GameObject signupPage;
    public GameObject loginSuccessText;
    public GameObject SignupSuccessText;


    public IEnumerator RemoveLoginSuccessText()
    {
        yield return new WaitForSeconds(3);
        loginSuccessText.SetActive(false);
        SignupSuccessText.SetActive(false);
    }
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
        audioSource.PlayOneShot(buttonClick, 2);
    }

    public void QuitGame()
    {
        Application.Quit();
        audioSource.PlayOneShot(buttonClick, 2);
    }

    public void ShowSignInPage()
    {
        mainMenu.SetActive(false);
        signinPage.SetActive(true);
        audioSource.PlayOneShot(buttonClick, 2);
    }

    public void ShowSignUpPage()
    {
        mainMenu.SetActive(false);
        signupPage.SetActive(true);
        audioSource.PlayOneShot(buttonClick, 2);
    }

    public void ShowMainMenuPage()
    {
        mainMenu.SetActive(true);
        signupPage.SetActive(false);
        signinPage.SetActive(false);
        audioSource.PlayOneShot(buttonClick, 2);
    }

    public void LoginButton()
    {
        loginSuccessText.SetActive(true);
        StartCoroutine(RemoveLoginSuccessText());
    }

    public void SignupButton()
    {
        SignupSuccessText.SetActive(true);
        StartCoroutine(RemoveLoginSuccessText());
    }
}
