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

    public Camera canvasCamera;

    public static PlaceUIManager instatnce;
    // Start is called before the first frame update
    PlaceUIManager()
    {
        instatnce = this;
    }
    void Start()
    {
        ResolutionFix();
    }
    void ResolutionFix()
    {

        float targetWidthAspect = 16.0f;
        float targetHeightAspect = 9.0f;


        float targetWidthAspectPort = targetWidthAspect / targetHeightAspect;
        float targetHeightAspectPort = targetHeightAspect / targetWidthAspect;

        float currentWidthAspectPort = (float)Screen.width / (float)Screen.height;
        float currentHeightAspectPort = (float)Screen.height / (float)Screen.width;

        float viewPortW = targetWidthAspectPort / currentWidthAspectPort;
        float viewPortH = targetHeightAspectPort / currentHeightAspectPort;

        if (viewPortH > 1)
            viewPortH = 1;
        if (viewPortW > 1)
            viewPortW = 1;
        Camera.main.rect = new Rect(
            (1 - viewPortW) / 2,
            (1 - viewPortH) / 2,
            viewPortW,
            viewPortH);


        canvasCamera.rect = new Rect(
            (1 - viewPortW) / 2,
            (1 - viewPortH) / 2,
            viewPortW,
            viewPortH);
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
