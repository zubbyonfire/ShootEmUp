using UnityEngine;
using UnityEditor;

namespace R42.GameEvents
{
    public class IntListener : BaseGameEventListener<int, IntEvent, UnityIntEvent> { }
#if UNITY_EDITOR
    [CustomEditor(typeof(IntListener))]
    public class IntListenerEditor : Editor
    {
        private bool showDescription;

        public override void OnInspectorGUI()
        {
            IntListener script = (IntListener)target;

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
