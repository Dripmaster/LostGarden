using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class controlBar : MonoBehaviour
{
    public Image centerBar;
    public Image ColorcenterBar;
    // Start is called before the first frame update
    void Start()
    {
        isDragging = false;
        
    }
    bool isDragging;
    Vector3 tmpPos;
    public float amount;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!isDragging && isOn3DUI(out RaycastResult result))
            {
                if(result.gameObject == gameObject || result.gameObject == centerBar.gameObject)
                {
                    isDragging = true;
                    Vector3 pos = centerBar.transform.localPosition;
                    pos.x = (((result.worldPosition.x-10.4f)/6)-0.5f)*316;
                    centerBar.transform.localPosition = pos;
                    tmpPos = Input.mousePosition;
                }
                else
                {
                }
            }
        }
        else
        {
            if (isDragging)
            {
                if (isOn3DUI(out RaycastResult r))
                {
                    Vector3 pos = centerBar.transform.localPosition;
                    pos.x = (((r.worldPosition.x - 10.4f) / 6) - 0.5f) * 316;
                    centerBar.transform.localPosition = pos;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        Vector3 p = centerBar.transform.localPosition;
        if (p.x <= -316/2)
            p.x = -316/2;
        if (p.x >= 316 / 2)
            p.x = 316 / 2;
        if(ColorcenterBar)
        amount = (p.x + 316 / 2-30) / 316;
        else
        {
            amount = (p.x + 316 / 2) / 316;
        }
        amount = Mathf.Clamp(amount,0,1);
        centerBar.transform.localPosition = p;
        if(ColorcenterBar)
        ColorcenterBar.color = Color.HSVToRGB(amount, 1, 1);
    }
    public void init()
    {

        Vector3 p = centerBar.transform.localPosition;
        p.x = 0;
        centerBar.transform.localPosition = p;
    }
    public void init(float amount)
    {

        Vector3 p = centerBar.transform.localPosition;
        if (ColorcenterBar)
            p.x = amount * 316 - 316 / 2 + 30;
        else
        {

            p.x = amount * 316 - 316 / 2;
        }
        centerBar.transform.localPosition = p;
    }
    public static bool isOn3DUI(out RaycastResult result)
    {//터치 포인트가 UI위에 있는지 확인해준다.
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData ped = new PointerEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>());
        ped.position = Input.mousePosition;
        GameObject.Find("3Dcanvas").GetComponent<GraphicRaycaster>().Raycast(ped, results);
        if (results.Count > 0)
        {
            result = results[0];
            return true;
        }
        result = new RaycastResult();
        return false;
    }
}
