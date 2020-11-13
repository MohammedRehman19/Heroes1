using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Get CustomTime", menuName = "CreateTime", order = 51)]

public class TimeZone : ScriptableObject
{
    enum Direction { Sat, Sun, Mon, Tue, Wed, Thu, Fri };
  
    int tempValue = 0;
   
    public int DayIndex;

   
    public string NextDay()
    {
        int temp = tempValue;
        temp += 1;
        PlayerPrefs.SetInt("DayIndex", temp);
        return EnterDayCode(temp);
     
    }


    public string CurrentDay( int currentday)
    {
        if (currentday == 1)
        {
            return Direction.Sat.ToString();
        }
        else if (currentday == 2)
        {
            return Direction.Sun.ToString();
        }
        else if (currentday == 3)
        {
            return Direction.Mon.ToString();
        }
        else if (currentday == 4)
        {
            return Direction.Tue.ToString();
        }
        else if (currentday == 5)
        {
            return Direction.Wed.ToString();
        }
        else if (currentday == 6)
        {
            return Direction.Thu.ToString();
        }
        else if (currentday == 7)
        {
            return Direction.Fri.ToString();
        }
        return "";

    }

    public string EnterDayCode(int code)
    {

        if (tempValue != code)
        {
            tempValue = code;
            DayIndex += 1;
            //Debug.Log(DayIndex);
           
        }
        if (DayIndex > 7)

        {
            DayIndex = 1;

        }

        PlayerPrefs.SetInt("DayIndex", DayIndex);
        if (DayIndex == 1)
            {
                return Direction.Sat.ToString();
            }
            else if (DayIndex == 2)
            {
                return Direction.Sun.ToString();
            }
            else if (DayIndex == 3)
            {
                return Direction.Mon.ToString();
            }
            else if (DayIndex == 4)
            {
                return Direction.Tue.ToString();
            }
            else if (DayIndex == 5)
            {
                return Direction.Wed.ToString();
            }
            else if (DayIndex == 6)
            {
                return Direction.Thu.ToString();
            }
            else if (DayIndex == 7)
            {
                return Direction.Fri.ToString();
            }
            return "";
        

    }
   

}
