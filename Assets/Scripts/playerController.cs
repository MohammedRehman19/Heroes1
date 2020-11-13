using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
       //  GameManager.Instance.Current_Database.
        if (GameManager.Instance.Current_Database.currentPos != transform.localPosition)
        {
            GameManager.Instance.Current_Database.currentPos = transform.localPosition;
        }
    }
}
