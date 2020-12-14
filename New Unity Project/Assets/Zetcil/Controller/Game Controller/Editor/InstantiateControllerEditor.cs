using UnityEditor;
using UnityEngine;

namespace Zetcil 
{
    [CustomEditor(typeof(InstantiateController)), CanEditMultipleObjects]
    public class InstantiateControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            InvokeType,
            TargetPrefab,
            TargetPosition,
            usingParent,
            TargetParent,
            AfterInstantiate,
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
            AfterInstantiate = serializedObject.FindProperty("AfterInstantiate");
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
                    EditorGUILayout.PropertyField(AfterInstantiate);
                    EditorGUILayout.PropertyField(TargetParent);
                    if (TargetParent.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                GlobalVariable.CInvokeType st = (GlobalVariable.CInvokeType) InvokeType.enumValueIndex;
                switch (st)
                {
                    case GlobalVariable.CInvokeType.OnAwake:
                        break;
                    case GlobalVariable.CInvokeType.OnDelay:
                        EditorGUILayout.PropertyField(usingDelay);
                        EditorGUILayout.PropertyField(Delay);
                        break;
                    case GlobalVariable.CInvokeType.OnInterval:
                        EditorGUILayout.PropertyField(usingInterval);
                        EditorGUILayout.PropertyField(Interval);
                        break;
                    case GlobalVariable.CInvokeType.OnEvent:
                        EditorGUILayout.PropertyField(usingDelay);
                        EditorGUILayout.PropertyField(Delay);
                        break;
                }

            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}