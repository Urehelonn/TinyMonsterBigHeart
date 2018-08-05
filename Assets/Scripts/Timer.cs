using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameTime curr;   //tracking current time
    public bool on;     //tracking if the timer need to work;
    public GameObject timerLabel;
    
    public float deltaTimer;
    PlayerInfo playerinfo;

    private void Start()
    {
        playerinfo = GameObject.FindGameObjectWithTag("PlayerInfoStorage").GetComponent<PlayerInfo>();
    }

    void Update () {

        //if timer working, time continue to run.
        if (on)
        {            
            deltaTimer += Time.deltaTime;
            curr.hour = (int)(deltaTimer/30f);       //30 second per hour

            if (curr.hour >= 20)        //20 hours per day
            {
                curr.day += 1;
                curr.hour -= 20;
                deltaTimer -= 600;

                if (curr.day >= 30)         //30 days per month
                {
                    curr.month += 1;
                    curr.day -= 30;

                    if(curr.month >= 4)     //4 months per year
                    {
                        curr.year += 1;
                        curr.month -= 4;
                    }
                }

            }

            //update timer label on ui
            //in the form of 0 Hour, 0 Day, 0 Month, 0 Year
            timerLabel.GetComponent<Text>().text = curr.hour + " Hour, " + curr.day +
                " Day, " + curr.month + " Month, "+curr.year+" Year ";

        //Synchronize curr time with the timer set in player info
        playerinfo.time = curr;
    }		
}
}

[System.Serializable]
public class GameTime
{
public int year;
public int month;
public int day;
public int hour;

public GameTime(int y, int m, int d, int h)
{
    year = y;
    month = m;
    day = d;
    hour = h;
}

public GameTime()
{
    year = 0;
    month = 0;
    day = 0;
    hour = 0;
}
}
