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
    public static bool CameraRaycast(out RaycastHit hit)
    {//보통 레이캐스트
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, 10000.0f, ~(1 << 6)))
        {
            return true;
        }
        return false;
    }
}
