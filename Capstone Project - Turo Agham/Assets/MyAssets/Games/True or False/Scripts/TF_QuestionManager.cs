/*
* Copyright (c) Creative Code Studio
*/

using System.Collections; // IEnumerator
using System.Collections.Generic; //List<>
using UnityEngine;
using System.Linq; //ability to store to a list
using TMPro;
using UnityEngine.UI;

public class TF_QuestionManager : MonoBehaviour {

	#region Variables
	[Header("Text Game Object")]
	public TextMeshProUGUI questionNoInfo;
	public TextMeshProUGUI scoreText;
	[Space]
	public TextMeshProUGUI questionText;

	[Header("AnswerAnim")]
	public Animator answer;

	[Header("FinishGameUI")]
	public GameObject endGamePanel;

	[Header("Number of Question")]
	public TF_Question[] questions;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public Animation anim;

    public Image questionImage;

	// store the ununansweredQuestions.
	// Static so that when we reload the next scene it will remember the questions...
	private static List<TF_Question> unansweredQuestions;

	private TF_Question currentQuestion; //this will store question after get the random question

	//string correctQuestion; // store the correct question
	private int currentNoQestion;

	string ans;

	int total = 0;
	string result;

	//Wrong
	public TextMeshProUGUI wrongAnswerCorrection;

    [Space]
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
			unansweredQuestions = questions.ToList<TF_Question>();
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

        audioSource.Stop();

        if (currentQuestion.questionImage != null && currentQuestion.questionSound != null)
        {
            questionImage.sprite = currentQuestion.questionImage;
            audioSource.clip = currentQuestion.questionSound;
            audioSource.Play();
        }

        if (currentQuestion.questionSound != null)
        {
            audioSource.Stop();
            audioSource.clip = currentQuestion.questionSound;
            audioSource.Play();
        }
    }

    #endregion

    #region Buttons
    public void SelectTrue()
	{
		if (currentQuestion.isTrue == true)
		{
			total++;

            audioSource.Stop();
            audioSource.clip = correctSound;
            audioSource.Play();

            answer.SetTrigger("Correct");
		}
		else
		{
			WrongAnswerCorrection();
            audioSource.Stop();
            audioSource.clip = wrongSound;
            audioSource.Play();
            answer.SetTrigger("Wrong");
		}
	}

	public void SelectFalse()
	{
		if (currentQuestion.isFalse == true)
		{
			total++;
            audioSource.Stop();
            audioSource.clip = correctSound;
            audioSource.Play();

            answer.SetTrigger("Correct");
		}
		else
		{
			WrongAnswerCorrection();
            audioSource.Stop();
            audioSource.clip = wrongSound;
            audioSource.Play();
            answer.SetTrigger("Wrong");
		}
	}

	public void WrongAnswerCorrection()
	{
		
		if (currentQuestion.isTrue == true)
		{
			ans = "TRUE";	
		}
		else
		{
			ans = "FALSE";	
		}	
		wrongAnswerCorrection.text =  currentQuestion.question +"\nThe Answer is "+ans;
	}

	#endregion

	#region GetNextAnswer
	public void GetNextQuestion()
	{
		// Check if unansweredQuestions is empty or all the question is answered, else GetRandomQuestion();
		if (unansweredQuestions.Count == 0 || unansweredQuestions == null)
		{
            answer.gameObject.SetActive(false);

            if (total == questions.Length)
            {
                AchievementManager.Instance.UnlockAchievement(achievementName);
                if (achievementName == "Weather God")
                {
                    AchievementManager.Instance.UnlockAchievement("You got this!");
                }
                result = "PERFECT !!!";
            }
            else if (total == (questions.Length -1 ) && achievementName == "Weather God")
            {
                AchievementManager.Instance.UnlockAchievement("You got this!");
                result = "Great, almost perfect";
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
        audioSource.clip = audioClip;
        audioSource.Play();
        anim.Play("TF_SampleGameAnim");
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
	#endregion
}
