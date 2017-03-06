using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSprites : MonoBehaviour {

    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            int i = Random.Range(0, sprites.Length);
            s.sprite = sprites[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
