using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 �����ɽ�Ʈ�� �����ִ� Ŭ����
 */
public class RayUtility
{
    static RayUtility()
    {//���� �ʱ�ȭ
    }
    public static bool isOnUI()
    {//��ġ ����Ʈ�� UI���� �ִ��� Ȯ�����ش�.
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData ped = new PointerEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>());
        ped.position = Input.mousePosition;
        GameObject.Find("Canvas").GetComponent<GraphicRaycaster>().Raycast(ped, results);
        if (results.Count > 0)
        {
            return true;
        }
        try
        {

            GameObject.Find("3Dcanvas").GetComponent<GraphicRaycaster>().Raycast(ped, results);
        }
        catch
        {

        }
        if (results.Count > 0)
        {
            return true;
        }
        return false;
    }
    public static bool CameraRaycast(out RaycastHit hit)
    {//���� ����ĳ��Ʈ
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, 10000.0f, ~(1 << 6)))
        {
            return true;
        }
        return false;
    }
    public static bool MouseRaycast(out RaycastHit hit, int ignorelayer = 6)
    {//���� ����ĳ��Ʈ
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000.0f, ~(1 << ignorelayer)))
        {
            return true;
        }
        return false;
    }
}
