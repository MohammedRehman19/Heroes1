using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Admanager : MonoBehaviour
{
    [Header("Ads Manager")]

    public GameObject Adpanel;
    public float adTime = 10;
    public TextMeshProUGUI CounterText;



   public IEnumerator startAd(float tempTimer)
    {
      //  print("HERE1");
        while (tempTimer > 0)
        {
    //        print("HERE2");
            yield return null;
            tempTimer -= 0.01f;
            CounterText.text = Mathf.FloorToInt(tempTimer).ToString();
        }
     //   print("HERE3");
        Adpanel.SetActive(false);
        int tempGoldValue = GameManager.Instance.Current_Database.Current_Gold;
        tempGoldValue += 5;
        PlayerPrefs.SetInt("Gold", tempGoldValue);
        GetComponent<CityManager>().ClonePopup("You Got 5 Gold");
    }

    public void SkipAd()
    {
        StopAllCoroutines();
        Adpanel.SetActive(false);

    }

    public void callAd()
    {
        Adpanel.SetActive(true);
        float tempTimer = adTime;
        CounterText.text = tempTimer.ToString();
        StartCoroutine(startAd(tempTimer));
    }
}
