/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script editor untuk checking variabels
 **************************************************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(CheckerController)), CanEditMultipleObjects]
    public class CheckerControllerEditor : Editor
    {

        public SerializedProperty
            enabled_prop,
            InvokeType,

            enum_Status,
            timeVariables_prop,
            healthVariables_prop,
            manaVariables_prop,
            expVariables_prop,
            scoreVariables_prop,
            intVariables_prop,
            floatVariables_prop,
            boolVariables_prop,
            objectVariables_prop,
            stringVariables_prop,

            usingTrueCondition,
            TrueConditionValue,
            TrueConditionEvent,
            usingFalseCondition,
            FalseConditionValue,
            FalseConditionEvent,

            usingEqualCondition,
            EqualConditionValue,
            EqualConditionEvent,
            usingNotEqualCondition,
            NotEqualConditionValue,
            NotEqualConditionEvent,

            usingTagEqualCondition,
            TagEqualConditionValue,
            TagEqualConditionEvent,
            usingNotTagEqualCondition,
            NotTagEqualConditionValue,
            NotTagEqualConditionEvent,

            usingNameEqualCondition,
            NameEqualConditionValue,
            NameEqualConditionEvent,
            usingNotNameEqualCondition,
            NotNameEqualConditionValue,
            NotNameEqualConditionEvent,

            usingGreaterCondition,
            GreaterConditionValue,
            GreaterConditionEvent,
            usingLessCondition,
            LessConditionValue,
            LessConditionEvent,

            RepeatChecking,

            //--Invoke type (1)
        usingDelay,
            Delay,
            usingInterval,
            Interval
            ;


        void OnEnable()
        {
            // Setup the SerializedProperties
            enabled_prop = serializedObject.FindProperty("isEnabled");
            InvokeType = serializedObject.FindProperty("InvokeType");
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
            objectVariables_prop = serializedObject.FindProperty("ObjectVariables");

            usingTrueCondition = serializedObject.FindProperty("usingTrueCondition");
            TrueConditionValue = serializedObject.FindProperty("TrueConditionValue");
            TrueConditionEvent = serializedObject.FindProperty("TrueConditionEvent");

            usingFalseCondition = serializedObject.FindProperty("usingFalseCondition");
            FalseConditionValue = serializedObject.FindProperty("FalseConditionValue");
            FalseConditionEvent = serializedObject.FindProperty("FalseConditionEvent");

            usingEqualCondition = serializedObject.FindProperty("usingEqualCondition");
            EqualConditionValue = serializedObject.FindProperty("EqualConditionValue");
            EqualConditionEvent = serializedObject.FindProperty("EqualConditionEvent");

            usingNotEqualCondition = serializedObject.FindProperty("usingNotEqualCondition");
            NotEqualConditionValue = serializedObject.FindProperty("NotEqualConditionValue");
            NotEqualConditionEvent = serializedObject.FindProperty("NotEqualConditionEvent");

            usingTagEqualCondition = serializedObject.FindProperty("usingTagEqualCondition");
            TagEqualConditionValue = serializedObject.FindProperty("TagEqualConditionValue");
            TagEqualConditionEvent = serializedObject.FindProperty("TagEqualConditionEvent");

            usingNotTagEqualCondition = serializedObject.FindProperty("usingNotTagEqualCondition");
            NotTagEqualConditionValue = serializedObject.FindProperty("NotTagEqualConditionValue");
            NotTagEqualConditionEvent = serializedObject.FindProperty("NotTagEqualConditionEvent");

            usingNameEqualCondition = serializedObject.FindProperty("usingNameEqualCondition");
            NameEqualConditionValue = serializedObject.FindProperty("NameEqualConditionValue");
            NameEqualConditionEvent = serializedObject.FindProperty("NameEqualConditionEvent");

            usingNotNameEqualCondition = serializedObject.FindProperty("usingNotNameEqualCondition");
            NotNameEqualConditionValue = serializedObject.FindProperty("NotNameEqualConditionValue");
            NotNameEqualConditionEvent = serializedObject.FindProperty("NotNameEqualConditionEvent");

            usingGreaterCondition = serializedObject.FindProperty("usingGreaterCondition");
            GreaterConditionValue = serializedObject.FindProperty("GreaterConditionValue");
            GreaterConditionEvent = serializedObject.FindProperty("GreaterConditionEvent");

            usingLessCondition = serializedObject.FindProperty("usingLessCondition");
            LessConditionValue = serializedObject.FindProperty("LessConditionValue");
            LessConditionEvent = serializedObject.FindProperty("LessConditionEvent");

            //--Invoke type (2)
            RepeatChecking = serializedObject.FindProperty("RepeatChecking");
            usingDelay = serializedObject.FindProperty("usingDelay");
            Delay = serializedObject.FindProperty("Delay");
            usingInterval = serializedObject.FindProperty("usingInterval");
            Interval = serializedObject.FindProperty("Interval");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enabled_prop, true);
            

            bool check = enabled_prop.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(InvokeType, true);

                EditorGUILayout.PropertyField(enum_Status);
                

                GlobalVariable.CVariableType st = (GlobalVariable.CVariableType)enum_Status.enumValueIndex;

                switch (st)
                {
                    case GlobalVariable.CVariableType.scoreVar:
                        EditorGUILayout.PropertyField(scoreVariables_prop, new GUIContent("Score Variables"));
                        if (scoreVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.timeVar:
                        EditorGUILayout.PropertyField(timeVariables_prop, new GUIContent("Time Variables"));
                        if (timeVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.healthVar:
                        EditorGUILayout.PropertyField(healthVariables_prop, new GUIContent("Health Variables"));
                        if (healthVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.manaVar:
                        EditorGUILayout.PropertyField(manaVariables_prop, new GUIContent("Mana Variables"));
                        if (manaVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.expVar:
                        EditorGUILayout.PropertyField(expVariables_prop, new GUIContent("Exp Variables"));
                        if (expVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.intVar:
                        EditorGUILayout.PropertyField(intVariables_prop, new GUIContent("Int Variables"));
                        if (intVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.floatVar:
                        EditorGUILayout.PropertyField(floatVariables_prop, new GUIContent("Float Variables"));
                        if (floatVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingGreaterCondition, true);
                        if (usingGreaterCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(GreaterConditionValue, true);
                            EditorGUILayout.PropertyField(GreaterConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingLessCondition, true);
                        if (usingLessCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(LessConditionValue, true);
                            EditorGUILayout.PropertyField(LessConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.stringVar:
                        EditorGUILayout.PropertyField(stringVariables_prop, new GUIContent("String Variables"));
                        if (stringVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingEqualCondition, true);
                        if (usingEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(EqualConditionValue, true);
                            EditorGUILayout.PropertyField(EqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingNotEqualCondition, true);
                        if (usingNotEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(NotEqualConditionValue, true);
                            EditorGUILayout.PropertyField(NotEqualConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.boolVar:
                        EditorGUILayout.PropertyField(boolVariables_prop, new GUIContent("Bool Variables"));
                        if (boolVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingTrueCondition, true);
                        if (usingTrueCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(TrueConditionValue, true);
                            EditorGUILayout.PropertyField(TrueConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingFalseCondition, true);
                        if (usingFalseCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(FalseConditionValue, true);
                            EditorGUILayout.PropertyField(FalseConditionEvent, true);
                        }

                        break;
                    case GlobalVariable.CVariableType.objectVar:
                        EditorGUILayout.PropertyField(objectVariables_prop, new GUIContent("Object Variables"));
                        if (objectVariables_prop.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(usingTagEqualCondition, true);
                        if (usingTagEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(TagEqualConditionValue, true);
                            EditorGUILayout.PropertyField(TagEqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingNotTagEqualCondition, true);
                        if (usingNotTagEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(NotTagEqualConditionValue, true);
                            EditorGUILayout.PropertyField(NotTagEqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingNameEqualCondition, true);
                        if (usingNameEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(NameEqualConditionValue, true);
                            EditorGUILayout.PropertyField(NameEqualConditionEvent, true);
                        }

                        EditorGUILayout.PropertyField(usingNotNameEqualCondition, true);
                        if (usingNotNameEqualCondition.boolValue)
                        {
                            EditorGUILayout.PropertyField(NotNameEqualConditionValue, true);
                            EditorGUILayout.PropertyField(NotNameEqualConditionEvent, true);
                        }

                        break;
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
                    EditorGUILayout.PropertyField(RepeatChecking, true);

                    EditorGUILayout.PropertyField(usingInterval, true);
                    usingInterval.boolValue = true;
                    if (usingInterval.boolValue)
                    {
                        EditorGUILayout.PropertyField(Interval, true);
                        Interval.floatValue = 1;
                    }
                }

                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnEvent)
                {
                    EditorGUILayout.PropertyField(RepeatChecking, true);
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
