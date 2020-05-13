using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
using UnityEditorInternal;
[CustomEditor(typeof(SO_ObjectPoolList))]
public class SO_ObjectPoolListEditor : Editor
{
    private ReorderableList list;

    private void OnEnable()
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("objectPoolList"), true, true, true, true);


        list.drawHeaderCallback = (Rect rect) => 
        {
            EditorGUI.LabelField(rect, "Object Pool List - Object/Tag/Amount/Expand");
        };
         
        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width / 4, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("poolObject"), GUIContent.none);

            EditorGUI.PropertyField(new Rect(rect.x + (rect.width / 4), rect.y, rect.width / 4, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("poolTag"), GUIContent.none);

            EditorGUI.PropertyField(new Rect(rect.x + ((rect.width / 4) * 2), rect.y, rect.width / 4, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("poolAmount"), GUIContent.none);

            EditorGUI.PropertyField(new Rect(rect.x + ((rect.width / 4) * 3), rect.y, rect.width / 4, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("poolExpand"), GUIContent.none);
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
