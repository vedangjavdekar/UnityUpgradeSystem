using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

[CustomEditor(typeof(UpgradeDatabase))]
public class UpgradeDatabaseEditor : Editor
{
    UpgradeDatabase database;
    ReorderableList list;
    SerializedProperty upgrades;
    
    private void OnEnable()
    {
        database = (UpgradeDatabase)target;
        upgrades = serializedObject.FindProperty("upgradeItems");
        list = new ReorderableList(serializedObject, upgrades, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;
        list.onRemoveCallback = OnRemove;
        list.elementHeight = 2 * EditorGUIUtility.singleLineHeight;
    }

    private void OnRemove(ReorderableList list)
    {
        serializedObject.Update();
        database.upgradeItems.RemoveAt(list.index);
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = upgrades.GetArrayElementAtIndex(index);
        element.objectReferenceValue = EditorGUI.ObjectField(new Rect(rect.x,rect.y,rect.width,EditorGUIUtility.singleLineHeight),
            element.objectReferenceValue,typeof(ScriptableObject),false);

        if(element.objectReferenceValue != null)
        {
            rect.y += EditorGUIUtility.singleLineHeight;
        }
    }

    private void DrawHeader(Rect rect)
    {
        EditorGUI.LabelField(rect, "UPGRADE ITEMS");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        if(GUILayout.Button("Export Save Data"))
        {
            database.ExportSaveData();
        }

        if (GUILayout.Button("Import From Save Data"))
        {
            database.ImportData();
        }
    }
}
