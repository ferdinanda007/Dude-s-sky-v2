using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(ADVController)), CanEditMultipleObjects]
    public class ADVControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           speed,
           jumpSpeed,
           gravity,
           smoothSpeed,
           smoothDirection,
           canJump
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            speed = serializedObject.FindProperty("speed");
            jumpSpeed = serializedObject.FindProperty("jumpSpeed");
            gravity = serializedObject.FindProperty("gravity");
            smoothSpeed = serializedObject.FindProperty("smoothSpeed");
            smoothDirection = serializedObject.FindProperty("smoothDirection");
            canJump = serializedObject.FindProperty("canJump");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(speed, true);
                EditorGUILayout.PropertyField(jumpSpeed, true);
                EditorGUILayout.PropertyField(gravity, true);
                EditorGUILayout.PropertyField(smoothSpeed, true);
                EditorGUILayout.PropertyField(smoothDirection, true);
                EditorGUILayout.PropertyField(canJump, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}