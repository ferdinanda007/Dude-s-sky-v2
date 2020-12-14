using UnityEditor;
using UnityEngine;

namespace Zetcil 
{
    [CustomEditor(typeof(DestroyController)), CanEditMultipleObjects]
    public class DestroyControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            InvokeType,
            usingTargetGameObject, 
            TargetGameObject,
            usingTargetGameObjectName,
            TargetGameObjectName,

            //--Invoke type (1)
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

            usingTargetGameObject = serializedObject.FindProperty("usingTargetGameObject");
            TargetGameObject = serializedObject.FindProperty("TargetGameObject");
            usingTargetGameObjectName = serializedObject.FindProperty("usingTargetGameObjectName");
            TargetGameObjectName = serializedObject.FindProperty("TargetGameObjectName");

            //--Invoke type (2)
            usingDelay = serializedObject.FindProperty("usingDelay");
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
                EditorGUILayout.PropertyField(InvokeType, true);

                EditorGUILayout.PropertyField(usingTargetGameObject, true);
                if (usingTargetGameObject.boolValue) 
                { 
                    EditorGUILayout.PropertyField(TargetGameObject, true);
                }

                EditorGUILayout.PropertyField(usingTargetGameObjectName, true);
                if (usingTargetGameObjectName.boolValue)
                {
                    EditorGUILayout.PropertyField(TargetGameObjectName, true);
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