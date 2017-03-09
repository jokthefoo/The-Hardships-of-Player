using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public Canvas UI;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void EnteredName()
    {
        string input;
        input = UI.GetComponentInChildren<InputField>().text;
        UI.GetComponentInChildren<InputField>().enabled = false;
        UI.GetComponentInChildren<InputField>().GetComponent<Image>().enabled = false;
        foreach ( Text t in UI.GetComponentsInChildren<Text>())
        {
            if(t.name == "Title")
            {
                t.text = "The Hardships of " + input;
            }
            if(t.name == "InputText")
            {
                t.enabled = false;
            }
        }
    }

    public void TogglePauseMenu()
    {
        if (UI.GetComponent<Canvas>().enabled)
        {
            UI.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }
    }

}
