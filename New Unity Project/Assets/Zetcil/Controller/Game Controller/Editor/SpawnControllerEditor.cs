using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SpawnController)), CanEditMultipleObjects]
    public class SpawnControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            InvokeType,
            TargetPrefab,
            TargetPosition,
            usingParent,
            TargetParent,
            AfterSpawn,
            usingDelay,
            Delay,
            usingInterval,
            Interval
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            InvokeType = serializedObject.FindProperty("InvokeType");
            TargetPrefab = serializedObject.FindProperty("TargetPrefab");
            TargetPosition = serializedObject.FindProperty("TargetPosition");
            usingParent = serializedObject.FindProperty("usingParent");
            TargetParent = serializedObject.FindProperty("TargetParent");
            usingDelay = serializedObject.FindProperty("usingDelay");
            AfterSpawn = serializedObject.FindProperty("AfterSpawn");
            Delay = serializedObject.FindProperty("Delay");
            usingInterval = serializedObject.FindProperty("usingInterval");
            Interval = serializedObject.FindProperty("Interval");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {

                EditorGUILayout.PropertyField(InvokeType);

                EditorGUILayout.PropertyField(TargetPrefab);
                if (TargetPrefab.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(TargetPosition);
                if (TargetPosition.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(usingParent);
                if (usingParent.boolValue)
                {
                    EditorGUILayout.PropertyField(AfterSpawn);
                    EditorGUILayout.PropertyField(TargetParent);
                    if (TargetParent.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                //--Invoke type (3)
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnDelay)
                { 
                    EditorGUILayout.PropertyField(usingDelay, true);
                    if (usingDelay.boolValue)
                    {
                        EditorGUILayout.PropertyField(Delay, true);
                    }
                }
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnInterval)
                {
                    EditorGUILayout.PropertyField(usingInterval, true);
                    if (usingInterval.boolValue)
                    {
                        EditorGUILayout.PropertyField(Interval, true);
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