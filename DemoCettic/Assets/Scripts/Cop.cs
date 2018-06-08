using UnityEngine;

public class Cop : MonoBehaviour {

    public float damage = 50f;

    public GameObject player;

    public AudioClip damagingClip;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        damage = PlayerPrefs.GetFloat("DanioEnemigo");
        if (damage == 0)
        {
            damage = 50f;
        }
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player")
        {
            audioPlayer.clip = damagingClip;
            audioPlayer.Play();

            player.GetComponent<PlayerStats>().TakeDamage(damage);
        }

    }

}
