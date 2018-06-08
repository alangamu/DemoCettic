using UnityEngine;

public class Coin : MonoBehaviour {

    public float coinValue = 50f;

    public AudioClip pickupCoin;

    private AudioSource audioPlayer;

    private void Start()
    {
        coinValue = PlayerPrefs.GetFloat("PuntosItem");
        if (coinValue == 0)
        {
            coinValue = 50f;
        }
        audioPlayer = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score", 0) + coinValue);

            audioPlayer.clip = pickupCoin;
            audioPlayer.Play();

            Destroy(gameObject, 2);
        }
    }
}
