using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    private Text namePlayer;

	void Start () {
        namePlayer = GetComponent<Text>();

        namePlayer.text = PlayerPrefs.GetString("PlayerName");
    }
	

}
