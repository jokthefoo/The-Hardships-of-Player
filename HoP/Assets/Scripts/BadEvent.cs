using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BadEvent : MonoBehaviour {

    public GameObject target;
    public string badEventText = "You smell really bad today.\n So yellow has been avoiding you.";

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
		if(triggered && showText)
        {
            textTimer -= Time.deltaTime;
            if(textTimer < 0)
            {
                showText = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if(!triggered)
                MomBadEvent();
        }
    }

    void MomBadEvent()
    {
        triggered = true;
        showText = true;
        foreach (Transform t in target.GetComponentsInChildren<Transform>())
        {
            if(t.name != target.name)
            {
                t.localScale = new Vector3(t.localScale.x / 2, t.localScale.y, t.localScale.z);
            }
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
