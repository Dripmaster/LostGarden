using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasrenderMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CanvasRenderer>().SetMesh(GetComponent<MeshFilter>().mesh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
