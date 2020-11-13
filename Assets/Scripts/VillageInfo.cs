using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public Level_Data Level_info;
    void Start()
    {

        if (PlayerPrefs.GetInt("BattleWon" + Level_info.name,0) == 1)
        {
            Level_info._isBattleWin = true;
        }
        else
        {
            Level_info._isBattleWin = false;
        }


        Level_info.imageSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Level_info.imageSprite.enabled = Level_info._isBattleWin;

        if (Level_info._isBattleWin) {
            PlayerPrefs.SetInt("BattleWon" + Level_info.name,1);
        }
        else
        {
            PlayerPrefs.SetInt("BattleWon" + Level_info.name, 0);
        }
    }
}
