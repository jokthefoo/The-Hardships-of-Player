using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatformSpawn : MonoBehaviour {

    public GameObject _platform;
    public int _numberOfPlatforms;
    public Transform _genPoint;
    public float _minDistanceBetween;
    public float _maxDistanceBetween;
    public float _xDeviation = 10;

    private float _platformHeight;
    private float _startingXPos;
	// Use this for initialization
	void Start () {
        _platformHeight = _platform.GetComponent<BoxCollider2D>().size.y;
        _startingXPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < _genPoint.position.y)
        {
            for (int i = 0; i < _numberOfPlatforms; i++)
            {
                float distanceBetweenY = Random.Range(_minDistanceBetween, _maxDistanceBetween);
                //Debug.Log(distanceBetweenY.ToString());
                float randomXPos = Random.Range(-_xDeviation,_xDeviation);
                //Debug.Log(randomXPos.ToString());
                //Debug.Log((_platformHeight).ToString());
                transform.position = new Vector3(_startingXPos + randomXPos, transform.position.y + _platformHeight + distanceBetweenY, transform.position.z);
                Instantiate(_platform, transform.position, transform.rotation);
            }
        }
	}
}
