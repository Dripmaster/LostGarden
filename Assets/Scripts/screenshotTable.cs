using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class screenshotTable : MonoBehaviour
{
    public GameObject imageBoxPrefab;
    
    string url = "http://metagardeners.com/connect/capture/getFiles.php";
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(getFileNames());
    }
    IEnumerator getFileNames()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.error == null)
        {
            string itemDataString = www.downloadHandler.text;
           
            string[] fileNames = itemDataString.Split('\n');
            foreach (var item in fileNames)
            {
                item.Replace("\n", "");
                if (item.Length<=0)
                    continue;
                var g = Instantiate(imageBoxPrefab, transform);
                g.GetComponent<screenImage>().Init(item);
            }
        }
    }
}
