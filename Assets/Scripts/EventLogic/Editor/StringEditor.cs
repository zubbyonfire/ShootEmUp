using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    [CustomEditor(typeof(StringEvent))]
    public class StringEditor : Editor
    {
        [SerializeField] private string value;

        public override void OnInspectorGUI()
        {
            StringEvent script = (StringEvent)target;

            //Event Description
            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Event Description", EditorStyles.centeredGreyMiniLabel);
            EditorStyles.textField.wordWrap = true;
            script.EventDescription = EditorGUILayout.TextArea(script.EventDescription, GUILayout.MinHeight(100));
            GUILayout.EndVertical();

            //Test Event Button
            GUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Test Event", EditorStyles.centeredGreyMiniLabel);
            value = EditorGUILayout.TextField("Value ", value);

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