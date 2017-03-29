using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour {

    Color baseColor = Color.green;
	// Use this for initialization
	void Start () {
       
	}

    void ChangeSprite()
    {
        Sprite temp = GetComponent<SpriteRenderer>().sprite;
        Texture2D tempText = new Texture2D(temp.texture.width, temp.texture.height);

        Color c;

        for (int y = 0; y < tempText.height; y++)
        {
            for (int x = 0; x < tempText.width; x++)
            {
                c = temp.texture.GetPixel(x, y);
                if (c == baseColor)
                {
                    tempText.SetPixel(x, y, Color.red);
                }
                else if (c.g < .5 && c.r < .5 && c.b > .5)
                {
                    tempText.SetPixel(x, y, new Color(c.b, c.g, c.r));
                }
                else if(c.g > .5 && c.r < .5 && c.b < .5)
                {
                    tempText.SetPixel(x, y, new Color(c.g, c.r, c.b));
                }else if(c == Color.white)
                {
                    if( x > 73 && x < 130 && y > 100 && y < 125)
                    {
                        tempText.SetPixel(x, y, Color.white);
                    }
                    else
                    {
                        tempText.SetPixel(x, y, new Color(0, 0, 0, 0));
                    }
                }
                else
                {
                    tempText.SetPixel(x, y, c);
                }

            }
        }
        tempText.Apply();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        print(sr.sprite.pivot);
        sr.sprite = Sprite.Create(tempText, sr.sprite.textureRect, new Vector2(0,0));
        sr.sprite.name = "tempname";
        sr.material.mainTexture = tempText;
        baseColor = Color.red;
    }

    void ChangeSpriteBlue()
    {
        Sprite temp = GetComponent<SpriteRenderer>().sprite;
        Texture2D tempText = new Texture2D(temp.texture.width, temp.texture.height);

        Color c;

        for (int y = 0; y < tempText.height; y++)
        {
            for (int x = 0; x < tempText.width; x++)
            {
                c = temp.texture.GetPixel(x, y);
                if (c == baseColor)
                {
                    tempText.SetPixel(x, y, Color.blue);
                }
                else if (c.g < .5 && c.r > .5 && c.b < .5)
                {
                    tempText.SetPixel(x, y, new Color(c.b, c.g, c.r));
                }
                else if (c.g > .5 && c.r < .5 && c.b < .5)
                {
                    tempText.SetPixel(x, y, new Color(c.r, c.b, c.g));
                }
                else if (c == Color.white)
                {
                    if (x > 73 && x < 130 && y > 100 && y < 125)
                    {
                        tempText.SetPixel(x, y, Color.white);
                    }
                    else
                    {
                        tempText.SetPixel(x, y, new Color(0, 0, 0, 0));
                    }
                }
                else
                {
                    tempText.SetPixel(x, y, c);
                }

            }
        }
        tempText.Apply();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        print(sr.sprite.pivot);
        sr.sprite = Sprite.Create(tempText, sr.sprite.textureRect, new Vector2(0, 0));
        sr.sprite.name = "tempname";
        sr.material.mainTexture = tempText;
        baseColor = Color.blue;
    }

    void ChangeSpriteGreen()
    {
        Sprite temp = GetComponent<SpriteRenderer>().sprite;
        Texture2D tempText = new Texture2D(temp.texture.width, temp.texture.height);

        Color c;

        for (int y = 0; y < tempText.height; y++)
        {
            for (int x = 0; x < tempText.width; x++)
            {
                c = temp.texture.GetPixel(x, y);
                if (c == baseColor)
                {
                    tempText.SetPixel(x, y, Color.green);
                }
                else if (c.g < .5 && c.r > .5 && c.b < .5)
                {
                    tempText.SetPixel(x, y, new Color(c.g, c.r, c.b));
                }
                else if (c.g < .5 && c.r < .5 && c.b > .5)
                {
                    tempText.SetPixel(x, y, new Color(c.r, c.b, c.g));
                }
                else if (c == Color.white)
                {
                    if (x > 73 && x < 130 && y > 100 && y < 125)
                    {
                        tempText.SetPixel(x, y, Color.white);
                    }
                    else
                    {
                        tempText.SetPixel(x, y, new Color(0, 0, 0, 0));
                    }
                }
                else
                {
                    tempText.SetPixel(x, y, c);
                }

            }
        }
        tempText.Apply();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        print(sr.sprite.pivot);
        sr.sprite = Sprite.Create(tempText, sr.sprite.textureRect, new Vector2(0, 0));
        sr.sprite.name = "tempname";
        sr.material.mainTexture = tempText;
        baseColor = Color.green;
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.R))
        {
            ChangeSprite();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeSpriteBlue();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeSpriteGreen();
        }
    }
}
