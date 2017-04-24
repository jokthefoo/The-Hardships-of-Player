using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteUpdaterFriend : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        Sprite[] subsprites = new Sprite[Vars.fsprites.Count];
        subsprites = Vars.fsprites.ToArray();
        /*for(int i = 0; i < subsprites.Length; i++)
        {
            subsprites[i] = (Sprite)Vars.sprites[i];
        }*/
        //Resources.LoadAll<Sprite>("Sprite Sheet");

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spritename = renderer.sprite.name;
            var newSprite = Array.Find(subsprites, item => item.name == spritename);

            if (newSprite)
            {
                renderer.sprite = newSprite;
                renderer.material.mainTexture = Vars.ftext;
            }
        }
    }
}
