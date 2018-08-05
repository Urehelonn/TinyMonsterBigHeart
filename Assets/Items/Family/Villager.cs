using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Items/Family/newVillager")]
public class Villager : ScriptableObject
{
    public string nCode;
    public string nName;
    public int gender;
    public int genderOrientation;
    public int looking;
    public List<Personality> nPersonalities;
    public List<Talent> nTalents;
    public bool ifRomance;    
}
