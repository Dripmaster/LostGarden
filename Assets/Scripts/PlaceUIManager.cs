using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUIManager : MonoBehaviour
{
    public GameObject HowToUI;
    public GameObject Hint1;
    public GameObject Hint2;

    public GameObject[] ZoneSelectBtns;

    public string nickName;

    public static PlaceUIManager instatnce;
    // Start is called before the first frame update
    PlaceUIManager()
    {
        instatnce = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Screen.fullScreen = true;
    }

    public void NextBtn1()
    {
        HowToUI.SetActive(false);
        Hint1.SetActive(true);
    }
    public void SetName(string n)
    {
        foreach (var b in ZoneSelectBtns)
        {
            b.SetActive(false);
        }
        Hint2.SetActive(true);
        nickName = n;

    }
    public void OnNameBtn()
    {
        foreach (var b in ZoneSelectBtns)
        {
            b.SetActive(true);
        }
    }
}
