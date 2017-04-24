using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cine4 : MonoBehaviour
{

    float audioTimer = 32.0f;
    public GameObject[] pictures;
    public GameObject audio;
    public Text text;

    // Use this for initialization
    void Start()
    {
        foreach (var pic in pictures)
        {
            pic.gameObject.SetActive(false);
        }
        pictures[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        audioTimer -= Time.deltaTime;
        if (audioTimer < 0)
        {
            text.text = "Continue";
        }
        else if (audioTimer < 18)
        {
            pictures[0].SetActive(false);
            pictures[1].SetActive(true);
        }
    }

    public void StoryLevel()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
