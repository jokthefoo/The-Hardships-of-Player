﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour {

    public InputField input;
    public Canvas nameCanvas;
    public Canvas mainCanvas;
    public Canvas colorCanvas;
    public ColorPicker picker;
    string playerName;
    public GameObject player;
    public GameObject platform;

    Color chosenColor = Color.green;

	// Use this for initialization
	void Start () {
        picker.CurrentColor = Color.green;
        nameCanvas.gameObject.SetActive(true);
        colorCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(false);
        input.ActivateInputField();
        playerName = "";
        picker.CurrentColor = Color.green;

        picker.onValueChanged.AddListener(color =>
        {
            chosenColor = color;
            player.GetComponent<SpriteColor>().ChangeSprite(color);
            platform.GetComponent<colorscript2>().ChangeSprite(color);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NameEntered(string name)
    {
        playerName = name;
        loadTitleColorSelect();
    }

    public void NameEntered()
    {
        foreach (Text t in input.GetComponentsInChildren<Text>())
        {
            if(t.gameObject.name == "Text")
            {
                playerName = t.text;
                loadTitleColorSelect();
            }
        }
    }

    public void ColorPicked()
    {
        GetComponent<SpriteSheetColor>().ChangeSpriteSheet(chosenColor);

        colorCanvas.gameObject.SetActive(false);
        foreach (Text t in mainCanvas.GetComponentsInChildren<Text>())
        {
            if (t.gameObject.name == "titleText")
            {
                t.text = t.text + playerName;
            }
        }
        mainCanvas.gameObject.SetActive(true);
    }

    public void InfLevel()
    {
        SceneManager.LoadScene("InfiniteLevel");
    }

    public void StoryLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    void loadTitleColorSelect()
    {
        Vars.Name = playerName;
        nameCanvas.gameObject.SetActive(false);
        foreach( Text t in colorCanvas.GetComponentsInChildren<Text>())
        {
            if(t.gameObject.name == "titleText")
            {
                t.text = t.text + playerName;
            }
        }
        colorCanvas.gameObject.SetActive(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
