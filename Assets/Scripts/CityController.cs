using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityController : MonoBehaviour
{

    public TextMeshProUGUI SelectedText;

    //public GameObject listofShopPt;
    //public GameObject listofResourcePt;

    public List<GameObject> ListAllshop = new List<GameObject>();
    public List<GameObject> ListAllResource = new List<GameObject>();

    private bool _firstLevel = false;

    public RectTransform PrefabPop;
    public RectTransform ParentPop;

    private void OnEnable()
    {
      //  ClickedButton(0);
    }


    public void ClonePopup(string popUpText)
    {
        Debug.Log("Clone");
        RectTransform cloneText = Instantiate(PrefabPop,ParentPop.position,Quaternion.identity);
        cloneText.GetComponent<TextMeshProUGUI>().text = popUpText;
        cloneText.SetParent(ParentPop);

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


    public void activeShopFtn(List<bool> LevelactiveShop)
    {
     //   clearClickHere();

        for(int i = 0; i < ListAllshop.Count; i++)
        {
            ListAllshop[i].gameObject.SetActive(false);
            
            if (LevelactiveShop[i])
            {
                if (!_firstLevel)
                {
                    ClickedButton(i);
                    _firstLevel = true;
                }
                ListAllshop[i].gameObject.SetActive(true);
            }
        }
    }

}
