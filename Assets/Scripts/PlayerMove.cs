using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject selectionObj;
    public static PlayerMove instance;

    bool EditMode;



    void Awake()
    {
        instance = this;
        EditMode = false;
        //Screen.fullScreen = true;
        isDragging = false;
        isWritting = false;
    }
    bool isDragging;
    Vector3 tmpMouse;
    Vector3 tmpRot;
    public bool isWritting;
    void Update()
    {
       // if (!EditMode) return;
        Vector3 moveDir = Vector3.zero;
        float h = 0;
        if (Input.anyKey && !isWritting)
        {
            h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            float up = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                up = 1f;
           }
            moveDir = new Vector3(h, up, v);
        }
        else
        {
            
        }
        if (!isWritting)
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!RayUtility.isOnUI())
            {
                if (!isDragging)
                {
                    isDragging = true;
                    tmpMouse = Input.mousePosition;
                    tmpRot = transform.rotation.eulerAngles;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; 
            tmpRot = transform.rotation.eulerAngles;
        }
        if (isDragging)
        {
            Vector3 mDir = Input.mousePosition - tmpMouse;
            mDir *= 0.3f;
            transform.rotation = Quaternion.Euler( tmpRot +new Vector3(-mDir.y, mDir.x, 0));

        }

        transform.Translate(moveDir*1f*0.1f,Space.Self);
        //transform.Rotate(0,h,0,Space.World);
    }
    public void setMove(Vector3 pos)
    {
        transform.position = pos;
    }
    public void setEditMode(bool v)
    {
        EditMode = v;
    }
}
