using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(CheckerLogicController)), CanEditMultipleObjects]
    public class CheckerLogicControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            InvokeType,
            LogicType,
            usingConditionLogic,
            usingInputCondition,
            InputCondition,
            usingTimeVariable,
            TimeCondition,
            usingScoreVariable,
            ScoreCondition,
            usingHealthVariable,
            HealthCondition,
            usingManaVariable,
            ManaCondition,
            usingExpVariable,
            ExpCondition,
            usingIntegerVariable,
            IntegerCondition,
            usingFloatVariable,
            FloatCondition,
            usingBooleanVariable,
            BooleanCondition,
            usingStringVariable,
            StringCondition,
            usingEventStatus,
            ConditionResult,
            usingTrueEventSettings,
            TrueEventSettings,
            usingFalseEventSettings,
            FalseEventSettings,
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
            isEnabled = serializedObject.FindProperty("isEnabled");
            InvokeType = serializedObject.FindProperty("InvokeType");
            LogicType = serializedObject.FindProperty("LogicType");
            usingInputCondition = serializedObject.FindProperty("usingInputCondition");
            InputCondition = serializedObject.FindProperty("InputCondition");
            usingTimeVariable = serializedObject.FindProperty("usingTimeVariable");
            TimeCondition = serializedObject.FindProperty("TimeCondition");
            usingScoreVariable = serializedObject.FindProperty("usingScoreVariable");
            ScoreCondition = serializedObject.FindProperty("ScoreCondition");
            usingHealthVariable = serializedObject.FindProperty("usingHealthVariable");
            HealthCondition = serializedObject.FindProperty("HealthCondition");
            usingManaVariable = serializedObject.FindProperty("usingManaVariable");
            ManaCondition = serializedObject.FindProperty("ManaCondition");
            usingExpVariable = serializedObject.FindProperty("usingExpVariable");
            ExpCondition = serializedObject.FindProperty("ExpCondition");
            usingIntegerVariable = serializedObject.FindProperty("usingIntegerVariable");
            IntegerCondition = serializedObject.FindProperty("IntegerCondition");
            usingFloatVariable = serializedObject.FindProperty("usingFloatVariable");
            FloatCondition = serializedObject.FindProperty("FloatCondition");
            usingBooleanVariable = serializedObject.FindProperty("usingBooleanVariable");
            BooleanCondition = serializedObject.FindProperty("BooleanCondition");
            usingStringVariable = serializedObject.FindProperty("usingStringVariable");
            StringCondition = serializedObject.FindProperty("StringCondition");
            ConditionResult = serializedObject.FindProperty("ConditionResult");
            usingTrueEventSettings = serializedObject.FindProperty("usingTrueEventSettings");
            TrueEventSettings = serializedObject.FindProperty("TrueEventSettings");
            usingFalseEventSettings = serializedObject.FindProperty("usingFalseEventSettings");
            FalseEventSettings = serializedObject.FindProperty("FalseEventSettings");

            usingConditionLogic = serializedObject.FindProperty("usingConditionLogic");
            usingEventStatus = serializedObject.FindProperty("usingEventStatus");

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

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(InvokeType, true);

                EditorGUILayout.PropertyField(LogicType, true);

                EditorGUILayout.PropertyField(usingConditionLogic, true);

                if (usingConditionLogic.boolValue)
                {


                    EditorGUILayout.PropertyField(usingInputCondition, true);
                    if (usingInputCondition.boolValue)
                    {
                        EditorGUILayout.PropertyField(InputCondition, true);
                    }

                    EditorGUILayout.PropertyField(usingTimeVariable, true);
                    if (usingTimeVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(TimeCondition, true);
                        if (TimeCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingScoreVariable, true);
                    if (usingScoreVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(ScoreCondition, true);
                        if (ScoreCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingHealthVariable, true);
                    if (usingHealthVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(HealthCondition, true);
                        if (HealthCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingManaVariable, true);
                    if (usingManaVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(ManaCondition, true);
                        if (ManaCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingExpVariable, true);
                    if (usingExpVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(ExpCondition, true);
                        if (ExpCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingIntegerVariable, true);
                    if (usingIntegerVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(IntegerCondition, true);
                        if (IntegerCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingFloatVariable, true);
                    if (usingFloatVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(FloatCondition, true);
                        if (FloatCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingBooleanVariable, true);
                    if (usingBooleanVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(BooleanCondition, true);
                        if (BooleanCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingStringVariable, true);
                    if (usingStringVariable.boolValue)
                    {
                        EditorGUILayout.PropertyField(StringCondition, true);
                        if (StringCondition.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                }

                EditorGUILayout.PropertyField(usingEventStatus, true);

                if (usingEventStatus.boolValue)
                {
                    EditorGUILayout.PropertyField(ConditionResult, true);

                    EditorGUILayout.PropertyField(usingTrueEventSettings, true);
                    if (usingTrueEventSettings.boolValue)
                    {
                        EditorGUILayout.PropertyField(TrueEventSettings, true);
                    }

                    EditorGUILayout.PropertyField(usingFalseEventSettings, true);
                    if (usingFalseEventSettings.boolValue)
                    {
                        EditorGUILayout.PropertyField(FalseEventSettings, true);
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
                    EditorGUILayout.PropertyField(RepeatChecking, true);
                    EditorGUILayout.PropertyField(usingInterval, true);
                    if (usingInterval.boolValue)
                    {
                        EditorGUILayout.PropertyField(Interval, true);
                        Interval.floatValue = 1;
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
