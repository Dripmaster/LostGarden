using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObj : MonoBehaviour
{

    public ObjectTransform objectTransform;
    public Color c;
    void Start()
    {
        objectTransform = new ObjectTransform();
        c = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        objectTransform.pos = transform.position;
        objectTransform.rot = transform.rotation;
        objectTransform.zone_id =1;
        objectTransform.scale = transform.localScale;
        objectTransform.color = c;

        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var r in renderers)
        {
            r.material.color = c;
        }
    }
}
