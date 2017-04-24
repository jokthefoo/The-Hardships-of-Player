using System.Collections;
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
    public GameObject audio;

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
            Vars.playerColor = color;
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
        GetComponent<SpriteSheetColor>().ChangeHatSpriteSheet(InvertColor(chosenColor));

        colorCanvas.gameObject.SetActive(false);
        foreach (Text t in mainCanvas.GetComponentsInChildren<Text>())
        {
            if (t.gameObject.name == "titleText")
            {
                t.text = t.text + playerName;
            }
        }
        audio.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(true);
    }
    public Color InvertColor(Color color)
    {
        return new Color(1.0f-color.r, 1.0f-color.g, 1.0f-color.b);
    }

public void InfLevel()
    {
        SceneManager.LoadScene("InfiniteLevel");
    }

    public void StoryLevel()
    {
        SceneManager.LoadScene("Level 1 Cinematic");
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
