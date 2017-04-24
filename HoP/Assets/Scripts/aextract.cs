using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class aextract : MonoBehaviour {
    public Sprite[] sheet;
    // Use this for initialization
    void Start () {
        print(sheet.Length);
        int i = 0;
        foreach (Sprite sprite in sheet)
        {
            Texture2D tex = sprite.texture;
            Rect r = sprite.textureRect;
            Texture2D subtex = tex.CropTexture((int)r.x, (int)r.y, (int)r.width, (int)r.height);
            byte[] data = subtex.EncodeToPNG();
            File.WriteAllBytes(Application.persistentDataPath + "/" + i + ".png", data);
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
