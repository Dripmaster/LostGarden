using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class placeObjTable : MonoBehaviour
{
    public MyTable mytable;
    public GameObject table;
    public GameObject ContentPrefab;
    public ScrollRect sr;

    public GameObject NextObject;
    public GameObject PrevObject;

    GameObject selectionObj;
    GameObject s3DObj;

    private void OnEnable()
    {
        var count = table.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(table.transform.GetChild(i));
        }

        foreach (var item in mytable.objects)
        {
            GameObject g = Instantiate(ContentPrefab, table.transform);
            g.GetComponent<Content>().Init(item, "My");
        }
        selectionObj = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool isDragging;
    ObjectItemInfo DraggingInfo;
    bool dragStart;
    RaycastResult r;
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            bool f = false;
            if (RayUtility.MouseRaycast(out RaycastHit result,7))
            {
                if (result.collider.tag == "plane" )
                {
                    if (selectionObj != null)
                    {
                        s3DObj.transform.position = result.point;
                        s3DObj.SetActive(true);
                        selectionObj.SetActive(false);
                        f = true;
                    }
                }
            }
            if (!f)
            {
                selectionObj.transform.localPosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
                s3DObj.SetActive(false);
                selectionObj.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                sr.vertical = true;
                dragStart = false;
                isDragging = false;
                DraggingInfo = null;
                Destroy(selectionObj);

                controlPanel.instance.Init(s3DObj.GetComponent<PlacedObj>());
                GameObject.FindObjectOfType<PlayerMove>().setMove(s3DObj.transform.position);
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                sr.vertical = true;
                dragStart = false;
                if (isOn3DUI(out RaycastResult result2))
                {
                    if (result2.gameObject.name == "My")
                    {
                       
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isOn3DUI(out RaycastResult result))
            {
                if (result.gameObject.name == "My")
                {
                    r = result;
                    dragStart = true;
                    Invoke("doDrag", 0.05f);
                }
                if (result.gameObject.tag == "AllTable")
                {

                }
            }
        }
    }
    public GameObject defaultParent;
    public void doDrag()
    {
        if (!dragStart) return;

        isDragging = true;
        GameObject g = Instantiate(defaultParent);
        selectionObj = Instantiate(r.gameObject.GetComponent<Content>().info._3DObject, GameObject.Find("DraggedCanvas").transform);
        selectionObj.transform.localPosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        s3DObj = Instantiate(r.gameObject.GetComponent<Content>().info._3DObject,g.transform);
        
        s3DObj.transform.localScale /= 100;
        s3DObj = g;
        s3DObj.SetActive(false);
        DraggingInfo = r.gameObject.GetComponent<Content>().info;
        selectionObj.layer = 5;
        var c = selectionObj.transform.childCount;
        for (int i = 0; i < c; i++)
        {
            selectionObj.transform.GetChild(i).gameObject.layer = 5;
        }
        sr.vertical = false;
    }
    public static bool isOn3DUI(out RaycastResult result)
    {//터치 포인트가 UI위에 있는지 확인해준다.
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData ped = new PointerEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>());
        ped.position = Input.mousePosition;
        GameObject.Find("3Dcanvas").GetComponent<GraphicRaycaster>().Raycast(ped, results);
        if (results.Count > 0)
        {
            result = results[0];
            return true;
        }
        result = new RaycastResult();
        return false;
    }

    public void NextBtn()
    {
        gameObject.SetActive(false);
        NextObject.SetActive(true);
    }
    public void PrevBtn()
    {

        gameObject.SetActive(false);
        PrevObject.SetActive(true);
    }
}
