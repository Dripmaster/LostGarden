using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneSelectButton : MonoBehaviour
{
    public GameObject NextBTN;
    public int zoneId;
    public InputField inField;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!inField.placeholder.GetComponent<Text>().enabled)
        {
            PlayerMove.instance.isWritting = true;
        }
    }
    public void Selected()
    {
        gameObject.GetComponentInChildren<Text>().gameObject.SetActive(false);
        NextBTN.SetActive(true);
        PlayerMove.instance.setMove(transform.position);
    }
    public void SetName()
    {
        PlayerMove.instance.isWritting = false;
        PlaceUIManager.instatnce.SetName(transform.parent.GetComponentInChildren<InputField>().text);
    }
}
