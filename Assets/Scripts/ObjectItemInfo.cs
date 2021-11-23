using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ObjectItemInfo : ScriptableObject
{
    public string ObjectName;
    public GameObject _3DObject;
    public Sprite viewImage;
    public Sprite infoImage;
    public string infoString;

}
