using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoodEvent : MonoBehaviour {

    public enum State
    {
        friendMoveEvent,grow, dissapearTime, jumpHeight
    }
    
    public State current;
    public GameObject target;
    public GameObject player;
    public string goodEventText = "You made a new friend!";
    public float dissapearTime = 1.0f;
    public bool timedEvent = false;
    public float eventTimer = 0f;

    bool triggered;
    bool showText;
    float textTimer = 3.0f;

	// Use this for initialization
	void Start () {
        triggered = false;
        showText = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (triggered && showText)
        {
            textTimer -= Time.deltaTime;
            if (textTimer < 0)
            {
                showText = false;
            }
        }

        if (triggered && timedEvent)
        {
            eventTimer -= Time.deltaTime;
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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if(!triggered)
            {
                FriendGoodEvent();
            }
        }
    }

    void FriendGoodEvent()
    {
        triggered = true;
        showText = true;
        target.transform.position = new Vector3(-38, target.transform.position.y, target.transform.position.z);
        GetComponentInParent<ParticleSystem>().Stop();
    }

    void GenGoodEvent()
    {
        triggered = true;
        showText = true;
        if (current == State.grow)
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
                    f.timeOnPlatform = dissapearTime;
                }
            }
        }

        if (current == State.jumpHeight)
        {
            player.GetComponent<Rigidbody2D>().mass -= .01f;
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
            DrawOutline(new Rect(Screen.width/2-150, Screen.height/2-25, 450, 50), goodEventText, style, Color.black, Color.cyan, 3);
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
