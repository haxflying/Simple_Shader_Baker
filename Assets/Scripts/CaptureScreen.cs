using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Camera))]
public class CaptureScreen : MonoBehaviour
{
    private Camera cam;
    private Texture2D captureTexture;

    public string savePath;

    public void Save()
    {
        cam = GetComponent<Camera>();
        captureTexture = new Texture2D(cam.pixelWidth, cam.pixelHeight, TextureFormat.ARGB32, false, false);
        
        StartCoroutine(Capture());
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
#if UNITY_EDITOR
        if(savePath == string.Empty)
        {
            savePath = EditorUtility.SaveFilePanelInProject("Save Texture", "Prefab_Baked_Tex", "tga", "");
        }

        if(savePath == string.Empty)
        {
            yield return null;
        }
        else
        {
            captureTexture.ReadPixels(new Rect(0, 0, cam.pixelWidth, cam.pixelHeight), 0, 0, false);
            captureTexture.Apply();

            byte[] bytes = captureTexture.EncodeToTGA();
            System.IO.File.WriteAllBytes(savePath, bytes);

            AssetDatabase.Refresh();
        }
#endif
    }
}
