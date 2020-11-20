using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Create_Database", menuName = "Database", order = 51)]

public class Database : ScriptableObject
{


    public int Current_Level = 0;
    public int Current_Endurance = 0;
    public int Current_ProgressBar_Level = 0;
  
    public int Current_Resources
    {
        get { return PlayerPrefs.GetInt("Resources",0); }
      //  set { _resources = value; }
    }
    public int Current_Gold
    {
        get { return PlayerPrefs.GetInt("Gold", 0); }
        //  set { _resources = value; }
    }
    public int Current_Weapon
    {
        get { return PlayerPrefs.GetInt("Weapon", 0); }
        //  set { _resources = value; }
    }
    public int Current_Coal
    {
        get { return PlayerPrefs.GetInt("Coal", 0); }
        //  set { _resources = value; }
    }
    public int Current_Food
    {
        get { return PlayerPrefs.GetInt("Food", 0); }
        //  set { _resources = value; }
    }
    public int Current_Wood
    {
        get { return PlayerPrefs.GetInt("Wood", 0); }
        //  set { _resources = value; }
    }
    public int Current_Unit
    {
        get { return PlayerPrefs.GetInt("Unit", 0); }
        //  set { _resources = value; }
    }
    public int _ResourcesCollectingAvaliable
    {
        get { return PlayerPrefs.GetInt("ResourcesCollecting", 0); }
        //  set { _resources = value; }
    }
    public int _UnitCollectingAvaliable
    {
        get { return PlayerPrefs.GetInt("UnitCollecting", 0); }
        //  set { _resources = value; }
    }


    public Vector3 currentPos;

   
   
}

