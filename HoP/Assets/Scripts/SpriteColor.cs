using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour {

    Color baseColor = Color.green;
    public Sprite BaseSprite;
	// Use this for initialization
	void Start ()
    {
        InitSprite();
	}

    void InitSprite()
    {
        Sprite temp = BaseSprite;
        Texture2D tempText = new Texture2D(temp.texture.width, temp.texture.height);
        Color color = Color.green;
        Color c;

        for (int y = 0; y < tempText.height; y++)
        {
            for (int x = 0; x < tempText.width; x++)
            {
                c = temp.texture.GetPixel(x, y);
                if (c == baseColor)
                {
                    tempText.SetPixel(x, y, color);
                }
                else if (c.g >= .5 && c.r < .5 && c.b < .5)
                {
                    tempText.SetPixel(x, y, new Color(color.r / 2, color.g / 2, color.b / 2));
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
        sr.sprite = Sprite.Create(tempText, sr.sprite.textureRect, new Vector2(0, 0));
        sr.sprite.name = "tempname";
        sr.material.mainTexture = tempText;
    }

    public void ChangeSprite(Color color)
    {
        Sprite temp = BaseSprite;
        Texture2D tempText = new Texture2D(temp.texture.width, temp.texture.height);
        Color c;

        for (int y = 0; y < tempText.height; y++)
        {
            for (int x = 0; x < tempText.width; x++)
            {
                c = temp.texture.GetPixel(x, y);
                if (c == baseColor)
                {
                    tempText.SetPixel(x, y, color);
                }
                else if (c.g >= .5 && c.r < .5 && c.b < .5)
                {
                    tempText.SetPixel(x, y, new Color(color.r / 2, color.g / 2, color.b / 2));
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
        sr.sprite = BaseSprite;
        sr.sprite = Sprite.Create(tempText, sr.sprite.textureRect, new Vector2(0, 0));
        sr.sprite.name = "tempname";
        sr.material.mainTexture = tempText;
    }

    // Update is called once per frame
    void Update () {
    }
}

class Points
{
    public int x { get; set; }
    public int y { get; set; }

    public override string ToString()
    {
        return string.Format("({0}, {1})", x, y);
    }
}
