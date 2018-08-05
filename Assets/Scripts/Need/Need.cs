using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Items/Need/newNeed")]
public class Need : ScriptableObject
{
    public float timer;
    public Hunger hunger;
    public Cleanliness cleanliness;
    public Social social;
    public Health health;
    public Tiredness tiredness;
    public Happiness happiness;
    public Faith faith;
}

