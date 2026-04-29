using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene1Dialogue : MonoBehaviour
{
    // These are the script variables.
    // For more character images / buttons, copy & renumber the variables:
    public int primeInt = 1;        // This integer drives game progress!
    public TMP_Text regularText;
    public TMP_Text Char1name;
    public TMP_Text Char1speech;
    /*public TMP_Text Char2name;
    public TMP_Text Char2speech;*/
    //public TMP_Text Char3name;
    //public TMP_Text Char3speech;
    public GameObject DialogueDisplay;
    public GameObject nameBox;
    //public GameObject ArtChar1a;
    //public GameObject ArtChar1b;
    //public GameObject ArtChar1c;
    //public GameObject ArtChar2;
    public GameObject ArtBG1;
    public GameObject ArtBG2;
    public GameObject Choice1a;
    public GameObject Choice1b;
    public GameObject NextSceneButton;
    public GameObject nextButton;
    //public AudioSource audioSource1;
    private bool allowSpace = true;

    // Set initial visibility. Added images or buttons need to also be SetActive(false);
    void Start()
    {
        DialogueDisplay.SetActive(false);
        //ArtChar1a.SetActive(false);
        StartCoroutine(FadeIn(ArtBG1));
        ArtBG1.SetActive(true);
        ArtBG2.SetActive(false);
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        NextSceneButton.SetActive(false);
        nextButton.SetActive(true);
        nameBox.SetActive(false);
        primeInt = 0;
    }

    // Use the spacebar as a faster "Next" button:
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

    //Story Units! The main story function.
    //Players hit [NEXT] to progress to the next primeInt:
    public void Next()
    {
        primeInt += 1;
        if (primeInt == 1)
        {
            // audioSource1.Play();
            DialogueDisplay.SetActive(true);
            regularText.text = "April 27th, 20xx, 8:00am. Bedroom.";
        }
        else if (primeInt == 2)
        {
            /*ArtChar1a.SetActive(true);*/
            StartCoroutine(TypeText(regularText, "Alarm Clock: BEEP BEEP BEEP BEEP"));
        }
        else if (primeInt == 3)
        {
            nameBox.SetActive(true);
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Ugh, morning already?"));
        }
        else if (primeInt == 4)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "I wake up to the sound of my alarm beeping so hard to wake me up. I don't know why I still have that though, there was no need for it anymore."));
        }
        else if (primeInt == 5)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Hah, what time is it?</i> I barely take my phone from my bedstand."));
        }
        else if (primeInt == 6)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<b>ITS 8 ALREADY?!!?!</b> IM GONNA BE LATE FOR SCHOOL!"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Why do I do this to myself?</i> I get up in a rush and and get ready in the fastest way I've ever gotten since the first day of high school."));
        }
        else if (primeInt == 8)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Should I just run to school or take the bus at this point? Sigh, I'm late either way."));
            // Turn off the "Next" button, turn on "Choice" buttons
            nextButton.SetActive(false);
            allowSpace = false;
            Choice1a.SetActive(true); // function Choice1aFunct(), take bus
            Choice1b.SetActive(true); // function Choice1bFunct(), run to school
        }

        // after choice 1a
        else if (primeInt == 20)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "20 minutes??? I'm never making it on time! Screw it, I'm running instead!"));
        }
        else if (primeInt == 21)
        {
            ArtBG1.SetActive(false);
            ArtBG2.SetActive(true);
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "I dash to the front door to make my escape. But before opening the door, I look to see if there's anyone in the house. But there's no one there."));
        }
        else if (primeInt == 22)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Oh, of course they all had to go too.<i> I forgot that the rest of my family had left to work and school as well. Without telling me to wake up."));
        }
        else if (primeInt == 23)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Sigh, I can think about this later. Well, that doesn't matter. I have to go now. I get out of the house and run to school, can't miss anymore time, y'know?"));
            // Turn off the "Next" button, turn on "Scene" button/s
            nextButton.SetActive(false);
            allowSpace = false;
            NextSceneButton.SetActive(true);
        }

        // after choice 1b
        else if (primeInt == 30)
        {
            StartCoroutine(FadeOut(ArtBG1));
            ArtBG1.SetActive(false);
            StartCoroutine(FadeIn(ArtBG2));
            ArtBG2.SetActive(true);
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "I dash to the front door to make my escape. But before opening the door, I look to see if there's anyone in the house. But there's no one there."));
        }
        else if (primeInt == 31)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Oh, of course they all had to go too.<i> I forgot that the rest of my family had left to work and school as well. Without telling me to wake up."));
        }
        else if (primeInt == 31)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Sigh, I can think about this later.</i> Well, that doesn't matter. I have to go now. I get out of the house and run to school, can't miss anymore time, y'know?"));
            // Turn off the "Next" button, turn on "Scene" button/s
            nextButton.SetActive(false);
            allowSpace = false;
            NextSceneButton.SetActive(true);
        }

        //Please do NOT delete this final bracket that ends the Next() function:
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
    public void Choice1aFunct() // take the bus
    {
        Char1name.text = "You";
        StartCoroutine(TypeText(Char1speech, "<i>Hopefully my luck isn't TOO bad.</i> I check the bus times on my phone to see the closest bus."));
        primeInt = 19; // so hitting "NEXT" goes to primeInt==20!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }
    public void Choice1bFunct() // just run
    {
        Char1name.text = "You";
        StartCoroutine(TypeText(Char1speech, "<i>Alright, here goes nothing.</i>"));
        primeInt = 29; // so hitting "NEXT" goes to primeInt==30!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Scene2");
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
    IEnumerator FadeIn(GameObject fadeImage)
    {
        float alphaLevel = 0;
        fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
        for (int i = 0; i < 100; i++)
        {
            alphaLevel += 0.01f;
            yield return null;
            fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
            Debug.Log("Alpha is: " + alphaLevel);
        }
    }

    IEnumerator FadeOut(GameObject fadeImage)
    {
        float alphaLevel = 1;
        fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
        for (int i = 0; i < 100; i++)
        {
            alphaLevel -= 0.01f;
            yield return null;
            fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
            Debug.Log("Alpha is: " + alphaLevel);
        }
    }
}