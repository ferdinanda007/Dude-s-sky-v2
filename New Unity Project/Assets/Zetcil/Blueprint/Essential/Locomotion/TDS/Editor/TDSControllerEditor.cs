using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(TDSController)), CanEditMultipleObjects]
    public class TDSControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           walkSpeed,
           curSpeed,
           maxSpeed,
           usingMouseLook,
           Zoffset
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            walkSpeed = serializedObject.FindProperty("walkSpeed");
            curSpeed = serializedObject.FindProperty("curSpeed");
            maxSpeed = serializedObject.FindProperty("maxSpeed");
            usingMouseLook = serializedObject.FindProperty("usingMouseLook");
            Zoffset = serializedObject.FindProperty("Zoffset");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(walkSpeed, true);
                EditorGUILayout.PropertyField(curSpeed, true);
                EditorGUILayout.PropertyField(maxSpeed, true);
                EditorGUILayout.PropertyField(usingMouseLook, true);
                EditorGUILayout.PropertyField(Zoffset, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}