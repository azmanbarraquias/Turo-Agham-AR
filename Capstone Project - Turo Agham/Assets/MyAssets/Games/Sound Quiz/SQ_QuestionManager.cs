/*
* Copyright (c) Creative Code Studio
*/

using System.Collections; // IEnumerator
using System.Collections.Generic; //List<>
using UnityEngine;
using System.Linq; //ability to store to a list
using TMPro;
using UnityEngine.UI;

public class SQ_QuestionManager : MonoBehaviour {

	#region Variables
	[Header("Text Game Object")]
	public TextMeshProUGUI questionNoInfo;
	public TextMeshProUGUI scoreText;
	[Space]
	public Image questionImage;
	public TextMeshProUGUI questionText;
	public Image button1IMG;
	public Image button2IMG;
	public Image button3IMG;

	[Header("AnswerAnim")]
	public Animator answer;

	[Header("FinishGameUI")]
	public GameObject endGamePanel;

	[Header("Number of Question")]
	public SQ_Question[] questions;

    public GameObject isPlaying;
    public GameObject stopPlaying;

    // store the ununansweredQuestions.
    // Static so that when we reload the next scene it will remember the questions...
    private static List<SQ_Question> unansweredQuestions;

	private SQ_Question currentQuestion; //this will store question after get the random question

	//string correctQuestion; // store the correct question
	private int currentNoQestion;

	public AudioSource aSource;
	AudioClip aClip;

    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip finishSound;

    int total = 0;
	string result;

    public AudioClip audioClip;
    public AudioClip wrongAudioClip;
    public Animation anim;

    public string achievementName;
    #endregion

    public void StartGame()
	{
		GetRandomQuestion(); // When start the game we want to load the questions
	}

	#region GetRandomQuestionMethod
	void GetRandomQuestion()
	{
		// but first we must load all the question to unansweredQuestions
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
		{
			// store to a list of unansweredQuestions <<< questions
			unansweredQuestions = questions.ToList<SQ_Question>();
		}

		questionNoInfo.text = (++currentNoQestion) + " / " + questions.Length; // 1++ / totalQuestions

		// Get the random question index from list from unansweredQuestions
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);

		// lets select the question base on index
		currentQuestion = unansweredQuestions[randomQuestionIndex];

		// remove question after set that current question from unansweredQuestion list
		unansweredQuestions.RemoveAt(randomQuestionIndex);

		// Set info to UI Text
		questionText.text = currentQuestion.question;
		questionImage.sprite = currentQuestion.images;
		button1IMG.sprite = currentQuestion.button1IMG;
		button2IMG.sprite = currentQuestion.button2IMG;
		button3IMG.sprite = currentQuestion.button3IMG;
		aSource.clip = currentQuestion.soundQuestion;
		aSource.Stop();
		aSource.Play();

	}

	public void PlaySound()
	{
		aSource.Stop();
		aSource.Play();
	}

	#endregion

	#region Buttons
	public void SelectButton1()
	{
		aSource.Stop();
		if (currentQuestion.button1 == true)
		{
			total++;
            aSource.Stop();
            aSource.clip = correctSound;
            aSource.Play();
            answer.SetTrigger("Correct");
		}
		else
		{
            aSource.Stop();
            aSource.clip = wrongSound;
            aSource.Play();
            answer.SetTrigger("Wrong");
		}
	}

	public void SelectButton2()
	{
		aSource.Stop();
		if (currentQuestion.button2 == true)
		{
			total++;
            aSource.Stop();
            aSource.clip = correctSound;
            aSource.Play();
            answer.SetTrigger("Correct");
		}
		else
		{
            aSource.Stop();
            aSource.clip = wrongSound;
            aSource.Play();
            answer.SetTrigger("Wrong");
		}
	}

    private void Update()
    {
        if (aSource.isPlaying)
        {
            isPlaying.SetActive(true);
            stopPlaying.SetActive(false);
        }
        else
        {
            isPlaying.SetActive(false);
            stopPlaying.SetActive(true);
        }
    }

    public void SelectButton3()
	{
		aSource.Stop();
		if (currentQuestion.button3 == true)
		{
			total++;
            aSource.Stop();
            aSource.clip = correctSound;
            aSource.Play();
            answer.SetTrigger("Correct");
		}
		else
		{
            aSource.Stop();
            aSource.clip = correctSound;
            aSource.Play();
            answer.SetTrigger("Wrong");
		}
	}
	#endregion

	#region GetNextAnswer
	public void GetNextQuestion()
	{
		// Check if unansweredQuestions is empty or all the question is answered, else GetRandomQuestion();
		if (unansweredQuestions.Count == 0 || unansweredQuestions == null)
		{
            answer.gameObject.SetActive(false);
            aSource.Stop();
            aSource.clip = finishSound;
            aSource.Play();

            if (total == questions.Length)
            {
                AchievementManager.Instance.UnlockAchievement(achievementName);
                result = "PERFECT !!!";
            }
            else if (total >= (questions.Length / 2))
			{
				result = "GOOD JOB";
			}
			else
			{
				result = "NICE TRY";
			}
			scoreText.text = "YOUR SCORE IS " + total.ToString() + " OUT OF " + questions.Length + "  " + result; ;
			endGamePanel.SetActive(true);
		}
		else
		{
			GetRandomQuestion();
			answer.SetTrigger("CloseAnswer");
		}
	}
	public void ExitGame()
	{
		unansweredQuestions.Clear();
	}

    public void PlaySampleQuestion()
    {
        aSource.clip = audioClip;
        aSource.Play();
        anim.Play("AnimalSoundGameSample");
    }

    public void WrongSound()
    {
        aSource.clip = wrongAudioClip;
        aSource.Play();
    }
    public void StopSound()
    {
        aSource.Stop();
    }

    #endregion
}
