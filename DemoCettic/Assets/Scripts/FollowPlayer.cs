using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    private float transition = 0f;
    private float animationDuration = 2f;
    private Vector3 animationOffset = new Vector3(0, 3, 5);

	// Update is called once per frame
	void Update () {
        if (transition > 1f)
        {
            transform.position = player.position + offset;
        }
        else
        {
            transform.position = Vector3.Lerp(player.position + offset + animationOffset, player.position + offset, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(player.position + Vector3.up);
        }
	}
}
