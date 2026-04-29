using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene2Dialogue : MonoBehaviour
{
    // These are the script variables.
    // For more character images / buttons, copy & renumber the variables:
    private int primeInt = 1;        // This integer drives game progress!
    private int currentInt;
    public TMP_Text regularText;
    public TMP_Text Char1name;
    public TMP_Text Char1speech;
    public TMP_Text Char2name;
    public TMP_Text Char2speech;
    public TMP_Text Char3name;
    public TMP_Text Char3speech;
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
        primeInt = 1;
        currentInt = 1;
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
        primeInt++;
        currentInt++;
        if (primeInt == 1)
        {
            DialogueDisplay.SetActive(true);
            regularText.text = "River High School, 9:00am";
        }
        else if (primeInt == 2)
        {
            nameBox.SetActive(true);
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Thank goodness, I made it.</i> I was embarassingly huffing and puffing from the amount of running I did, along with carrying my very heavy backpack."));
        }
        else if (primeInt == 3)
        {
            Char1name.text = "You";
            Char1speech.text = "I take a look around the school, and realize how <i>really</i> late I am, as there's no one there. Hopefully they'll still let me in, I thought.";
        }
        else if (primeInt == 4)
        {
            Char2name.text = "Student 1";
            Char2speech.text = "I can't believe how late we are. We are <b>so</b> cooked.";
        }
        else if (primeInt == 5)
        {
            Char3name.text = "Student 2";
            Char3speech.text = "C'mon, don't worry about it. It's near the end of the school year, there's not much going on.";
        }
        else if (primeInt == 6)
        {
            Char1name.text = "You";
            Char2speech.text = "<i>Wait, I recognize those voices.</i>";
        }
        else if (primeInt == 7)
        {
            Char1name.text = "You";
            Char2speech.text = "<b>!!! Mina and Hana?!</b> My best friends, I figured that they'd be late too, as usual. Maybe they can help me out?";
        }
        else if (primeInt == 8)
        {
            Char1name.text = "You";
            Char1speech.text = "I should come up to them.";
            nextButton.SetActive(false);
            allowSpace = false;
            Choice1a.SetActive(true); // function Choice1aFunct(), run up to them
            Choice1b.SetActive(true); // function Choice1bFunct(), yell out their names
        }

        // after choice 1a
        else if (primeInt == 20)
        {
            Char2name.text = "Mina";
            StartCoroutine(TypeText(Char2speech, "Hey, did you hear that?"));
        }
        else if (primeInt == 21)
        {
            Char3name.text = "Hana";
            StartCoroutine(TypeText(Char3speech, "Hear what?"));
        }
        else if (primeInt == 22)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Hmm?"));
        }
        else if (primeInt == 23)
        {
            Char2name.text = "Mina";
            StartCoroutine(TypeText(Char2speech, "Whatever, it's probably nothing."));
        }
        else if (primeInt == 24)
        {
            Char3name.text = "Hana";
            StartCoroutine(TypeText(Char3speech, "Must've been the wind."));
        }
        else if (primeInt == 25)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Both of them were laughing at that before walking towards me. That's...strange. Did they ever ignore me like this before?"));
        }
        else if (primeInt == 26)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "But before I could ponder on that, I see them walking to where I'm at, they're coming this way!"));
        }
        else if (primeInt == 27)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Maybe I get their attention right now. I might not have been loud enough.</i>"));
        }
        else if (primeInt == 28)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>Wait, am I being annoying right now? Ugh whatever, I'm already too late, let's get their help!</i>"));
        }
        else if (primeInt == 29)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<b>Hana!! Mina!! Over here! Do y'all know where I should go?!</b> I walked up closer to them so they can see me better hopefully. They're coming closer and closer..."));
        }

        // after choice 1b
        else if (primeInt == 30)
        {
            Char3name.text = "Hana";
            StartCoroutine(TypeText(Char3speech, "Hah, don't feel bad about it. Look, there are the other students near the gate, it's not too late!"));
        }
        else if (primeInt == 31)
        {
            Char2name.text = "Mina";
            StartCoroutine(TypeText(Char2speech, "You're right! Let's run!"));
        }
        else if (primeInt == 32) 
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "They ran as fast as they can towards the gate, which just so happens to be in front of me."));
        }
        else if (primeInt == 33)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<b>Wait guys, hold on!</b> How do they still not hear me, did I do something a-"));
        }
        else if (primeInt == 34)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Mina and Hana, holding hands, proceed to run right through me. Yep, right through me."));
        }
        else if (primeInt == 35)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "Wait, what."));
        }
        else if (primeInt == 36)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "I just, stood there, after that. Screw school, what just happened?"));
        }
        else if (primeInt == 37)
        {
            Char1name.text = "You";
            StartCoroutine(TypeText(Char1speech, "<i>There is no way. There is no way.</i> I look down on myself to my hands."));
        }
    }

    public void Choice1aFunct() // run up to them
    {
        Char1name.text = "You";
        StartCoroutine(TypeText(Char1speech, "Hey Mina, Hana, it's me!! I don't mean to scare you, but I've never been late before so-"));
        primeInt = 19; // so hitting "NEXT" goes to primeInt==20!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }
    public void Choice1bFunct() // yell out their names
    {
        Char1name.text = "You";
        StartCoroutine(TypeText(Char1speech, "<b>Hana!! Mina!! Over here! Do y'all know where I should go?!</b> I walked up closer to them so they can see me better hopefully. They're coming closer and closer..."));
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
            /*if (primeInt == currentInt) 
            {
                primeInt++;
                currentText = currentText.Length(fullText.Length(i));
            }*/
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
