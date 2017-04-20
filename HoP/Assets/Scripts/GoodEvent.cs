using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class GoodEvent : MonoBehaviour
{

    public enum State
    {
        friendMoveEvent, grow, dissapearTime, jumpHeight
    }

    public State current;
    public GameObject target;
    public GameObject player;
    public string goodEventText = "You made a new friend!";
    public float dissapearTime = 1.0f;
    public bool timedEvent = false;
    public float eventTimer = 0f;
    public Canvas eventCanvas;
    public Canvas timerCanvas;

    bool triggered;
    bool showText;
    bool showCanvas;
    float textTimer = 4.0f;

    // Use this for initialization
    void Start()
    {
        triggered = false;
        showText = false;
        showCanvas = false;
        if (eventCanvas.gameObject.activeSelf)
        {
            eventCanvas.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && showText)
        {
            textTimer -= Time.deltaTime;
            if (textTimer < 0)
            {
                showText = false;
            }
        }

        if (triggered && showCanvas)
        {
            textTimer -= Time.deltaTime;
            if (textTimer < 0)
            {
                showCanvas = false;
                eventCanvas.gameObject.SetActive(false);
            }
        }

        if (triggered && timedEvent)
        {
            eventTimer -= Time.deltaTime;
            foreach (Text t in timerCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "TimerText")
                    t.text = "" + eventTimer.ToString("F1");
            }
            if (eventTimer < 0)
            {
                if (current == State.grow)
                {
                    foreach (Transform t in target.GetComponentsInChildren<Transform>())
                    {
                        if (t.name != target.name)
                        {
                            t.localScale = new Vector3(t.localScale.x / 2, t.localScale.y, t.localScale.z);
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
                    player.GetComponent<Rigidbody2D>().mass += .01f;
                }
                timedEvent = false;
                timerCanvas.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.name == "GroundCheck" && coll.gameObject.GetComponentInParent<PlatformerCharacter2D>().getGrounded())
        {
            if (!triggered)
            {
                GenGoodEvent();
                eventCanvas.gameObject.SetActive(true);
                showCanvas = true;
                //Time.timeScale = 0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.transform.name == "GroundCheck" && coll.gameObject.GetComponentInParent<PlatformerCharacter2D>().getGrounded())
        {
            if (!triggered)
            {
                GenGoodEvent();
                eventCanvas.gameObject.SetActive(true);
                showCanvas = true;
                //Time.timeScale = 0f;
            }
        }
    }

    void GenGoodEvent()
    {
        String message = "";
        if (timedEvent)
        {
            timerCanvas.gameObject.SetActive(true);
            foreach (Text t in timerCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "TimerText")
                    t.text = "" + eventTimer.ToString("F1");
            }
            message = " For " + eventTimer + " seconds.";
        }
        triggered = true;
        //showText = true;
        if (current == State.grow)
        {
            foreach (Transform t in target.GetComponentsInChildren<Transform>())
            {
                if (t.name != target.name)
                {
                    t.localScale = new Vector3(t.localScale.x * 2, t.localScale.y, t.localScale.z);
                }
            }
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = goodEventText + "\n(Their platforms have grown!)" + message;
            }
            //EditorUtility.DisplayDialog("Good Event! :)", goodEventText + "\n(Their platforms have grown!)" + message, "Ok");
        }

        if (current == State.friendMoveEvent)
        {
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = goodEventText + "\n(A new friend's platforms have appeared!)";
            }
            //EditorUtility.DisplayDialog("Good Event! :)", goodEventText + "\n(A new friend's platforms have appeared!)", "Ok");
            target.transform.position = new Vector3(target.transform.position.x - 38, target.transform.position.y, target.transform.position.z);
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
                    t.text = goodEventText + "\n(Their platforms disappear slower!)" + message;
            }
            //EditorUtility.DisplayDialog("Good Event! :)", goodEventText + "\n(Their platforms disappear slower!)" + message, "Ok");
        }

        if (current == State.jumpHeight)
        {
            player.GetComponent<Rigidbody2D>().mass -= .01f;
            foreach (Text t in eventCanvas.GetComponentsInChildren<Text>())
            {
                if (t.name == "MainText")
                    t.text = goodEventText + "\n(You can jump higher!)" + message;
            }
            //EditorUtility.DisplayDialog("Good Event! :)", goodEventText + "\n(You can jump higher!)" + message, "Ok");
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
            DrawOutline(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 450, 50), goodEventText, style, Color.black, Color.cyan, 3);
        }
    }

    //draw text of a specified color, with a specified outline color
    void DrawOutline(Rect position, string text, GUIStyle style, Color outColor, Color inColor, int outlineSize)
    {
        style.normal.textColor = outColor;

        for (int z = 1; z <= outlineSize + 1; z++)
        {
            GUI.Label(new Rect(position.x - z, position.y, position.width, position.height), text, style);
            GUI.Label(new Rect(position.x + z, position.y, position.width, position.height), text, style);
            GUI.Label(new Rect(position.x, position.y - z, position.width, position.height), text, style);
            GUI.Label(new Rect(position.x, position.y + z, position.width, position.height), text, style);
        }

        style.normal.textColor = inColor;
        GUI.Label(position, text, style);
    }
}
