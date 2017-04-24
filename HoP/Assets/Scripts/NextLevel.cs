using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class NextLevel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name.Contains("1"))
        {
            SceneManager.LoadScene("Level 2 Cinematic");
        }
        else if (SceneManager.GetActiveScene().name.Contains("2"))
        {
            SceneManager.LoadScene("Level 3 Cinematic");
        }
        else if (SceneManager.GetActiveScene().name.Contains("3"))
        {
            SceneManager.LoadScene("End Cinematic");
        }
    }
}
