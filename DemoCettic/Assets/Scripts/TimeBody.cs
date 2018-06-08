using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    public float rewindTime = 1f;

    bool isRewinding = false;
    List<Vector3> positions;

	// Use this for initialization
	void Start () {
        positions = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            StartRewind();
        }

        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
	}

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            isRewinding = false;
        }
    }

    void Record()
    {
        if (positions.Count > Mathf.Round(rewindTime / Time.deltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
        }
            positions.Insert(0, transform.position);
    }

    void StartRewind()
    {
        isRewinding = true;
    }
}
