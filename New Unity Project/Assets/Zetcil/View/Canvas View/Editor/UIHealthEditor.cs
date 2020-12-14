using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Zetcil
{
    [CustomEditor(typeof(UIHealth)), CanEditMultipleObjects]
    public class UIHealthEditor : Editor
    {

        public SerializedProperty
            enum_Status,
            isEnabled,
            timeVariables_prop,
            healthVariables_prop,
            manaVariables_prop,
            expVariables_prop,
            scoreVariables_prop,
            intVariables_prop,
            floatVariables_prop,
            boolVariables_prop,
            stringVariables_prop,
            displaytext_prop,
            usingAutoRotation,
            TargetCanvas,
            TargetCamera
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            enum_Status = serializedObject.FindProperty("VariableType");
            timeVariables_prop = serializedObject.FindProperty("TimeVariables");
            healthVariables_prop = serializedObject.FindProperty("HealthVariables");
            manaVariables_prop = serializedObject.FindProperty("ManaVariables");
            expVariables_prop = serializedObject.FindProperty("ExpVariables");
            scoreVariables_prop = serializedObject.FindProperty("ScoreVariables");
            intVariables_prop = serializedObject.FindProperty("IntVariables");
            floatVariables_prop = serializedObject.FindProperty("FloatVariables");
            boolVariables_prop = serializedObject.FindProperty("BoolVariables");
            stringVariables_prop = serializedObject.FindProperty("StringVariables");
            displaytext_prop = serializedObject.FindProperty("TargetSlider");
            usingAutoRotation = serializedObject.FindProperty("usingAutoRotation");
            TargetCanvas = serializedObject.FindProperty("TargetCanvas");
            TargetCamera = serializedObject.FindProperty("TargetCamera");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            if (isEnabled.boolValue)
            {

                EditorGUILayout.PropertyField(enum_Status);
                GlobalVariable.CVariableType st = (GlobalVariable.CVariableType)enum_Status.enumValueIndex;

                switch (st)
                {
                    case GlobalVariable.CVariableType.timeVar:
                        EditorGUILayout.PropertyField(timeVariables_prop, new GUIContent("TimeVariables"));
                        if (timeVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.healthVar:
                        EditorGUILayout.PropertyField(healthVariables_prop, new GUIContent("HealthVariables"));
                        if (healthVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.manaVar:
                        EditorGUILayout.PropertyField(manaVariables_prop, new GUIContent("ManaVariables"));
                        if (manaVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.expVar:
                        EditorGUILayout.PropertyField(expVariables_prop, new GUIContent("ExpVariables"));
                        if (expVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.scoreVar:
                        EditorGUILayout.PropertyField(scoreVariables_prop, new GUIContent("ScoreVariables"));
                        if (scoreVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.intVar:
                        EditorGUILayout.PropertyField(intVariables_prop, new GUIContent("IntVariables"));
                        if (intVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.floatVar:
                        EditorGUILayout.PropertyField(floatVariables_prop, new GUIContent("FloatVariables"));
                        if (floatVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.stringVar:
                        EditorGUILayout.PropertyField(stringVariables_prop, new GUIContent("StringVariables"));
                        if (stringVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.boolVar:
                        EditorGUILayout.PropertyField(boolVariables_prop, new GUIContent("BoolVariables"));
                        if (boolVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                }

                EditorGUILayout.PropertyField(displaytext_prop, true);

                EditorGUILayout.PropertyField(usingAutoRotation, true);
                if (usingAutoRotation.boolValue)
                {
                    EditorGUILayout.PropertyField(TargetCanvas, true);
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