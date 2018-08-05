using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Items/Playerdata/Player")]
public class PlayerInfoStorage : ScriptableObject
{
    public string monsterName = "Nano";
    public int gender = 0;  //0 as male, 1 as female, 2 as neutral
    public int belief = 0;  //0 as sun, 1 as moon, 2 as star
    public List<Personality> personalities;
    public List<Talent> talents;

    public int strength;
    public int agility;
    public int looking;

    public Family family;

    //need to add mark later
    //public List<Mark> marks;
    public List<Items> backpack;
    public List<int> passedEvents;
    public List<int> missedEvents;

    public GameTime time;

    public string fishing;
    public string hunting;

    //relationship record
    public List<ReleationshipRecord> rsrData;

    //monster's colour
    public Color monsterColour;
}

