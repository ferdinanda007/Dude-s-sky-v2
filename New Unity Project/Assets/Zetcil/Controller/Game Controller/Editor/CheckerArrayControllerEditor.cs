/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script editor untuk checking variabels
 **************************************************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(CheckerArrayController)), CanEditMultipleObjects]
    public class CheckerArrayControllerEditor : Editor
    {

        public SerializedProperty
            enabled_prop,
            InvokeType,

            usingTimeVariable,
            TimeCondition,
            usingScoreVariable,
            ScoreCondition,
            usingHealthVariable,
            HealthCondition,
            usingIntegerVariable,
            IntegerCondition,
            usingFloatVariable,
            FloatCondition,
            usingBooleanVariable,
            BooleanCondition,
            usingEventSettings,

            usingTrueCondition,
            TrueConditionValue,
            TrueConditionEvent,
            usingFalseCondition,
            FalseConditionValue,
            FalseConditionEvent,

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

            usingTimeVariable = serializedObject.FindProperty("usingTimeVariable");
            TimeCondition = serializedObject.FindProperty("TimeCondition");

            usingScoreVariable = serializedObject.FindProperty("usingScoreVariable");
            ScoreCondition = serializedObject.FindProperty("ScoreCondition");

            usingHealthVariable = serializedObject.FindProperty("usingHealthVariable");
            HealthCondition = serializedObject.FindProperty("HealthCondition");

            usingIntegerVariable = serializedObject.FindProperty("usingIntegerVariable");
            IntegerCondition = serializedObject.FindProperty("IntegerCondition");

            usingFloatVariable = serializedObject.FindProperty("usingFloatVariable");
            FloatCondition = serializedObject.FindProperty("FloatCondition");

            usingBooleanVariable = serializedObject.FindProperty("usingBooleanVariable");
            BooleanCondition = serializedObject.FindProperty("BooleanCondition");

            usingEventSettings = serializedObject.FindProperty("usingEventSettings");

            usingTrueCondition = serializedObject.FindProperty("usingTrueCondition");
            TrueConditionValue = serializedObject.FindProperty("TrueConditionValue");
            TrueConditionEvent = serializedObject.FindProperty("TrueConditionEvent");

            usingFalseCondition = serializedObject.FindProperty("usingFalseCondition");
            FalseConditionValue = serializedObject.FindProperty("FalseConditionValue");
            FalseConditionEvent = serializedObject.FindProperty("FalseConditionEvent");

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

                EditorGUILayout.PropertyField(usingTimeVariable, true);
                if (usingTimeVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(TimeCondition, true);
                }

                EditorGUILayout.PropertyField(usingScoreVariable, true);
                if (usingScoreVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(ScoreCondition, true);
                }

                EditorGUILayout.PropertyField(usingHealthVariable, true);
                if (usingHealthVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(HealthCondition, true);
                }

                EditorGUILayout.PropertyField(usingIntegerVariable, true);
                if (usingIntegerVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(IntegerCondition, true);
                }

                EditorGUILayout.PropertyField(usingFloatVariable, true);
                if (usingFloatVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(FloatCondition, true);
                }

                EditorGUILayout.PropertyField(usingBooleanVariable, true);
                if (usingBooleanVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(BooleanCondition, true);
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
