using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpriteSheetColor : MonoBehaviour
{

    public Sprite[] spriteSheet;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
    }

    public void ChangeSpriteSheet(Color color)
    {
        for(int i = 0; i < spriteSheet.Length; i++)
        {
            Texture2D tempText = new Texture2D(spriteSheet[i].texture.width, spriteSheet[i].texture.height);
            //Color color = Color.green;
            Color c;

            for (int x = 0; x < tempText.width; x++)
            {
                for (int y = 0; y < tempText.height; y++)
                {
                    c = spriteSheet[i].texture.GetPixel(x, y);
                    
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
            /*
            byte[] bytes = tempText.EncodeToPNG();
            string path = "HoP_Data/Resources/Sprite Sheet.png";
#if UNITY_EDITOR
            Debug.Log("editor");
            path = "Assets/Resources/Sprite Sheet.png";
#endif

            //Resources.Load("Sprite Sheet") = tempText;
            File.WriteAllBytes(path, bytes);
            */

            Rect tempRect = new Rect(0, 0, spriteSheet[i].rect.width, spriteSheet[i].rect.height);
            spriteSheet[i] = Sprite.Create(tempText, tempRect, new Vector2(.5f, .5f));
            spriteSheet[i].name = "Sprite Sheet_"+i;
            Vars.sprites.Add(spriteSheet[i]);
            Vars.text = tempText;
            //SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            //sr.material.mainTexture = tempText;

#if UNITY_EDITOR
            //UnityEditor.AssetDatabase.Refresh();
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
