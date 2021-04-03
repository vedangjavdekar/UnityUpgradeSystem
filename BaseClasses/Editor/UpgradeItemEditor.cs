using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public abstract class UpgradeItemEditor : Editor
{
    protected ReorderableList list;
    protected  SerializedProperty upgradeLevels;

    protected virtual void OnEnable()
    {
        upgradeLevels = serializedObject.FindProperty("upgradeLevels");
        list = new ReorderableList(serializedObject, upgradeLevels, true, true, true, true);

        list.drawElementCallback = DrawListItems; // Delegate to draw the elements on the list
        list.drawHeaderCallback = DrawHeader;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PrefixLabel("Name");
        serializedObject.FindProperty("upgradeName").stringValue = EditorGUILayout.TextField(serializedObject.FindProperty("upgradeName").stringValue);
        EditorGUILayout.Space(10);

        EditorGUILayout.PrefixLabel("CurrentLevel");
        serializedObject.FindProperty("currentLevel").intValue = EditorGUILayout.IntSlider(serializedObject.FindProperty("currentLevel").intValue, 0, Mathf.Max(serializedObject.FindProperty("upgradeLevels").arraySize-1,0));
        EditorGUILayout.Space(10);

        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    protected abstract void DrawListItems(Rect rect, int index, bool isActive, bool isFocused);
    protected abstract void DrawHeader(Rect rect);

}
