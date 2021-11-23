using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    public ObjectItemInfo info;

    public Image noneImage;
    public Image backImage;
    public Image FillImage;
    public Text contentText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(ObjectItemInfo o, string initString)
    {
        info = o;

        if(o.viewImage != null)
        {
            FillImage.sprite = o.viewImage;
        }
        else
        {
            noneImage.enabled = true;
            backImage.enabled = false;
            FillImage.enabled = false;
        }
        contentText.text = o.ObjectName;


        FillImage.name = initString;
        contentText.name = initString;
        backImage.name = initString;
        noneImage.name = initString;
        name = initString;
    }
}
