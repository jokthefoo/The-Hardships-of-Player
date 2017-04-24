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
        Time.timeScale = 1.0f;
        foreach (Text t in UI.GetComponentsInChildren<Text>())
        {
            if (t.name == "Title")
            {
                t.text = "The Hardships of " + Vars.Name;
            }
        }
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
        Vars.sprites = new List<Sprite>();
        Vars.fsprites = new List<Sprite>();
        Vars.numJumps = 0;
        Vars.momJumps = 0;
        Vars.dadJumps = 0;
        Vars.badJumps = 0;
        Vars.goodJumps = 0;
        Vars.friend1Jumps = 0;
        Vars.friend2Jumps = 0;
        Vars.brotherJumps = 0;
        SceneManager.LoadScene("StartScreen");
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
        if (UI.enabled)
        {
            UI.enabled = false;
            TimeSet();
        }
        else
        {
            UI.enabled = true;
            TimeSet();
        }
    }

    public void TimeSet()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
