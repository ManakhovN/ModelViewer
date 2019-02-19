using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewUtils : MonoBehaviour
{
    static int previewWidth = 300;
    static int previewHeight = 300;

    public static Sprite LoadPreview(UnityEngine.Object obj)
    {
        Texture2D tex = null;
        try
        {
            tex = LoadPreviewFromFile(obj.name);
        }
        catch (Exception e) {
            tex = MakePreview(obj);
        }
        Sprite spr = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one / 2f);
        return spr;
    }

    public static Texture2D MakePreview(UnityEngine.Object obj)
    {
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/previews/");
        var camera = Camera.main;
        GameObject go = Instantiate(obj) as GameObject;
        RenderTexture rt = new RenderTexture(previewWidth, previewHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(previewWidth, previewHeight, TextureFormat.RGB24, false);
        camera.GetComponent<ScreenFitter>().ChangeModel(go);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, previewWidth, previewHeight), 0, 0);
        camera.targetTexture = null;
        Destroy(go);
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = GenerateScreenshotName(obj.name);
        System.IO.File.WriteAllBytes(filename, bytes);
        return LoadPreviewFromFile(obj.name);
    }

    public static Texture2D LoadPreviewFromFile(string name) {
        var bytes = System.IO.File.ReadAllBytes(GenerateScreenshotName(name));
        Texture2D preview = new Texture2D(2, 2);
        preview.LoadImage(bytes);
        return preview;
    }

    private static string GenerateScreenshotName(string name)
    {
        Debug.Log(Application.persistentDataPath + "/previews/" + name + ".png");
        return Application.persistentDataPath + "/previews/" + name + ".png";
    }
}
