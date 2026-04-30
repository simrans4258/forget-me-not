using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().Equals("MainMenu"))
        {
            audio1.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Game()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Saves()
    {
        SceneManager.LoadScene("Saves");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CGs()
    {
        SceneManager.LoadScene("CGs");
    }
    /*public void Help()
    {
        SceneManager.LoadScene("Help");
    }*/

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
