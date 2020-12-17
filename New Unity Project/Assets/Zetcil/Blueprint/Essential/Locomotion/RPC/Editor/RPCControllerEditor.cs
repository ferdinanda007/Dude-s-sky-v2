using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(RPCController)), CanEditMultipleObjects]
    public class RPCControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           carRigidbody,
           frontwheel,
           backwheel,
           speedF,
           speedB,
           torqueF,
           torqueB,
           TractionFront,
           TractionBack,
           carRotationSpeed
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            carRigidbody = serializedObject.FindProperty("carRigidbody");
            frontwheel = serializedObject.FindProperty("frontwheel");
            backwheel = serializedObject.FindProperty("backwheel");
            speedF = serializedObject.FindProperty("speedF");
            speedB = serializedObject.FindProperty("speedB");
            torqueF = serializedObject.FindProperty("torqueF");
            torqueB = serializedObject.FindProperty("torqueB");
            TractionFront = serializedObject.FindProperty("TractionFront");
            TractionBack = serializedObject.FindProperty("TractionBack");
            carRotationSpeed = serializedObject.FindProperty("carRotationSpeed");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(carRigidbody, true);
                if (carRigidbody.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(frontwheel, true);
                if (frontwheel.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(backwheel, true);
                if (backwheel.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(speedF, true);
                EditorGUILayout.PropertyField(speedB, true);
                EditorGUILayout.PropertyField(torqueF, true);
                EditorGUILayout.PropertyField(torqueB, true);
                EditorGUILayout.PropertyField(TractionFront, true);
                EditorGUILayout.PropertyField(TractionBack, true);
                EditorGUILayout.PropertyField(carRotationSpeed, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}