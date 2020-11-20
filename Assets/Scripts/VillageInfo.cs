using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public Level_Data Level_info;

    private SpriteRenderer currentImage;
    public SpriteRenderer Questionmark;
    void Start()
    {
        currentImage = this.GetComponent<SpriteRenderer>();
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

       if(Vector2.Distance(this.transform.position, GameManager.Instance.Player.transform.position) > 4 && !Level_info._isBattleWin)
        {
            currentImage.enabled = false;
            Questionmark.enabled = true;
        }
        else
        {
            currentImage.enabled = true;
            Questionmark.enabled = false;
        }

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
