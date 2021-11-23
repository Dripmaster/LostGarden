using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
	public Text dataText;
	public InputField queryText;
	public PlacedObj Plant;

	string url = "http://metagardeners.com/connect/";

	string queryString;

	Coroutine currentConnect;

	public UserInfo[] users;
	public PlacedObject[] placedObjects;
	public Zone[] zones;

	public void Start()
    {
		getData();
    }
	public void sendData()
    {
		StartCoroutine(DataPlant());
	}
	public void getData()
	{
		//StartCoroutine(DataPost());
		//StartCoroutine(DataPost());
	}
	public void getUsersData(bool isOnline =true)
	{ 
		queryString = "SELECT * FROM `users`";
		if (isOnline)
		queryString += " where online_status = 1";
		queryString +=";";
		currentConnect = StartCoroutine(getDataConnect(0));
	}
	public void getObjectsData()
	{
		queryString = "SELECT * FROM `placed_objects`";
		queryString += ";";
		currentConnect = StartCoroutine(getDataConnect(1));
	}
	public void getZoneData()
	{
		queryString = "SELECT * FROM `zone`";
		queryString += ";";
		currentConnect = StartCoroutine(getDataConnect(2));
	}
	IEnumerator getDataConnect(int dataType)
    {
		WWWForm form = new WWWForm();
		form.AddField("query", queryString);
		UnityWebRequest itemsData = UnityWebRequest.Post(url, form);
		//itemsData.downloadHandler = new DownloadHandlerBuffer();
		yield return itemsData.SendWebRequest();
		if (itemsData.error == null)
		{
			string itemDataString = itemsData.downloadHandler.text;
			itemDataString = itemDataString.Replace("\"{\\","{");
			itemDataString = itemDataString.Replace("}\"","}");
			itemDataString = itemDataString.Replace("\\", "");
			itemDataString = "{\"items\":" + itemDataString + "}";

			print(itemDataString);

            switch (dataType)
            {
				case 0:
					users = JsonHelper.FromJson<UserInfo>(itemDataString);
					break;
				case 1:
					placedObjects = JsonHelper.FromJson<PlacedObject>(itemDataString);
					print(placedObjects[0].object_transform.pos);
					print(placedObjects[0].object_id);
					print(placedObjects[0].object_kind_id);
					break;
				case 2:
					zones = JsonHelper.FromJson<Zone>(itemDataString);
					break;
                default:
                    break;
            }
		}
		else
		{
		}
	}
	




	IEnumerator DataPlant()
	{
		yield return null;
		string jsonStr = JsonUtility.ToJson(Plant.objectTransform);
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

[Serializable]
public class UserInfo
{
	public string nickname;
	public int id_user;
	public int online_status;
	public string online_pos;
}
[Serializable]
public class PlacedObject
{
	public int object_id;
	public int object_kind_id;
	public ObjectTransform object_transform;
	public int object_userid;
}
[Serializable]
public class ObjectTransform
{
	public Vector3 pos;
	public Quaternion rot;
	public Vector3 scale;
	public Color color;
	public int zone_id;
}

[Serializable]
public class Zone
{
	public string zone_name;
	public int zone_weather;
	public int zone_id;
}




public static class JsonHelper
{
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.items;
	}
    public static string ToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.items = array;
		return JsonUtility.ToJson(wrapper);
	}
    public static string ToJson<T>(T[] array, bool prettyPrint)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.items = array;
		return JsonUtility.ToJson(wrapper, prettyPrint);
	}
    [Serializable]
	private class Wrapper<T>
	{
		public T[] items;
	}
}







