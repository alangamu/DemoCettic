using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public float maxTime;
    private bool isTimeUp = false;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
        maxTime = PlayerPrefs.GetFloat("MaxTime");
        if (maxTime == 0)
        {
            maxTime = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimeUp && !GameManager.GameIsOver)
        {
            if (maxTime < 0)
            {
                PlayerPrefs.SetFloat("MaxTime", 0);
                isTimeUp = true;
            }
            else
            {
                timerText.text = string.Format("{0}:{1}", (int)(maxTime / 60), (maxTime % 60).ToString("00"));
                maxTime -= Time.deltaTime;
            }
        }


    }
}
