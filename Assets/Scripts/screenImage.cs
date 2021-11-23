using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class screenImage : MonoBehaviour
{
    string url = "http://metagardeners.com/connect/capture/";
    Image myImage;
    public Text myText;
    string fileN = "screenShot.png";
    private void Awake()
    {
    }
    public void Init(string fileName)
    {
        myImage = GetComponent<Image>();
        fileN = fileName;
        StartCoroutine(GetTexture());
    }
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url+ fileN);
        yield return www.SendWebRequest();

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            myImage.sprite =  Sprite.Create((Texture2D)myTexture, new Rect(0.0f, 0.0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            string n =  fileN.Split('/')[1];
            myText.text = n.Replace('+',' ').Split('.')[0];
        }
    }
}
