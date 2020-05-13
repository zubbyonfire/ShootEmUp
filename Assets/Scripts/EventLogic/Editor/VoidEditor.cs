using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    [CustomEditor(typeof(VoidEvent))]
    public class VoidEditor : Editor
    {
        [SerializeField] private Vector2 value;

        public override void OnInspectorGUI()
        {
            VoidEvent script = (VoidEvent)target;

            //Event Description
            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Event Description", EditorStyles.centeredGreyMiniLabel);
            EditorStyles.textField.wordWrap = true;
            script.EventDescription = EditorGUILayout.TextArea(script.EventDescription, GUILayout.MinHeight(100));
            GUILayout.EndVertical();

            //Test Event Button
            GUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Test Event", EditorStyles.centeredGreyMiniLabel);

            if (GUILayout.Button("Raise"))
            {
                if (Application.isPlaying)
                {
                    script.Raise();
                }
            }
            GUILayout.EndVertical();
        }
    }
}