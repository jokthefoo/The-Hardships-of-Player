using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatformSpawn : MonoBehaviour
{

    public GameObject[] _platforms;
    public GameObject[] parents;
    public GameObject player;
    public Canvas eventCanvas;
    public Canvas timerCanvas;
    public int _numberOfPlatforms;
    public Transform _genPoint;
    public float _minDistanceBetween;
    public float _maxDistanceBetween;
    public float _xDeviation = 10;

    private float _platformHeight;
    private float _startingXPos;
    // Use this for initialization
    void Start()
    {
        _platformHeight = _platforms[0].GetComponent<BoxCollider2D>().size.y;
        _startingXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < _genPoint.position.y)
        {
            for (int i = 0; i < _numberOfPlatforms; i++)
            {
                float distanceBetweenY = Random.Range(_minDistanceBetween, _maxDistanceBetween);
                //Debug.Log(distanceBetweenY.ToString());
                float randomXPos = Random.Range(-_xDeviation, _xDeviation);
                //Debug.Log(randomXPos.ToString());
                //Debug.Log((_platformHeight).ToString());
                transform.position = new Vector3(_startingXPos + randomXPos, transform.position.y + _platformHeight + distanceBetweenY, transform.position.z);

                int x = Random.Range(0, 5);

                int z = Random.Range(0, 50);
                if (z == 25)
                {
                    x = 5;
                }
                else if (z == 0)
                {
                    x = 6;
                }

                GameObject g = Instantiate(_platforms[x], transform.position, transform.rotation);
                g.AddComponent<DestroyPlatform>();

                if(x < 5)
                {
                    g.transform.parent = parents[x].transform;
                }

                if (g.gameObject.name.Contains("good"))
                {
                    GoodEvent script = g.GetComponent<GoodEvent>();
                    script.eventCanvas = eventCanvas;
                    script.timerCanvas = timerCanvas;
                    script.player = player;

                    if (Random.Range(0, 1) > .5)
                    {
                        script.timedEvent = true;
                        script.eventTimer = Random.Range(10, 31);
                    }

                    script.target = parents[Random.Range(0, parents.Length)];

                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            script.current = GoodEvent.State.grow;
                            break;
                        case 1:
                            script.current = GoodEvent.State.dissapearTime;
                            script.dissapearTime = 2;
                            break;
                        case 2:
                            script.current = GoodEvent.State.jumpHeight;
                            break;
                    }
                }
                else if (g.gameObject.name.Contains("bad"))
                {
                    BadEvent script = g.GetComponent<BadEvent>();
                    script.eventCanvas = eventCanvas;
                    script.timerCanvas = timerCanvas;
                    script.player = player;

                    if (Random.Range(0, 1) > .5)
                    {
                        script.timedEvent = true;
                        script.eventTimer = Random.Range(10, 31);
                    }

                    script.target = parents[Random.Range(0, parents.Length)];

                    switch (Random.Range(0, 4))
                    {
                        case 0:
                            script.current = BadEvent.State.shrink;
                            break;
                        case 1:
                            script.current = BadEvent.State.dissapearTime;
                            script.dissapearTime = 0.5f;
                            break;
                        case 2:
                            script.current = BadEvent.State.jumpHeight;
                            script.timedEvent = true;
                            script.eventTimer = Random.Range(10, 31);
                            break;
                        case 3:
                            script.current = BadEvent.State.clingy;
                            script.timedEvent = true;
                            script.eventTimer = Random.Range(10, 31);
                            break;
                    }
                }
            }
        }
    }
}
