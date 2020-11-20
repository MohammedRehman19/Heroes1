using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public List<GameObject> wanttoOpenList = new List<GameObject>();




    public void OpenAll()
    {

         for (int i = 0; i < wanttoOpenList.Count; i++)
        {
            wanttoOpenList[i].SetActive(true);
        }


        Destroy(this.gameObject);
    }
}
