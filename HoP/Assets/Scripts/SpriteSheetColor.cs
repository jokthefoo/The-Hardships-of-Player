using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpriteSheetColor : MonoBehaviour {

    public Sprite spriteSheet;
    public GameObject player;

    // Use this for initialization
    void Start () {
    }

    public void ChangeSpriteSheet(Color color)
    {
            Texture2D tempText = new Texture2D(spriteSheet.texture.width, spriteSheet.texture.height);
            //Color color = Color.green;
            Color c;

            for (int y = 0; y < tempText.height; y++)
            {
                for (int x = 0; x < tempText.width; x++)
                {
                    c = spriteSheet.texture.GetPixel(x, y);

                    //if (c == baseColor)
                    if (c.r < 0.1 && c.g < 0.1 && c.b < 0.1 && c.a > 0)
                    {
                        tempText.SetPixel(x, y, new Color(color.r / 4, color.g / 4, color.b / 4));
                    }
                    else if (c.r < 0.2 && c.g < 0.2 && c.b < 0.2 && c.a > 0)
                    {
                        tempText.SetPixel(x, y, new Color(color.r / 3, color.g / 3, color.b / 3));
                    }
                    else if (c.r < 0.4 && c.g < 0.4 && c.b < 0.4 && c.a > 0)
                    {
                        tempText.SetPixel(x, y, new Color(color.r / 2, color.g / 2, color.b / 2));
                    }
                    else if (c.r < 0.63 && c.g < 0.63 && c.b < 0.63 && c.a > 0)
                    {
                        tempText.SetPixel(x, y, color);
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

            byte[] bytes = tempText.EncodeToPNG();
           // File.WriteAllBytes(Application.dataPath + "/../Assets/Sprite Sheet.png", bytes);
        

            SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            Rect tempRect = new Rect(0, 0, spriteSheet.rect.width, spriteSheet.rect.height);
            //sr.sprite.textureRect
            spriteSheet = Sprite.Create(tempText, tempRect, new Vector2(0, 0));
            spriteSheet.name = "Sprite Sheet_2";
            sr.material.mainTexture = tempText;
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
