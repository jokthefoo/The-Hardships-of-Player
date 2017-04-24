using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Events : MonoBehaviour {

    public float startWaitTime = 5;
    public GameObject startPlat;
    float startPos = -7.16f;
    
    public float speed = 10.0F;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        journeyLength = 20 - startPos;
    }
	
	// Update is called once per frame
	void Update () {
        startWaitTime -= Time.deltaTime;
        if(startWaitTime < 0)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            startPlat.transform.position = Vector3.Lerp(new Vector3(-20+startPos, -5.68f, 0), new Vector3(startPos, -5.68f, 0), fracJourney);
        }
    }
}
