/*
* Copyright (c) Creative Code Studio
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSoundManager : MonoBehaviour
{

    #region Variables
    private Queue<AudioClip> factsSounds = new Queue<AudioClip>();

    public Button soundBtn;

    public AudioSource audioSource;

    AudioClip discriptionSound;
    AudioClip whatDoTheyEatSound;
    AudioClip lastFacts;

    #endregion

    #region Methods
    public void SetSound(AnimalSoundInfo _sounds)
    {
        factsSounds.Clear();
        if (_sounds.animalHasSound == true)
        {
            soundBtn.gameObject.SetActive(true);
        }
        else
        {
            soundBtn.gameObject.SetActive(false);
        }

        //Play Narrator when
        audioSource.clip = _sounds.discription;
        audioSource.Play();

        //Set Sounds to this SoundManager
        discriptionSound = _sounds.discription;
        whatDoTheyEatSound = _sounds.whatDoTheyEatAClip;

        foreach (var _facts in _sounds.facts)
        {
            factsSounds.Enqueue(_facts); // FIFO, "IN" the dialogue.sentences in sentences Queue
        }
    }

    public void PlayNextFacts()
    {
        audioSource.Stop();
        if (factsSounds.Count == 0)
        {
            if (lastFacts != null)
            {
                audioSource.clip = lastFacts;
                audioSource.Play();
            }
            return;
        }

        AudioClip fact = factsSounds.Dequeue();
        Debug.Log(factsSounds.Count);
        if (factsSounds.Count == 0)
        {
            lastFacts = fact;
        }

        audioSource.clip = fact;
        audioSource.Play();
    }

    public void PlayDiscriptionSound()
    {
        audioSource.Stop();
        audioSource.clip = discriptionSound;
        audioSource.Play();
    }

    public void PlayWhatDoTheyEatSound()
    {
        audioSource.Stop();
        audioSource.clip = whatDoTheyEatSound;
        audioSource.Play();
    }

    public void EmptySound()
    {
        factsSounds.Clear();
    }
    #endregion
}
