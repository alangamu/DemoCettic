using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public GameManager gameManager;

    public float playerHealth = 500f;
    private float currentHealth;

    public AudioClip dieClip;
    public AudioClip gameMusic;

    private AudioSource audioPlayer;

    public Image healthBar;

    private void Start()
    {
        currentHealth = playerHealth;
        audioPlayer = GetComponent<AudioSource>();
        playerHealth = PlayerPrefs.GetFloat("VitalidadPlayer");

        if (playerHealth == 0)
        {
            playerHealth = 500f;
        }

        audioPlayer.clip = gameMusic;
        audioPlayer.Play();
    }

    public void TakeDamage (float damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.fillAmount = currentHealth / playerHealth;

        if (currentHealth <= 0)
        {
            audioPlayer.Stop();
            audioPlayer.clip = dieClip;
            audioPlayer.Play();
            gameManager.EndGame();
        }
    }

}
