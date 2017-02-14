using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    Renderer rend;
    BoxCollider2D[] colliders;
    bool unactive;
    bool touched;
    float disTimer;
    float standTimer;

    public float transparency = .3f;
    public float timeDisabled = 2.0f;
    public float timeOnPlatform = 1.0f;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        colliders = GetComponents<BoxCollider2D>();
        unactive = false;
        touched = false;
        disTimer = timeDisabled;
        standTimer = timeOnPlatform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(touched && !unactive)
        {
            standTimer -= Time.deltaTime;
            if (standTimer < 0)
            {
                rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, transparency);
                unactive = true;
                touched = false;
                colliders[0].enabled = false;
                colliders[1].enabled = false;
            }
        }

        if(unactive)
        {
            disTimer -= Time.deltaTime;

            if (disTimer < 0)
            {
                rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1.0f);
                unactive = false;
                standTimer = timeOnPlatform;
                disTimer = timeDisabled;
                colliders[0].enabled = true;
                colliders[1].enabled = true;
            }
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!touched && !unactive)
        {
            touched = true;
        }
    }
} 
