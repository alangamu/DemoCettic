using UnityEngine;

public class Clock : MonoBehaviour {

    public Timer timer;
    public float clockValue = 2;

    public AudioClip pickupClock;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timer.maxTime = timer.maxTime + clockValue;

            audioPlayer.clip = pickupClock;
            audioPlayer.Play();

            Destroy(gameObject, 2);
        }
    }
}
