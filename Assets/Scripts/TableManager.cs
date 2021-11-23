using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    public All_Table all_Table;
    public MyTable myTable;

    public GameObject ContentPrefab;

    public ObjectItemInfo[] objects;

    public Image infoImage;
    public Text infoString;
    public Text infoName;

    public GameObject tableParent;
    public GameObject inventoryParent;
    public GameObject prevObject;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in objects)
        {
            GameObject g = Instantiate(ContentPrefab, all_Table.transform);
            g.GetComponent<Content>().Init(item,"All");
        }
        infoImage.sprite = null;
        infoImage.enabled = false;
        infoString.text = "";
        infoName.text = "";
        isDragging = false;
    }
    bool isDragging;
    GameObject draggingItem;
    ObjectItemInfo DraggingInfo;
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            draggingItem.transform.localPosition = Input.mousePosition - new Vector3(Screen.width/2,Screen.height/2,0);
            if (Input.GetMouseButtonUp(0))
            {
                dragStart = false;
                if (isOn3DUI_2(out RaycastResult result))
                {
                    GameObject g = Instantiate(ContentPrefab, myTable.transform);
                    g.GetComponent<Content>().Init(DraggingInfo, "My");
                    myTable.objects.Add(DraggingInfo);
                }


                isDragging = false;
                DraggingInfo = null;
                Destroy(draggingItem);
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                dragStart = false;
                if (isOn3DUI_2(out RaycastResult result))
                {
                    if (result.gameObject.name == "My")
                    {
                        infoImage.sprite = result.gameObject.GetComponent<Content>().info.infoImage;
                        infoImage.enabled = true;
                        infoString.text = result.gameObject.GetComponent<Content>().info.infoString;
                        infoName.text = result.gameObject.GetComponent<Content>().info.ObjectName;

                    }
                    
                }
                else if (isOn3DUI(out RaycastResult result2))
                {
                    if (result2.gameObject.name == "All")
                    {
                        infoImage.sprite = result2.gameObject.GetComponent<Content>().info.infoImage;
                        infoImage.enabled = true;
                        infoString.text = result2.gameObject.GetComponent<Content>().info.infoString;
                        infoName.text = result2.gameObject.GetComponent<Content>().info.ObjectName;
                    }
                }
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (isOn3DUI(out RaycastResult result))
            {
                if(result.gameObject.name == "All")
                {
                    r = result;
                    dragStart = true;
                    Invoke("doDrag", 0.1f);
                }
                if(result.gameObject.tag == "AllTable")
                {

                }
            }
        }
    }
    RaycastResult r;
    bool dragStart;
    public void doDrag()
    {
        if (!dragStart) return;

        isDragging = true;
        draggingItem = Instantiate(r.gameObject.GetComponent<Content>().info._3DObject, GameObject.Find("3Dcanvas").transform);
        DraggingInfo = r.gameObject.GetComponent<Content>().info;
        draggingItem.layer = 5;
        var c = draggingItem.transform.childCount;
        for (int i = 0; i < c; i++)
        {
            draggingItem.transform.GetChild(i).gameObject.layer = 5;
        }
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
    public static bool isOn3DUI_2(out RaycastResult result)
    {//터치 포인트가 UI위에 있는지 확인해준다.
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData ped = new PointerEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>());
        ped.position = Input.mousePosition;
        GameObject.Find("3Dcanvas_2").GetComponent<GraphicRaycaster>().Raycast(ped, results);
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
        tableParent.SetActive(false);
        inventoryParent.SetActive(true);
    }
    public void PrevBtn()
    {
        PlaceUIManager.instatnce.OnNameBtn();
        prevObject.SetActive(true);
        tableParent.SetActive(false);
    }
}
