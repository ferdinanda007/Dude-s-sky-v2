/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script editor untuk checking variabels
 **************************************************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(TransferController)), CanEditMultipleObjects]
    public class TransferControllerEditor : Editor
    {

        public SerializedProperty
            enabled_prop,
            enum_Status,
            timeSender_prop,
            timeReceiver_prop,
            healthSender_prop,
            healthReceiver_prop,
            manaSender_prop,
            manaReceiver_prop,
            expSender_prop,
            expReceiver_prop,
            scoreSender_prop,
            scoreReceiver_prop,
            intSender_prop,
            intReceiver_prop,
            floatSender_prop,
            floatReceiver_prop,
            boolSender_prop,
            boolReceiver_prop,
            stringSender_prop,
            stringReceiver_prop,
            Increment_prop,
            ThreeSecondComplete,
            usingAttributeSettings,
            AttributeSettings
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            enabled_prop = serializedObject.FindProperty("isEnabled");
            enum_Status = serializedObject.FindProperty("VariableType");

            timeSender_prop = serializedObject.FindProperty("TimeSender");
            healthSender_prop = serializedObject.FindProperty("HealthSender");
            manaSender_prop = serializedObject.FindProperty("ManaSender");
            expSender_prop = serializedObject.FindProperty("ExpSender");
            scoreSender_prop = serializedObject.FindProperty("ScoreSender");
            intSender_prop = serializedObject.FindProperty("IntSender");
            floatSender_prop = serializedObject.FindProperty("FloatSender");
            boolSender_prop = serializedObject.FindProperty("BoolSender");
            stringSender_prop = serializedObject.FindProperty("StringSender");

            timeReceiver_prop = serializedObject.FindProperty("TimeReceiver");
            healthReceiver_prop = serializedObject.FindProperty("HealthReceiver");
            manaReceiver_prop = serializedObject.FindProperty("ManaReceiver");
            expReceiver_prop = serializedObject.FindProperty("ExpReceiver");
            scoreReceiver_prop = serializedObject.FindProperty("ScoreReceiver");
            intReceiver_prop = serializedObject.FindProperty("IntReceiver");
            floatReceiver_prop = serializedObject.FindProperty("FloatReceiver");
            boolReceiver_prop = serializedObject.FindProperty("BoolReceiver");
            stringReceiver_prop = serializedObject.FindProperty("StringReceiver");

            Increment_prop = serializedObject.FindProperty("Increment");
            ThreeSecondComplete = serializedObject.FindProperty("ThreeSecondComplete");

            usingAttributeSettings = serializedObject.FindProperty("usingAttributeSettings");
            AttributeSettings = serializedObject.FindProperty("AttributeSettings");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enabled_prop, true);

            bool check = enabled_prop.boolValue;

            if (check)
            {

                EditorGUILayout.PropertyField(enum_Status);

                GlobalVariable.CVariableType st = (GlobalVariable.CVariableType)enum_Status.enumValueIndex;

                switch (st)
                {
                    case GlobalVariable.CVariableType.timeVar:
                        EditorGUILayout.PropertyField(timeSender_prop, new GUIContent("TimeSender"));
                        EditorGUILayout.PropertyField(timeReceiver_prop, new GUIContent("TimeReceiver"));
                        break;
                    case GlobalVariable.CVariableType.scoreVar:
                        EditorGUILayout.PropertyField(scoreSender_prop, new GUIContent("ScoreSender"));
                        EditorGUILayout.PropertyField(scoreReceiver_prop, new GUIContent("ScoreReceiver"));
                        break;
                    case GlobalVariable.CVariableType.healthVar:
                        EditorGUILayout.PropertyField(healthSender_prop, new GUIContent("HealthSender"));
                        EditorGUILayout.PropertyField(healthReceiver_prop, new GUIContent("HealthReceiver"));
                        break;
                    case GlobalVariable.CVariableType.manaVar:
                        EditorGUILayout.PropertyField(manaSender_prop, new GUIContent("ManaSender"));
                        EditorGUILayout.PropertyField(manaReceiver_prop, new GUIContent("ManaReceiver"));
                        break;
                    case GlobalVariable.CVariableType.expVar:
                        EditorGUILayout.PropertyField(expSender_prop, new GUIContent("ExpSender"));
                        EditorGUILayout.PropertyField(expReceiver_prop, new GUIContent("ExpReceiver"));
                        break;
                    case GlobalVariable.CVariableType.intVar:
                        EditorGUILayout.PropertyField(intSender_prop, new GUIContent("IntSender"));
                        EditorGUILayout.PropertyField(intReceiver_prop, new GUIContent("IntReceiver"));
                        break;
                    case GlobalVariable.CVariableType.floatVar:
                        EditorGUILayout.PropertyField(floatSender_prop, new GUIContent("FloatSender"));
                        EditorGUILayout.PropertyField(floatReceiver_prop, new GUIContent("FloatReceiver"));
                        break;
                    case GlobalVariable.CVariableType.stringVar:
                        EditorGUILayout.PropertyField(stringSender_prop, new GUIContent("StringSender"));
                        EditorGUILayout.PropertyField(stringReceiver_prop, new GUIContent("StringReceiver"));
                        break;
                    case GlobalVariable.CVariableType.boolVar:
                        EditorGUILayout.PropertyField(boolSender_prop, new GUIContent("BoolSender"));
                        EditorGUILayout.PropertyField(boolReceiver_prop, new GUIContent("BoolReceiver"));
                        break;
                }

                EditorGUILayout.PropertyField(Increment_prop, true);
                EditorGUILayout.PropertyField(ThreeSecondComplete, true);
                
                EditorGUILayout.PropertyField(usingAttributeSettings, true);
                EditorGUILayout.PropertyField(AttributeSettings, true);

            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
