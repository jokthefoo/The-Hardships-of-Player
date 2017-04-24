using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cine1 : MonoBehaviour {

    float audioTimer = 50.0f;
    public GameObject[] pictures;
    public GameObject audio;
    public Text text;
    bool playing;
    // Use this for initialization
    void Start () {
        foreach (var pic in pictures)
        {
            pic.gameObject.SetActive(false);
        }
        pictures[0].SetActive(true);
        audio.GetComponent<AudioSource>().time = 3;
        playing = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (playing)
        {
            audioTimer -= Time.deltaTime;
            if (audioTimer < 9)
            {
                text.text = "Start";
            }
            else if(audioTimer < 17)
            {
                pictures[2].SetActive(false);
                pictures[3].SetActive(true);
            }
            else if (audioTimer < 28)
            {
                pictures[1].SetActive(false);
                pictures[2].SetActive(true);
            }
            else if (audioTimer < 37)
            {
                pictures[0].SetActive(false);
                pictures[1].SetActive(true);
            }
        }
    }

    public void StoryLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
