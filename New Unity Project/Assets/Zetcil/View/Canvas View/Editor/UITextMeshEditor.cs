/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script editor untuk body
 **************************************************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UITextMesh)), CanEditMultipleObjects]
    public class UITextMeshEditor : Editor
    {

        public SerializedProperty
            enum_Status,
            enabled_prop,
            timeVariables_prop,
            healthVariables_prop,
            manaVariables_prop,
            expVariables_prop,
            scoreVariables_prop,
            intVariables_prop,
            floatVariables_prop,
            boolVariables_prop,
            stringVariables_prop,
            usingDebug_prop,
            DebugText_prop,
            CaptionText_prop,
            PrefixText_prop,
            PostfixText_prop,
            usingTime_prop,
            TimeFormat_prop,
            CaptionTime_prop,
            pCaptionTime_prop
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            enum_Status = serializedObject.FindProperty("VariableType");

            enabled_prop = serializedObject.FindProperty("isEnabled");
            timeVariables_prop = serializedObject.FindProperty("TimeVariables");
            healthVariables_prop = serializedObject.FindProperty("HealthVariables");
            manaVariables_prop = serializedObject.FindProperty("ManaVariables");
            expVariables_prop = serializedObject.FindProperty("ExpVariables");
            scoreVariables_prop = serializedObject.FindProperty("ScoreVariables");
            intVariables_prop = serializedObject.FindProperty("IntVariables");
            floatVariables_prop = serializedObject.FindProperty("FloatVariables");
            boolVariables_prop = serializedObject.FindProperty("BoolVariables");
            stringVariables_prop = serializedObject.FindProperty("StringVariables");
            usingDebug_prop = serializedObject.FindProperty("usingDebug");
            DebugText_prop = serializedObject.FindProperty("DebugText");
            CaptionText_prop = serializedObject.FindProperty("TargetText");
            PrefixText_prop = serializedObject.FindProperty("PrefixText");
            PostfixText_prop = serializedObject.FindProperty("PostfixText");
            usingTime_prop = serializedObject.FindProperty("usingTimeFormat");
            TimeFormat_prop = serializedObject.FindProperty("TimeFormat");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enabled_prop, true);

            if (enabled_prop.boolValue)
            {


                EditorGUILayout.PropertyField(enum_Status);
                GlobalVariable.CVariableType st = (GlobalVariable.CVariableType)enum_Status.enumValueIndex;

                switch (st)
                {
                    case GlobalVariable.CVariableType.scoreVar:
                        EditorGUILayout.PropertyField(scoreVariables_prop, new GUIContent("ScoreVariables"));
                        if (scoreVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }
                        break;
                    case GlobalVariable.CVariableType.timeVar:
                        EditorGUILayout.PropertyField(timeVariables_prop, new GUIContent("TimeVariables"));
                        if (timeVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null/None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingTime_prop, true);
                        EditorGUILayout.PropertyField(TimeFormat_prop, true);

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

                EditorGUILayout.PropertyField(CaptionText_prop, true);
                EditorGUILayout.PropertyField(PrefixText_prop, true);
                EditorGUILayout.PropertyField(PostfixText_prop, true);

                EditorGUILayout.PropertyField(usingDebug_prop, true);
                EditorGUILayout.PropertyField(DebugText_prop, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
