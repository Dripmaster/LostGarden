using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ScreenShotManager : MonoBehaviour
{

    public string screenShotURL = "http://metagardeners.com/connect/capture/upload.php";


	public GameObject NextObj;
	public GameObject PrevObj;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
	public void onClick()
    {
		StartCoroutine(captureUpload());
    }
	public void NextBtn()
	{
		gameObject.SetActive(false);
		NextObj.SetActive(true);
	}
	public void PrevBtn()
	{

		gameObject.SetActive(false);
		PrevObj.SetActive(true);
	}
	IEnumerator captureUpload()
    {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();

		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Destroy(tex);

		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("fileDate", DateTime.Now.ToString(("yyyy-MM-dd")));
		string fName = PlaceUIManager.instatnce.nickName+"+"+ DateTime.Now.ToString("yyyy-MM-dd") + ".png";
		form.AddBinaryData("fileUpload", bytes, fName, "image/png");

		// Upload to a cgi script
		UnityWebRequest w = UnityWebRequest.Post(screenShotURL, form);
		yield return w.SendWebRequest();
		if (!string.IsNullOrEmpty(w.error))
		{
			print(w.error);
		}
		else
		{
			print("Finished Uploading Screenshot");
			string itemDataString = w.downloadHandler.text;
			print(itemDataString);
		}


	}
}
