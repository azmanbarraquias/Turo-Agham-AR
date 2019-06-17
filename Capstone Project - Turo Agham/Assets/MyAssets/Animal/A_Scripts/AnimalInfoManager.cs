/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimalInfoManager : MonoBehaviour
{

    #region Variables
    private Queue<string> facts;
    /* A Queue is just a collection of objects (like an array or List). 
    -It just stores a bunch of objects.
    -The difference is that you can only enqueue (put something in the queue) 
    at the end and dequeue (get something out) at the beginning of the queue. 
    It's a FIFO(FirstIn-FirstOut). */

    public TextMeshProUGUI[] nameTMP;
    public TextMeshProUGUI animaTypeTMP;
    public TextMeshProUGUI foodTypeTMP;
    public TextMeshProUGUI descriptionTMP;
    public TextMeshProUGUI whatDoTheyEatTMP;
    public TextMeshProUGUI factsTMP;
    [Space]
    public GameObject animalSelection;
    public GameObject animalInfoUI;
    [Space]
    public Image animalBG;
    public Sprite defaultBG;
    public Sprite desert;
    public Sprite hills;
    public Sprite mountain;
    public Sprite plains;
    public Sprite plateus;
    public Sprite snowland;
    public Sprite ocean;

    [Space]
    public Image animalDietIMG;
    public Sprite herbivore, carnivore, omnivore;

    public AnimalCardUnlockTracker_Learn animalCardUnlockTracker_Learn;
    #endregion

    #region Methods
    // Use this for initialization
    void Start()
    {
        facts = new Queue<string>();
    }

    public void StartInformation(AnimalInfo _info) // Receive a Dialogue object or class
    {
        // BG Environment
        if (_info.desert == true)
        {
            animalBG.sprite = desert;
        }
        else if (_info.hills == true)
        {
            animalBG.sprite = hills;
        }
        else if (_info.mountain == true)
        {
            animalBG.sprite = mountain;
        }
        else if (_info.plains == true)
        {
            animalBG.sprite = plains;
        }
        else if (_info.plateus == true)
        {
            animalBG.sprite = plateus;
        }
        else if (_info.snowland == true)
        {
            animalBG.sprite = defaultBG;
        }
        else if (_info.ocean == true)
        {
            animalBG.sprite = ocean;
        }
        else
        {
            animalBG.sprite = defaultBG;
        }

        // Diet
        if (_info.herbivore == true)
        {
            animalDietIMG.sprite = herbivore;
            foodTypeTMP.text = "Herbivore";
        }
        else if (_info.carnivore == true)
        {
            animalDietIMG.sprite = carnivore;
            foodTypeTMP.text = "Carnivore";
        }
        else if (_info.omnivore == true)
        {
            animalDietIMG.sprite = omnivore;
            foodTypeTMP.text = "Omnivore";
        }
        else
        {
            animalDietIMG.sprite = omnivore;
            foodTypeTMP.text = "Omnivore";
        }

        animalInfoUI.SetActive(true);
        animalSelection.SetActive(false);
        // dialogBoxAnimator.SetBool("IsOpen", true);

        Debug.Log("<color=blue> Start " + _info.name + "</color>");
        animalCardUnlockTracker_Learn.AnimalUnlocked(_info.name);

        foreach (TextMeshProUGUI name in nameTMP)
        {
            name.text = _info.name; // set nameText to the canvase
        }

        animaTypeTMP.text = _info.animalType;
        descriptionTMP.text = _info.descriptions;
        whatDoTheyEatTMP.text = _info.whatDoTheyEat;

        facts.Clear(); // Clear the sentences from previous setences

        // Store each sentences in the dialogue to string array of _sentence
        foreach (string _sentence in _info.facts)
        {
            facts.Enqueue(_sentence); // FIFO, "IN" the dialogue.sentences in sentences Queue
        }
        // Check if theres is next Sentence
    }

    //  Check if theres is next Sentence
    public void DisplayNextSentence()
    {
        if (facts.Count == 0)
        {
            // if true sentence is 0 end Dialogue
            EndDialogue();
            return;
        }

        // else if there is  sentence
        string sentence = facts.Dequeue(); // FIFO, "OUT" the first Queue then the next if call again (Queue --)
                                           // Debug.Log("Sentece no " + ((sentences.Count) + 1) + ": " + sentence);

        StopAllCoroutines(); //Start new Coroutine
        StartCoroutine(DisplayEachLetter(sentence));

        //"if you want to display all sentences in dialog remove this comment" dialogueText.text = sentence; 
        // set nameText to the canvase
    }

    IEnumerator DisplayEachLetter(string sentence)
    {
        factsTMP.text = "";
        //ToCharArray is a fuction that convert string in to Char Array
        foreach (char letter in sentence.ToCharArray())
        {
            factsTMP.text += letter; // dialogueText.text = dialogueText.text + letter;
            yield return null; // Delay
        }
    }

    void EndDialogue()
    {
        Debug.Log("End Conversation.");
        // dialogBoxAnimator.SetBool("IsOpen", false);
    }

    public void StopDisplayText()
    {
        StopAllCoroutines();
    }

    public void EmptyInfo()
    {
        StopAllCoroutines();
        facts.Clear();
    }
    #endregion
}
