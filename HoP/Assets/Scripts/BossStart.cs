using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStart : MonoBehaviour
{

    bool fighting;
    public Canvas timerCanvas;
    public float bossTime = 15f;
    public GameObject bossPlatforms;
    public GameObject playerPlatform;
    public GameObject bossfail;
    public GameObject[] movePlatforms;
    float eventTimer;

    
    private float speed = 10.0F;
    private float startTime;
    bool started;

    // Use this for initialization
    void Start()
    {
        eventTimer = bossTime;
        fighting = false;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            startTime = Time.time;
        }
        if (fighting)
        {
            eventTimer -= Time.deltaTime;
            if (eventTimer < 0)
            {
                started = true;
                timerCanvas.gameObject.SetActive(false);
                //playerPlatform.transform.position = new Vector3(0, playerPlatform.transform.position.y, playerPlatform.transform.position.z);
                float distCovered = (Time.time - startTime) * speed;
                float fracJourney = distCovered / 25;
                playerPlatform.transform.position = Vector3.Lerp(new Vector3(25, playerPlatform.transform.position.y, 0), new Vector3(0, playerPlatform.transform.position.y, 0), fracJourney);
            }
            else if(eventTimer < 5)
            {
                foreach(FadeOut f in bossPlatforms.GetComponentsInChildren<FadeOut>())
                {
                    f.timeDisabled = 3f;
                    f.timeOnPlatform = .25f;
                }
            }
            else if (eventTimer < 10)
            {
                foreach (FadeOut f in bossPlatforms.GetComponentsInChildren<FadeOut>())
                {
                    f.timeDisabled = 2.5f;
                    f.timeOnPlatform = .5f;
                }
            }


            foreach (Text t in timerCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "TimerText")
                {
                    t.text = "" + eventTimer.ToString("F1");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.name == "GroundCheck")
        {
            if (!fighting)
            {
                fighting = true;
                timerCanvas.gameObject.SetActive(true);
                bossfail.SetActive(true);
                foreach (Text t in timerCanvas.GetComponentsInChildren<Text>())
                {
                    if (t.name == "TimerText")
                        t.text = "" + eventTimer.ToString("F1");
                }

                foreach(GameObject g in movePlatforms)
                {
                    g.transform.position = new Vector3(38,0,0);
                }
            }
        }
    }

    public void resetFight()
    {
        fighting = false;
        playerPlatform.transform.position = new Vector3(38, playerPlatform.transform.position.y, playerPlatform.transform.position.z);
        timerCanvas.gameObject.SetActive(false);
        foreach (FadeOut f in bossPlatforms.GetComponentsInChildren<FadeOut>())
        {
            f.timeDisabled = 2f;
            f.timeOnPlatform = .75f;
        }
        foreach (GameObject g in movePlatforms)
        {
            g.transform.position = new Vector3(0, 0, 0);
        }
        eventTimer = bossTime;
    }
}
