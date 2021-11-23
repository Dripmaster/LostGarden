using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayUI : MonoBehaviour
{
    public GameObject[] NextUI;
    public int functionIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            if (NextUI.Length!=0) {
                foreach (var item in NextUI)
                {

                    item.SetActive(true);
                }
            }
            if (functionIndex == 1)
            {
                GameObject.Find("Player").GetComponent<PlayerMove>().setEditMode(true);
            }
        }
    }
}
