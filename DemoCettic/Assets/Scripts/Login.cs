using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Login : MonoBehaviour {

    public Text username;
    public InputField password;

    Image passwordImage;

    string createUserURL = "http://todosederrumbo.cl/Cettic_demo/InsertUser.php";
    string loginURL = "http://todosederrumbo.cl/Cettic_demo/Login.php";

    private void Start()
    {
        passwordImage = password.GetComponent<Image>();
    }

    public void LoginAttempt()
    {
        passwordImage.color = new Color(255, 255, 255);
        StartCoroutine(LoginToBD());
    }

    void CreateUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username.text);
        form.AddField("passwordPost", password.text);

        WWW www = new WWW(createUserURL, form);
    }

    void LoadNextLevel()
    {
        PlayerPrefs.SetString("PlayerName", username.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoginToBD()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username.text);
        form.AddField("passwordPost", password.text);

        WWW www = new WWW(loginURL, form);
        yield return www;
        
        switch (www.text)
        {
            case "1": //success
                LoadNextLevel();
                break;
            case "2": //password incorrect
                passwordImage.color = new Color(255,0,0);
                break;
            case "3": //user not found
                CreateUser();
                LoadNextLevel();
                break;
        }
    }
}
