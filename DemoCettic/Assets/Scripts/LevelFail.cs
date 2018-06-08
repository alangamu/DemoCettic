using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFail : MonoBehaviour {

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
