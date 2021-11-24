    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    public GameObject StartUI;
    public GameObject SynopsisUI;
    public GameObject SelectUI;
    public GameObject TitleUI;
    public GameObject Bubble;


    // Start is called before the first frame update
    void Start()
    {
        ResolutionFix();
    }

    // Update is called once per frame
    void Update()
    {

        //Screen.fullScreen = true;
    }
    public void StartBtn()
    {
        StartUI.SetActive(false);
        Bubble.SetActive(false);
        TitleUI.SetActive(false);
        SynopsisUI.SetActive(true);
    }
    public void NextBtn()
    {
        SynopsisUI.SetActive(false);
        SelectUI.SetActive(true);
    }
    public void SelectBtn(int v)
    {
        if (v == 1)
        {
            SceneLoader.ChangeScene(1);
        }
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

    }
}
