using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    public class Vector2Listener : BaseGameEventListener<Vector2, Vector2Event, UnityVector2Event> { }
#if UNITY_EDITOR
    [CustomEditor(typeof(Vector2Listener))]
    public class Vector2ListenerEditor : Editor
    {
        private bool showDescription;

        public override void OnInspectorGUI()
        {
            Vector2Listener script = (Vector2Listener)target;

            if (script.GameEvent != null)
            {
                //Event Description
                GUILayout.BeginVertical();

                showDescription = EditorGUILayout.Toggle("Show Description", showDescription);

                if (showDescription)
                {
                    EditorGUILayout.LabelField("Event Description", EditorStyles.centeredGreyMiniLabel);
                    EditorStyles.textField.wordWrap = true;
                    EditorGUILayout.TextField(script.GameEvent.EventDescription, GUILayout.MinHeight(60));
                }
                GUILayout.EndVertical();
            }

            base.OnInspectorGUI();
        }
    }
#endif
}
