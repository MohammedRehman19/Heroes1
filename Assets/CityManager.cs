using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public RectTransform PrefabPop;
    public RectTransform ParentPop;


    private void Start()
    {
        InvokeRepeating("resoucresPlus", 30, 30);
        InvokeRepeating("UnitPlus", 35, 35);

    }

    public void ClonePopup(string popUpText)
    {
        Debug.Log("Clone");
        RectTransform cloneText = Instantiate(PrefabPop, ParentPop.position, Quaternion.identity);
        cloneText.GetComponent<TextMeshProUGUI>().text = popUpText;
        cloneText.SetParent(ParentPop);

    }
    public void resoucresPlus()
    {

        if (GameManager.Instance.Current_Database._ResourcesCollectingAvaliable != 1)
            return;
        resoucresCall();
       
    }


    public void resoucresCall()
    {
        int tempValue = GameManager.Instance.Current_Database.Current_Resources;
        int randValue = Random.Range(10, 101);
        tempValue += randValue;
        PlayerPrefs.SetInt("Resources", tempValue);
        ClonePopup("You Got " + randValue + " Resources");
    }

    public void UnitPlus()
    {
        if (GameManager.Instance.Current_Database._UnitCollectingAvaliable != 1)
            return;


        int tempValue = GameManager.Instance.Current_Database.Current_Unit;
        int randValue = Random.Range(0, 3);
        tempValue += randValue;
        PlayerPrefs.SetInt("Unit", tempValue);
        ClonePopup("You Got " + randValue + " Unit");
    }

    public void GetGoldsWithAds()
    {
        GetComponent<Admanager>().callAd();
    }


    public void Getweapon()
    {
        int tempWeaponValue = GameManager.Instance.Current_Database.Current_Weapon;
        tempWeaponValue += 5;
        PlayerPrefs.SetInt("Weapon", tempWeaponValue);
        ClonePopup("You Got 5 Weapon");
    }
    public void GetWood()
    {
        int tempWeaponValue = GameManager.Instance.Current_Database.Current_Weapon;
        tempWeaponValue += 5;
        PlayerPrefs.SetInt("Wood", tempWeaponValue);
        ClonePopup("You Got 5 Wood");
    }
    public void GetCoal()
    {
        int tempCoalValue = GameManager.Instance.Current_Database.Current_Coal;
        tempCoalValue += 3;
        PlayerPrefs.SetInt("Coal", tempCoalValue);
        ClonePopup("You Got 3 Coal");
    }
    public void GetFood()
    {
        int tempFoodValue = GameManager.Instance.Current_Database.Current_Food;
        tempFoodValue += 4;
        PlayerPrefs.SetInt("Food", tempFoodValue);
        ClonePopup("You Got 4 Food");
    }
    public void GoldPlus()
    {
        if (GameManager.Instance.Current_Database.Current_Resources < 10)
        {
            ClonePopup("ooooh! You Dont have Resource please Comeback when you have 10 Resources bye for now.");
        }
        else
        {

            int tempValue = GameManager.Instance.Current_Database.Current_Resources;
            tempValue -= 10;
            PlayerPrefs.SetInt("Resources", tempValue);
            int tempGoldValue = GameManager.Instance.Current_Database.Current_Gold;
            tempGoldValue += 5;
            PlayerPrefs.SetInt("Gold", tempGoldValue);
            ClonePopup("You Got 5 Gold");
        }
    }

    public void HireGatheronGold()
    {
        if (GameManager.Instance.Current_Database.Current_Gold < 100)
        {
            ClonePopup("ooooh! You Dont have 100 Gold please Comeback when you have 100 Golds bye for now.");
        }
        else
        {

            //int tempValue = GameManager.Instance.Current_Database.Current_Resources;
            //tempValue += 300;
            //PlayerPrefs.SetInt("Resources", tempValue);
            int tempGoldValue = GameManager.Instance.Current_Database.Current_Gold;
            tempGoldValue -= 100;
            PlayerPrefs.SetInt("Gold", tempGoldValue);
            PlayerPrefs.SetInt("ResourcesCollecting", 1);
            ClonePopup("Wow! Now you can have full box Resources on every 5th day from local gatherer Random.");
        }
    }
    public void GetUnit()
    {
        if (GameManager.Instance.Current_Database.Current_Gold < 10)
        {
            ClonePopup("ooooh! You Dont have 10 Gold please Comeback when you have 100 Golds bye for now.");

        }
        else
        {

            //int tempValue = GameManager.Instance.Current_Database.Current_Resources;
            //tempValue += 300;
            //PlayerPrefs.SetInt("Resources", tempValue);
            int tempGoldValue = GameManager.Instance.Current_Database.Current_Gold;
            tempGoldValue -= 10;
            PlayerPrefs.SetInt("Gold", tempGoldValue);
            PlayerPrefs.SetInt("UnitCollecting", 1);
            ClonePopup("Wow! Now you can Units on every 5th day from local gatherer Random.");
        }
    }
}
