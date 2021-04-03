using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeItem : ScriptableObject, IUpgradeItemMethods
{
    public string upgradeName;
    public int currentLevel;

    public virtual bool canUpgrade { get; }
    public virtual bool reachedMaxLevel { get; }

    public virtual void Upgrade()
    {
        if (canUpgrade)
        {
            currentLevel++;
        }
    }

    private void OnValidate()
    {
        currentLevel = Mathf.Max(currentLevel, 0);
    }
}