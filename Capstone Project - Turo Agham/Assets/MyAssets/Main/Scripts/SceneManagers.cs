/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagers : MonoBehaviour
{

    #region Loading Variables
    public GameObject loadingScreen;

    //public Slider loadingBar;

    public TextMeshProUGUI progressText;
    public Image loadingBG;
    public TextMeshProUGUI loadingTriviaTMP;
    //public Animator fadeAnimator;
    [Space]
    public string[] loadingTriviaSS;
    public Sprite[] loadingImagesSS;
    public string[] stringArraySS;
    [Space]
    public string[] loadingTriviaA;
    public Sprite[] loadingImagesA;
    public string[] stringArrayA;
    [Space]
    public string[] loadingTriviaW;
    public Sprite[] loadingImagesW;
    public string[] stringArrayW;
    [Space]
    public string[] loadingTriviaH;
    public Sprite[] loadingImagesH;
    public string[] stringArrayH;
    #endregion


    #region Methods
    public void LoadScene(string sceneIndex) // int for index, string for scene name
    {
        //Debug.Log("Loading panel active " + loadingScreen.activeSelf);  // check if its active
        if (loadingScreen != null)
        {
            string stringToCheck = sceneIndex;

            loadingScreen.SetActive(true);

            foreach (string x in stringArraySS)
            {
                if (stringToCheck.Contains(x))
                {
                    int rand = Random.Range(0, loadingTriviaSS.Length);
                    loadingBG.sprite = loadingImagesSS[rand];
                    loadingTriviaTMP.text = loadingTriviaSS[rand];
                }
            }
            foreach (string x in stringArrayA)
            {
                if (stringToCheck.Contains(x))
                {
                    int rand = Random.Range(0, loadingTriviaA.Length);
                    loadingBG.sprite = loadingImagesA[rand];
                    loadingTriviaTMP.text = loadingTriviaA[rand];
                }
            }
            foreach (string x in stringArrayW)
            {
                if (stringToCheck.Contains(x))
                {
                    int rand = Random.Range(0, loadingTriviaW.Length);
                    loadingBG.sprite = loadingImagesW[rand];
                    loadingTriviaTMP.text = loadingTriviaW[rand];
                }
            }
            foreach (string x in stringArrayH)
            {
                if (stringToCheck.Contains(x))
                {
                    int rand = Random.Range(0, loadingTriviaH.Length);
                    loadingBG.sprite = loadingImagesH[rand];
                    loadingTriviaTMP.text = loadingTriviaH[rand];
                }
            }
        }

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(string _sceneIndex)
    {
        /* LoadSceneAsync load the scene a synchronously in the backgorund that
		 * means it keep all our current scene and all the behavior
		 * in it running while its loading our new scene in to memory */

        /* What it can do now is get some information back from our scene manager
		 * about the progress of this operation. */

        // not we store the info into the variable AsyncOperation name operation
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneIndex);

        // loadingScreen.SetActive(true); // Set Loading Panel Active = True , LOADING LOADING LOADING LOADING

        // Debug.Log("Loading Panel Active " + loadingScreen.activeSelf); // check if its active, LOADING LOADING LOADING LOADING

        while (!operation.isDone)
        {
            // insted 0 and 0.9 we use Mathf.Clamp01 to change the value to value 0 and 1
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            //Debug.Log((progress * 100).ToString("0")); //Check loading
            if (progressText != null)
            {
                // loadingBar.value = progress; // , LOADING LOADING LOADING LOADING

                progressText.text = (progress * 100).ToString("0") + "%"; // , LOADING LOADING LOADING LOADING
            }

            yield return null; // wait next frame then do again
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
    }

    public void OpenLink()
    {
        Application.OpenURL("https://drive.google.com/open?id=1_jTe5PmLlb6Oo42GwXViNeWKFkC78C5B");
    }
    #endregion
}
