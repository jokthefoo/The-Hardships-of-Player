using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour {

    public GameObject _destroyPoint;
	// Use this for initialization
	void Start () {
		if (_destroyPoint == null)
        {
            _destroyPoint = GameObject.Find("DestroyLimit");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < _destroyPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
