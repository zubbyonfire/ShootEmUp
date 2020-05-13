using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    public class Vector3Listener : BaseGameEventListener<Vector3, Vector3Event, UnityVector3Event> { }
#if UNITY_EDITOR
    [CustomEditor(typeof(Vector3Listener))]
    public class Vector3ListenerEditor : Editor
    {
        private bool showDescription;

        public override void OnInspectorGUI()
        {
            Vector3Listener script = (Vector3Listener)target;

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
