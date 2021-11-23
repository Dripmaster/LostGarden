using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rigid;
    public GameObject selectionObj;

    bool EditMode;



    void Awake()
    {
        EditMode = false;
        rigid = GetComponent<Rigidbody>();
        //Screen.fullScreen = true;
    }

    void Update()
    {
        if (!EditMode) return;
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
        if(RayUtility.MouseRaycast(out RaycastHit hit))
        {
            if(hit.collider.name == "Plane")
            {
                if(selectionObj!=null)
                selectionObj.transform.position = hit.point;
            }
            else if(Input.GetMouseButton(0)&&hit.collider.tag == "Plant")
            {
                selectionObj = hit.collider.gameObject;
            }
        }
    }

    public void setEditMode(bool v)
    {
        EditMode = v;
    }
}
