using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UpgradeDatabase", menuName = "Databases/Upgrades/UpgradeDatabase")]
public class UpgradeDatabase : ScriptableObject
{
    public List<UpgradeItem> upgradeItems = new List<UpgradeItem>();


    public void ExportSaveData(bool resetLevels =false)
    {
        // Your code to export this data to your data persistence manager
    }

    public void ImportData()
    {
        // Your code to import data from your data persistence manager
    }
}
