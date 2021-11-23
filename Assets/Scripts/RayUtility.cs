using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 레이케스트를 도와주는 클래스
 */
public class RayUtility
{
    static RayUtility()
    {//참조 초기화
    }
    public static bool isOnUI()
    {//터치 포인트가 UI위에 있는지 확인해준다.
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData ped = new PointerEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>());
        ped.position = Input.mousePosition;
        GameObject.Find("Canvas").GetComponent<GraphicRaycaster>().Raycast(ped, results);
        if (results.Count > 0)
        {
            return true;
        }
        return false;
    }
    public static bool CameraRaycast(out RaycastHit hit)
    {//보통 레이캐스트
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, 10000.0f, ~(1 << 6)))
        {
            return true;
        }
        return false;
    }
    public static bool MouseRaycast(out RaycastHit hit)
    {//보통 레이캐스트
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000.0f, ~(1 << 6)))
        {
            return true;
        }
        return false;
    }
}
