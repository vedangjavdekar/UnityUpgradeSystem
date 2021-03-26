using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeItem : ScriptableObject
{
    public string upgradeName;
    public int currentLevel;
}