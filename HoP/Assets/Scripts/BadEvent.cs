using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;

public class BadEvent : MonoBehaviour {

    public enum State
    {
        shrink, dissapearTime, jumpHeight,clingy
    }

    public State current;
    public GameObject target;
    public GameObject player;
    public string badEventText = "You smell really bad today.\n So yellow has been avoiding you.";
    public float dissapearTime = 1.0f;
    public bool timedEvent = false;
    public float eventTimer = 0f;
    public Canvas eventCanvas;

    bool triggered;
    bool showText;
    float textTimer = 3.0f;

	// Use this for initialization
	void Start () {
        triggered = false;
        showText = false;
        if (eventCanvas.gameObject.activeSelf)
        {
            eventCanvas.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(triggered && showText)
        {
            textTimer -= Time.deltaTime;
            if(textTimer < 0)
            {
                showText = false;
            }
        }

        if(triggered && timedEvent)
        {
            eventTimer -= Time.deltaTime;
            if (eventTimer < 0)
            {
                if(current == State.shrink)
                {
                    foreach (Transform t in target.GetComponentsInChildren<Transform>())
                    {
                        if (t.name != target.name)
                        {
                            t.localScale = new Vector3(t.localScale.x * 2, t.localScale.y, t.localScale.z);
                        }
                    }
                }

                if (current == State.dissapearTime)
                {
                    foreach (FadeOut f in target.GetComponentsInChildren<FadeOut>())
                    {
                        if (f.name != target.name)
                        {
                            f.enabled = true;
                            f.timeOnPlatform = 1.0f;
                        }
                    }
                }

                if (current == State.jumpHeight)
                {
                    player.GetComponent<Rigidbody2D>().mass -= .01f;
                }

                if (current == State.clingy)
                {
                    player.GetComponent<PlatformerCharacter2D>().setCLingy(false);
                }
                timedEvent = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "GroundCheck")
        {
            if (!triggered)
            {
                GenBadEvent();
                eventCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    void GenBadEvent()
    {
        String message = "";
        if (timedEvent)
        {
            message = " For " + eventTimer + " seconds.";
        }
        triggered = true;
        //showText = true;
        if (current == State.shrink)
        {
            foreach (Transform t in target.GetComponentsInChildren<Transform>())
            {
                if (t.name != target.name)
                {
                    t.localScale = new Vector3(t.localScale.x / 2, t.localScale.y, t.localScale.z);
                }
            }
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = badEventText + "\n(Their platforms are now smaller.)" + message;
            }
            //EditorUtility.DisplayDialog("Bad Event! :(", badEventText + "\n(Their platforms are now smaller.)" + message, "Ok");
        }

        if (current == State.dissapearTime)
        {
            foreach (FadeOut f in target.GetComponentsInChildren<FadeOut>())
            {
                if (f.name != target.name)
                {
                    f.enabled = true;
                    f.timeOnPlatform = dissapearTime;
                }
            }
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = badEventText + "\n(Their platforms disappear faster.)" + message;
            }
            //EditorUtility.DisplayDialog("Bad Event! :(", badEventText + "\n(Their platforms disappear faster.)" + message, "Ok");
        }

        if (current == State.jumpHeight)
        {
            player.GetComponent<Rigidbody2D>().mass += .01f;
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = badEventText + "\n(You can't jump as high.)" + message;
            }
            //EditorUtility.DisplayDialog("Bad Event! :(", badEventText + "\n(You can't jump as high.)" + message, "Ok");
        }

        if (current == State.clingy)
        {
            player.GetComponent<PlatformerCharacter2D>().setCLingy(true);
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = badEventText + "\n(You can only move while in mid-air.)" + message;
            }
            //EditorUtility.DisplayDialog("Bad Event! :(", badEventText + "\n(You can only move while in mid-air.)" + message, "Ok");
        }
        GetComponentInParent<ParticleSystem>().Stop();
    }

    void OnGUI()
    {
        if (triggered && showText)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 35;
            style.alignment = TextAnchor.MiddleCenter;
            style.wordWrap = true;
            DrawOutline(new Rect(Screen.width/2-150, Screen.height/2-25, 450, 50), badEventText, style, Color.black, Color.red, 3);
        }
    }

    //draw text of a specified color, with a specified outline color
    void DrawOutline(Rect position, string text, GUIStyle style, Color outColor, Color inColor, int outlineSize)
    {
        style.normal.textColor = outColor;

        for(int z = 1; z <= outlineSize+1; z++)
        {
            GUI.Label(new Rect(position.x - z,position.y,position.width,position.height), text, style);
            GUI.Label(new Rect(position.x + z, position.y, position.width, position.height), text, style);
            GUI.Label(new Rect(position.x, position.y - z, position.width, position.height), text, style);
            GUI.Label(new Rect(position.x, position.y + z, position.width, position.height), text, style);
        }

        style.normal.textColor = inColor;
        GUI.Label(position, text, style);
    }
}
