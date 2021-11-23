using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float tmpAngle;
    float angleAdd;
    public float rotationSpeed = 1f;
    bool rotationState;

    // Start is called before the first frame update
    void Start()
    {
        tmpAngle = transform.rotation.eulerAngles.y;
        angleAdd = 0;
        rotationState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotationState) return;

        angleAdd += Time.deltaTime*rotationSpeed;
        if (angleAdd >= 360)
        {
            angleAdd = angleAdd % 360;
        }

        transform.rotation = Quaternion.AngleAxis(tmpAngle+angleAdd, Vector3.up);
    }

    public void setRotationAnim(bool v)
    {
        rotationState = v;
    }
}
