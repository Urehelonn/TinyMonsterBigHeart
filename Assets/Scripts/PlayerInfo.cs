using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerInfo : MonoBehaviour {

    public PlayerInfoStorage player;

    public string monsterName;
    public int gender;
    public int belief;
    public List<Personality> personalities;
    public List<Talent> talents;

    public int strength;
    public int agility;
    public int looking;

    public Family family;

    public List<Items> backpack;
    public List<int> passedEvents;
    public List<int> missedEvents;
    
    public GameTime time;
    public List<ReleationshipRecord> rsrData;
    public Color monsterColour;

    private void Start()
    {
        monsterName = "Nano";
    }
    public void CreateNewData()
    {
        player = ScriptableObject.CreateInstance<PlayerInfoStorage>();
        
        AssetDatabase.CreateAsset(player, "Assets/Items/Savedata/"+monsterName+".asset");

        player.monsterName = monsterName;
        player.gender = gender;
        player.belief = belief;
        player.personalities = personalities;
        player.talents = talents;
        player.strength = strength;
        player.agility = agility;
        player.looking = looking;
        player.family = family;
        player.time = new GameTime();
        player.monsterColour = monsterColour;
        EditorUtility.SetDirty(player);
    }
}

[System.Serializable]
public class ReleationshipRecord
{
    public Villager npc;
    public int releationshipPoint;
    public int releationshipType;    //family0, love1, friendship2, and romance3

    public ReleationshipRecord(Villager npc, int rp, int rt)
    {
        this.npc = npc;
        releationshipPoint = rp;
        releationshipType = rt;
    }
}

[System.Serializable]
public class Items
{
    public Item item;
    public int count;

    public Items(Item i, int c)
    {
        item = i;
        count = c;
    }
}
