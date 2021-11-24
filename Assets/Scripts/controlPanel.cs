using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanel : MonoBehaviour
{

    public static controlPanel instance;
    public PlacedObj pObj;
    public controlBar colorBar;
    public controlBar scaleBar;
    public controlBar rotBar;
    public controlBar heightBar;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(pObj!= null)
        {
            float amount = 0;
            amount = colorBar.amount;
            Color c;
            c = Color.HSVToRGB(amount,1,1);
            pObj.c = c;

            amount = scaleBar.amount;
            amount = amount*2+1;
            Vector3 s = pObj.transform.localScale;
            s.x = amount; s.z = amount;
            pObj.transform.localScale = s;


            amount = heightBar.amount;
            amount = amount * 2 + 1;
            s = pObj.transform.localScale;
            s.y = amount;
            pObj.transform.localScale = s;

            amount = rotBar.amount;
            amount *=360;
            amount -= 180;
            pObj.transform.rotation =Quaternion.Euler(0,amount,0);
        }
    }
    public void Init(PlacedObj p)
    {
        pObj = p;
        colorBar.init();
        scaleBar.init();
        rotBar.init();
        heightBar.init();
    }
    public void Init(PlacedObj p,ObjectTransform tmp)
    {
        pObj = p;
        Color.RGBToHSV(tmp.color, out float h, out float s, out float v);
        colorBar.init(h);
        scaleBar.init((tmp.scale.x-1)*0.5f);
        rotBar.init(((tmp.rot.eulerAngles.y)+180)/360);
        heightBar.init((tmp.scale.y - 1) * 0.5f);
    }
}
