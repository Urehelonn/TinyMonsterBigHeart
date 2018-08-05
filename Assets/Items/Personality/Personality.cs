using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPersonality")]
public class Personality : ScriptableObject
{
    public string personalityID;
    public string personalityName;
    public string description;
}
