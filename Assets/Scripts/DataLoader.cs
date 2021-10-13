using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
	public Text dataText;
	public InputField queryText;
	public GameObject Plant;
	
	public void Start()
    {
		getData();
    }
	public void StartData()
    {
		//StartCoroutine(DataPost());
		StartCoroutine(DataPlant());
	}
	public void getData()
	{
		//StartCoroutine(DataPost());
		StartCoroutine(DataPost());
	}

	IEnumerator DataPlant()
	{
		yield return null;
		string jsonStr = JsonUtility.ToJson(Plant.transform.position);
		
		string url = "http://meta-gardeners.com/connect/";
		WWWForm form = new WWWForm();
		string queryString = "UPDATE `placed_objects` SET `object_transform` = '" + jsonStr +"'";

		form.AddField("query", queryString);
		UnityWebRequest itemsData = UnityWebRequest.Post(url, form);
		//itemsData.downloadHandler = new DownloadHandlerBuffer();
		yield return itemsData.SendWebRequest();
		if (itemsData.error == null)
		{
			string itemDataString = itemsData.downloadHandler.text.Replace("\\", "");
			print(itemDataString);
			//dataText.text = itemDataString;
		}
		else
		{
			print(itemsData.error);
		}
		print(queryString);
	}


	IEnumerator DataPost()
	{
		yield return null;

		string url = "http://meta-gardeners.com/connect/";
		WWWForm form = new WWWForm();
		string queryString = "SELECT * FROM `placed_objects`";

		form.AddField("query", queryString);
		UnityWebRequest itemsData = UnityWebRequest.Post(url, form);
		//itemsData.downloadHandler = new DownloadHandlerBuffer();
		yield return itemsData.SendWebRequest();
		if (itemsData.error == null)
		{
			string itemDataString = itemsData.downloadHandler.text.Replace("\\", "");
			itemDataString = itemDataString.Split(new string[] { "{", "}" }, System.StringSplitOptions.None)[2];
			itemDataString = "{" + itemDataString + "}";
			Plant.transform.position = JsonUtility.FromJson<Vector3>(itemDataString);
			print(itemDataString);
			//dataText.text = itemDataString;
		}
		else
		{
			print(itemsData.error);
		}
		print(queryString);
	}
}