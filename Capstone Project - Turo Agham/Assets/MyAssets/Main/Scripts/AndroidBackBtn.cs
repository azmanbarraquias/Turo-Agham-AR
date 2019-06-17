using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidBackBtn : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if Back was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void ApplicationQuiz()
    {
        Application.Quit();
    }

    public void Pause()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
    }
}
