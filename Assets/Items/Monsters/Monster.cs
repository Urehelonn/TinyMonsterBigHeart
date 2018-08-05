using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Items/Monsters/newMonster")]

public class Monster : ScriptableObject
{
    public string monsterName;
    public List<ItemDrop> dropList;
    public int monsterCode;
}

[System.Serializable]
public class ItemDrop
{
    public Item item;
    public float rate;
}
