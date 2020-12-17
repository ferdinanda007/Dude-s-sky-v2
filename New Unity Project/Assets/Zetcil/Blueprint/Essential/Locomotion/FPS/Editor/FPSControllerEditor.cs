using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FPSController)), CanEditMultipleObjects]
    public class FPSControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetCamera,
           MovementType,
           walkSpeed,
           jumpSpeed,
           runSpeed,
           gravity,
           usingDpad,
           DpadController
        ;

        void OnEnable()
        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetCamera = serializedObject.FindProperty("TargetCamera");
            MovementType = serializedObject.FindProperty("MovementType");
            walkSpeed = serializedObject.FindProperty("walkSpeed");
            jumpSpeed = serializedObject.FindProperty("jumpSpeed");
            runSpeed = serializedObject.FindProperty("runSpeed");
            gravity = serializedObject.FindProperty("gravity");
            usingDpad = serializedObject.FindProperty("usingDpad");
            DpadController = serializedObject.FindProperty("DpadController");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            { 
                EditorGUILayout.PropertyField(TargetCamera, true);
                if (TargetCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(MovementType, true);
                EditorGUILayout.PropertyField(walkSpeed, true);
                EditorGUILayout.PropertyField(jumpSpeed, true);
                EditorGUILayout.PropertyField(runSpeed, true);
                EditorGUILayout.PropertyField(gravity, true);

                if ((FPSController.CMovementType) MovementType.enumValueIndex == FPSController.CMovementType.Keyboard)
                {

                } else
                {
                    EditorGUILayout.PropertyField(usingDpad, true);
                    if (usingDpad.boolValue)
                    {
                        EditorGUILayout.PropertyField(DpadController, true);
                    }
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}