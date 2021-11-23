using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneSelectButton : MonoBehaviour
{
    public GameObject NextBTN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Selected()
    {
        gameObject.SetActive(false);
        NextBTN.SetActive(true);
    }
    public void SetName()
    {
        PlaceUIManager.instatnce.SetName(transform.parent.GetComponentInChildren<InputField>().text);
    }
}
