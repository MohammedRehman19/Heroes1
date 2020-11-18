using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Create_Level", menuName = "Level", order = 51)]

public class Level_Data : ScriptableObject
{


    public bool _isBattleWin = false;
    [HideInInspector]
    public SpriteRenderer imageSprite;
    public List<bool> activeShops = new List<bool>();
}
