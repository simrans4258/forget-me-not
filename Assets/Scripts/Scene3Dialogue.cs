using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene3Dialogue : MonoBehaviour
{
    private int primeInt;
    public TMP_Text regularText;
    public GameObject DialogueDisplay;
    public GameObject nextButton;
    public AudioSource backgroundMusic1;
    private bool allowSpace = true;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(true);
        primeInt = 0;
        backgroundMusic1.Play();
        DialogueDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (allowSpace == true)
        {
            if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            {
                Next();
            }

            // secret debug code: go back 1 Story Unit, if NEXT is visible
            if (Input.GetKeyDown("p"))
            {
                primeInt -= 2;
                Next();
            }
        }
    }

    public void Next() 
    {
        primeInt += 1;
        if (primeInt == 1) 
        {
            DialogueDisplay.SetActive(true);
            StartCoroutine(TypeText(regularText, "Next part coming eventually...maybe...later."));
        }
        else if (primeInt == 2) 
        {
            StartCoroutine(TypeText(regularText, "Thank you for playing this short low quality demo lmao. Both criticism and support is appreciated."));
        }
        else if (primeInt == 3)
        {
            /*allowSpace = false;
            nextButton.SetActive(false);*/
            Application.Quit();
        }
        /*else if (primeInt == 3) 
        {
            StartCoroutine(TypeText(regularText, "If you want to play this game fully for whatever reason, keep up with my itch.io page."));
        }*/
    }
    IEnumerator TypeText(TMP_Text target, string fullText)
    {
        float delay = 0.01f;
        nextButton.SetActive(false);
        allowSpace = false;
        for (int i = 0; i <= fullText.Length; i++)
        {
            string currentText = fullText.Substring(0, i);
            target.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        nextButton.SetActive(true);
        allowSpace = true;
    }
}
