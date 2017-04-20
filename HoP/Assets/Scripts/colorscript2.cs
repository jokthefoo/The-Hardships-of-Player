using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorscript2 : MonoBehaviour
{

    public Sprite BaseSprite;
    // Use this for initialization
    void Start()
    {
        InitSprite();
    }

    void InitSprite()
    {
        Sprite temp = BaseSprite;
        Texture2D tempText = new Texture2D(temp.texture.width, temp.texture.height);
        //print("Width: " + temp.texture.width + " Height: " + temp.texture.height + " rect: " + GetComponent<SpriteRenderer>().sprite.textureRect);
        Color color = Color.green;
        Color c;

        for (int y = 0; y < tempText.height; y++)
        {
            for (int x = 0; x < tempText.width; x++)
            {
                c = temp.texture.GetPixel(x, y);
                if (c.r > 0.8 && c.g < 0.1 && c.b < 0.1)
                {
                    tempText.SetPixel(x, y, new Color(color.r / 4, color.g / 4, color.b / 4, c.a));
                }
                else if (c.r > 0.8 && c.g > 0.4 && c.b < 0.1)
                {
                    tempText.SetPixel(x, y, new Color(color.r / 3, color.g / 3, color.b / 3, c.a));
                }
                else if (c.r < 0.4 && c.g < 0.4 && c.b < 0.1 && c.a > 0)
                {
                    tempText.SetPixel(x, y, new Color(color.r / 2, color.g / 2, color.b / 2, c.a));
                }
                else if (c == Color.white)
                {
                    tempText.SetPixel(x, y, new Color(0, 0, 0, 0));
                }
                else
                {
                    tempText.SetPixel(x, y, c);
                }
            }
        }
        tempText.Apply();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Rect tempRect = new Rect(0, 0, 36, 15);
        //sr.sprite.textureRect
        sr.sprite = Sprite.Create(tempText, tempRect, new Vector2(0, 0));
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
                if (c.r > 0.8 && c.g < 0.1 && c.b < 0.1)
                {
                    tempText.SetPixel(x, y, new Color(color.r , color.g , color.b , c.a));
                }
                else if (c.r > 0.8 && c.g > 0.4 && c.b < 0.1)
                {
                    tempText.SetPixel(x, y, new Color(color.r / 2 , color.g / 2 , color.b / 2 , c.a));
                }
                else if (c.r < 0.4 && c.g < 0.4 && c.b < 0.1 && c.a > 0)
                {
                    if(color.r < .2 && color.g < .2 && color.b < .2)
                    {
                        tempText.SetPixel(x, y, Color.white);
                    }
                    else
                    {
                        tempText.SetPixel(x, y, new Color(color.r / 3, color.g / 3, color.b / 3, c.a));
                    }
                }
                else if (c == Color.white)
                {
                    tempText.SetPixel(x, y, new Color(0, 0, 0, 0));
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
        Rect tempRect = new Rect(0, 0, 36, 15);
        //sr.sprite.textureRect
        sr.sprite = Sprite.Create(tempText, tempRect, new Vector2(0, 0));
        sr.sprite.name = "tempname";
        sr.material.mainTexture = tempText;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
