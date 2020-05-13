using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    public class FloatListener : BaseGameEventListener<float, FloatEvent, UnityFloatEvent> { }
#if UNITY_EDITOR
    [CustomEditor(typeof(FloatListener))]
    public class FloatListenerEditor : Editor
    {
        private bool showDescription;

        public override void OnInspectorGUI()
        {
            FloatListener script = (FloatListener)target;

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

