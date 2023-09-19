using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "TD/Scriptable/Tower",order = 1)]
public class Tower : ScriptableObject
{
    public int Cost;
    public int Damage;
    public int Name;
}
