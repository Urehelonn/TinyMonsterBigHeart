using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Items/Items/newItem")]

public class Item : ScriptableObject
{
    public string itemName;
    public int itemCode;
    public string itemDescription;
    public string itemType; //food, bug, ore, plant, fur, mark, meat
    public bool eatable;
}
