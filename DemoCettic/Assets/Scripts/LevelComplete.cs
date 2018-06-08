using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public Text timeText;
    public Text scoreText;
    public Timer timer;
    public Score score;

    public void LoadNextLevel()
    {
        timeText.text = timer.timerText.text;
        scoreText.text = score.scoreText.text;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
