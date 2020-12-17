using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SSPController)), CanEditMultipleObjects]
    public class SSPControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           movementSpeed,
           jumpSpeed,
           isGrounded
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            movementSpeed = serializedObject.FindProperty("movementSpeed");
            jumpSpeed = serializedObject.FindProperty("jumpSpeed");
            isGrounded = serializedObject.FindProperty("isGrounded");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(movementSpeed, true);
                EditorGUILayout.PropertyField(jumpSpeed, true);
                EditorGUILayout.PropertyField(isGrounded, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}