using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityController : MonoBehaviour
{

    public TextMeshProUGUI SelectedText;

    public GameObject listofShopPt;
    public GameObject listofResourcePt;

    private List<GameObject> ListAllshop = new List<GameObject>();
    private List<GameObject> ListAllResource = new List<GameObject>();
   

    void OnEnable()
    {
        for(int i = 0; i < listofShopPt.transform.childCount; i++)
        {
            ListAllshop.Add(listofShopPt.transform.GetChild(i).gameObject);
            
        }
        for (int i = 0; i < listofResourcePt.transform.childCount; i++)
        {
            ListAllResource.Add(listofResourcePt.transform.GetChild(i).gameObject);
            ListAllResource[i].SetActive(false);
        }

        ClickedButton(0);
    }




    public void ClickedButton(int index)
    {
        clearClickHere();

        ListAllshop[index].GetComponent<Image>().color = new Color(0.65f,1,0,1);
        SelectedText.text =  "SELECTED SHOP : " + ListAllshop[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        ListAllResource[index].gameObject.SetActive(true);
    }

    public void clearClickHere()
    {
        for(int i = 0; i < ListAllshop.Count; i++)
        {
            ListAllshop[i].GetComponent<Image>().color = new Color (1,1,1,1) ;
        }
        for (int i = 0; i < ListAllResource.Count; i++)
        {
            ListAllResource[i].gameObject.SetActive(false);
        }
    }

}
