using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cine3 : MonoBehaviour
{

    float audioTimer = 60.0f;
    public GameObject[] pictures;
    public GameObject audio1;
    public GameObject audio2;
    public Text text;
    bool playing;
    // Use this for initialization
    void Start()
    {
        foreach (var pic in pictures)
        {
            pic.gameObject.SetActive(false);
        }
        pictures[0].SetActive(true);
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {

        audioTimer -= Time.deltaTime;
        if (audioTimer < 3)
        {
            text.text = "Start";
        }
        else if (audioTimer < 16)
        {
            pictures[2].SetActive(false);
            pictures[3].SetActive(true);
        }
        else if (audioTimer < 30)
        {
            pictures[1].SetActive(false);
            pictures[2].SetActive(true);
        }
        else if (audioTimer < 45)
        {
            pictures[0].SetActive(false);
            pictures[1].SetActive(true);
        }

        if (playing)
        {
            if (!audio1.GetComponent<AudioSource>().isPlaying)
            {
                audio2.GetComponent<AudioSource>().enabled = true;
                playing = false;
            }
        }
    }

    public void StoryLevel()
    {
        SceneManager.LoadScene("Level 3");
    }
}
