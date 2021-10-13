using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rigid;
    public GameObject selectionObj;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            rigid.velocity = new Vector3(h,0,v);
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
        if(RayUtility.CameraRaycast(out RaycastHit hit))
        {
            if(hit.collider.name == "Plane")
            {
                selectionObj.transform.position = hit.point;
            }
        }
    }
}
