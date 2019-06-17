/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetInfoManager : MonoBehaviour {

	#region Variables
	private Queue<string> descriptions;
	/* A Queue is just a collection of objects (like an array or List). 
    -It just stores a bunch of objects.
    -The difference is that you can only enqueue (put something in the queue) 
    at the end and dequeue (get something out) at the beginning of the queue. 
    It's a FIFO(FirstIn-FirstOut). */

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI descriptionText;
    #endregion

    #region Methods
    // Use this for initialization
    void Start()
	{
        descriptions = new Queue<string>();
	}

	public void StartInformation(PlanetInfo _info) // Receive a Dialogue object or class
	{
		// dialogBoxAnimator.SetBool("IsOpen", true);

		Debug.Log("<color=blue> Start " + _info.name + "</color>");

		nameText.text = _info.name; // set nameText to the canvase

		descriptions.Clear(); // Clear the sentences from previous setences

		// Store each sentences in the dialogue to string array of _sentence
		foreach (string _sentence in _info.descriptions)
		{
			descriptions.Enqueue(_sentence); // FIFO, "IN" the dialogue.sentences in sentences Queue
		}

		DisplayNextSentence(); // Check if theres is next Sentence
	}

	//  Check if theres is next Sentence
	public void DisplayNextSentence()
	{
		if (descriptions.Count == 0)
		{
			// if true sentence is 0 end Dialogue
			EndDialogue();
			return;
		}

		// else if there is  sentence
		string sentence = descriptions.Dequeue(); // FIFO, "OUT" the first Queue then the next if call again (Queue --)
												  // Debug.Log("Sentece no " + ((sentences.Count) + 1) + ": " + sentence);

		StopAllCoroutines(); //Start new Coroutine
		StartCoroutine(DisplayEachLetter(sentence));

		//"if you want to display all sentences in dialog remove this comment" dialogueText.text = sentence; // set nameText to the canvase
	}

	IEnumerator DisplayEachLetter(string sentence)
	{
		descriptionText.text = "";
		//ToCharArray is a fuction that convert string in to Char Array
		foreach (char letter in sentence.ToCharArray())
		{
			descriptionText.text += letter; // dialogueText.text = dialogueText.text + letter;
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
	#endregion
}
