using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BadEvent : MonoBehaviour {

    public GameObject target;
    bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
    }
	
	// Update is called once per frame
	void Update () {
		
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
        foreach(Transform t in target.GetComponentsInChildren<Transform>())
        {
            if(t.name != target.name)
            {
                t.localScale = new Vector3(t.localScale.x / 2, t.localScale.y, t.localScale.z);
            }
        }
        EditorUtility.DisplayDialog("Bad Stuff","You got bronze 5 in league","Ok");
        GetComponentInParent<ParticleSystem>().Stop();
    }
}
