using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(ActivationController)), CanEditMultipleObjects]
    public class ActivationControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           ObjectType,
           StatusType,
           InvokeType,
           TargetGameObject,

            //--Invoke type (1)
            usingDelay,
            Delay,
            usingInterval,
            Interval,
            usingActivationEvent,
            ActivationEvent
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            ObjectType = serializedObject.FindProperty("ObjectType");
            StatusType = serializedObject.FindProperty("StatusType");
            InvokeType = serializedObject.FindProperty("InvokeType");
            TargetGameObject = serializedObject.FindProperty("TargetGameObject");
            usingActivationEvent = serializedObject.FindProperty("usingActivationEvent");
            ActivationEvent = serializedObject.FindProperty("ActivationEvent");

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
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(InvokeType, true);

                EditorGUILayout.PropertyField(ObjectType, true);
                EditorGUILayout.PropertyField(StatusType, true);
                EditorGUILayout.PropertyField(TargetGameObject, true);

                EditorGUILayout.PropertyField(usingActivationEvent, true);
                if (usingActivationEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(ActivationEvent, true);
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