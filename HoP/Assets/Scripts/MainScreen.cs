using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour {

    public InputField input;
    public Canvas nameCanvas;
    public Canvas colorCanvas;
    public ColorPicker picker;
    string playerName;
    public GameObject player;

	// Use this for initialization
	void Start () {
        picker.CurrentColor = Color.green;
        nameCanvas.gameObject.SetActive(true);
        colorCanvas.gameObject.SetActive(false);
        input.ActivateInputField();
        playerName = "";
        picker.CurrentColor = Color.green;

        picker.onValueChanged.AddListener(color =>
        {
            player.GetComponent<SpriteColor>().ChangeSprite(color);
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

    void loadTitleColorSelect()
    {
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
}
