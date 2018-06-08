using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public float obstacleDamage = 50f;
    public float clockValue = 2f;

    public PlayerStats playerStat;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            playerStat.TakeDamage(obstacleDamage);
        }

    }
}
