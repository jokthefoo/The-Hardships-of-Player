using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailBoss : MonoBehaviour {

    public GameObject bossStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.name == "GroundCheck")
        {
            bossStart.GetComponent<BossStart>().resetFight();
        }
    }
}
