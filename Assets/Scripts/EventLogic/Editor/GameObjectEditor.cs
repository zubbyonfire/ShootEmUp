using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    [CustomEditor(typeof(GameObjectEvent))]
    public class GameObjectEditor : Editor
    {
        [SerializeField] private GameObject value;

        public override void OnInspectorGUI()
        {
            GameObjectEvent script = (GameObjectEvent)target;

            //Event Description
            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Event Description", EditorStyles.centeredGreyMiniLabel);
            EditorStyles.textField.wordWrap = true;
            script.EventDescription = EditorGUILayout.TextArea(script.EventDescription, GUILayout.MinHeight(100));
            GUILayout.EndVertical();

            //Test Event Button
            GUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Test Event", EditorStyles.centeredGreyMiniLabel);
            value = (GameObject)EditorGUILayout.ObjectField("Value", value, typeof(GameObject), true);

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

