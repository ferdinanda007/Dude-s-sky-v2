using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(LerpController)), CanEditMultipleObjects]
    public class LerpControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,

           InvokeType,

           usingBooleanCondition,
           BooleanCondition,

           TransformType,
           TargetObject,
           StartTransform,
           EndTransform,
           Offset,
           Speed,
           usingCoolDown,
           CoolDown,
            //--Invoke type (1)
            usingDelay,
            Delay,
            usingInterval,
            Interval
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            InvokeType = serializedObject.FindProperty("InvokeType");

            usingBooleanCondition = serializedObject.FindProperty("usingBooleanCondition");
            BooleanCondition = serializedObject.FindProperty("BooleanCondition");

            TransformType = serializedObject.FindProperty("TransformType");
            TargetObject = serializedObject.FindProperty("TargetObject");
            StartTransform = serializedObject.FindProperty("StartTransform");
            EndTransform = serializedObject.FindProperty("EndTransform");
            Offset = serializedObject.FindProperty("Offset");
            Speed = serializedObject.FindProperty("Speed");
            usingCoolDown = serializedObject.FindProperty("usingCoolDown");
            CoolDown = serializedObject.FindProperty("CoolDown");

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

                EditorGUILayout.PropertyField(usingBooleanCondition, true);
                if (usingBooleanCondition.boolValue)
                {
                    EditorGUILayout.PropertyField(BooleanCondition, true);
                    if (BooleanCondition.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                EditorGUILayout.PropertyField(TransformType, true);

                EditorGUILayout.PropertyField(TargetObject, true);
                if (TargetObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(StartTransform, true);
                if (StartTransform.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(EndTransform, true);
                if (EndTransform.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(Offset, true);
                EditorGUILayout.PropertyField(Speed, true);
                EditorGUILayout.PropertyField(usingCoolDown, true);
                if (usingCoolDown.boolValue)
                {
                    EditorGUILayout.PropertyField(CoolDown, true);
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