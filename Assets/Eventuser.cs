using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Eventuser : MonoBehaviour
{

    public Button play, score, Quit;

    public void Start()
    {
        play.onClick.AddListener(StartGame);
        play.onClick.AddListener(ShowScore);
        Quit.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        Debug.Log("Start");

        SceneManager.LoadScene("Level1");
    }

    public void ShowScore()
    {
        Debug.Log("Score");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }

}
