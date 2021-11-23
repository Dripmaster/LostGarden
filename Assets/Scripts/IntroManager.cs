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
}
