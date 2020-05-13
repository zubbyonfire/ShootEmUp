using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    [CustomEditor(typeof(Vector2Event))]
    public class Vector2Editor : Editor
    {
        [SerializeField] private Vector2 value;

        public override void OnInspectorGUI()
        {
            Vector2Event script = (Vector2Event)target;

            //Event Description
            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Event Description", EditorStyles.centeredGreyMiniLabel);
            EditorStyles.textField.wordWrap = true;
            script.EventDescription = EditorGUILayout.TextArea(script.EventDescription, GUILayout.MinHeight(100));
            GUILayout.EndVertical();

            //Test Event Button
            GUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Test Event", EditorStyles.centeredGreyMiniLabel);
            value = EditorGUILayout.Vector2Field("Value ", value);

            if (GUILayout.Button("Raise"))
            {
                if (Application.isPlaying)
                {
                    script.Raise(value);
                }
            }
            GUILayout.EndVertical();
        }
    }
}