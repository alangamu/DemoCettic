using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public float restartDelay = 1f;
    public float maxTime = 30f;
    public GameObject completeLevelUI;
    public GameObject failLevelUI;

    private void Awake()
    {
        PlayerPrefs.SetFloat("Score", 0);
        PlayerPrefs.SetFloat("MaxTime", maxTime);
        //LoadPlayerSettings();
        StartCoroutine(GetSettingsFromDB());
    }

    void Start()
    {
        GameIsOver = false;
    }

    IEnumerator GetSettingsFromDB()
    {
        float velocidadPersonaje;
        float tiempoLevel;
        float puntosItem;
        float vitalidadPersonaje;
        float danioEnemigo;

        WWW settingsData = new WWW("http://todosederrumbo.cl/Cettic_demo/SettingsData.php");
        yield return settingsData;

        string settingsDataString = settingsData.text;

        velocidadPersonaje = GetDataValue(settingsDataString, "velocidadPersonaje:");
        tiempoLevel = GetDataValue(settingsDataString, "tiempoLevel:");
        puntosItem = GetDataValue(settingsDataString, "puntosItem:");
        vitalidadPersonaje = GetDataValue(settingsDataString, "vitalidadPersonaje:");
        danioEnemigo = GetDataValue(settingsDataString, "danioEnemigo:");

        LoadPlayerSettings(velocidadPersonaje, tiempoLevel, puntosItem, vitalidadPersonaje, danioEnemigo);
    }

    float GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return float.Parse(value);
    }

    void LoadPlayerSettings(float velocidadPlayer, float tiempoLevel, float puntosItem, float vitalidadPlayer, float DanioEnemigo)
    {
        PlayerPrefs.SetFloat("VelocidadPlayer", velocidadPlayer);
        maxTime = tiempoLevel;
        PlayerPrefs.SetFloat("PuntosItem", puntosItem);
        PlayerPrefs.SetFloat("VitalidadPlayer", vitalidadPlayer);
        PlayerPrefs.SetFloat("DanioEnemigo", DanioEnemigo);
    }

    private void Update()
    {
        if (!GameIsOver)
        {
            if (PlayerPrefs.GetFloat("MaxTime") == 0)
            {
                EndGame();
            }
        }
    }

    public void CompleteLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        GameIsOver = true;
        failLevelUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
