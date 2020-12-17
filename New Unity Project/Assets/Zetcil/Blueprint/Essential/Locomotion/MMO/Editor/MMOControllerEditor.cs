using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(MMOController)), CanEditMultipleObjects]
    public class MMOControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           MoveDirection,
           joystickMove,
           speed
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            MoveDirection = serializedObject.FindProperty("MoveDirection");
            joystickMove = serializedObject.FindProperty("joystickMove");
            speed = serializedObject.FindProperty("speed");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(MoveDirection, true);
                EditorGUILayout.PropertyField(joystickMove, true);
                if (joystickMove.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(speed, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}