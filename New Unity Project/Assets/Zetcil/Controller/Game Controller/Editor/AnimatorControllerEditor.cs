using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Zetcil
{
    [CustomEditor(typeof(AnimatorController)), CanEditMultipleObjects]
    public class AnimatorControllerEditor : Editor
    {
        public SerializedProperty
            isEnabled,
            TargetAnimator,
            AnimationType,
            AnimationStateName,
            ParameterType,
            ParameterName,
            TransitionValue,
            usingAdditionalSettings,
            AdditionalEvent
        ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetAnimator = serializedObject.FindProperty("TargetAnimator");
            AnimationType = serializedObject.FindProperty("AnimationType");
            AnimationStateName = serializedObject.FindProperty("AnimationStateName");
            ParameterType = serializedObject.FindProperty("ParameterType");
            ParameterName = serializedObject.FindProperty("ParameterName");
            TransitionValue = serializedObject.FindProperty("TransitionValue");
            usingAdditionalSettings = serializedObject.FindProperty("usingAdditionalSettings");
            AdditionalEvent = serializedObject.FindProperty("AdditionalEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            AnimatorController.CAnimType st = (AnimatorController.CAnimType)AnimationType.enumValueIndex;

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TargetAnimator, true);
                if (TargetAnimator.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(AnimationType, true);

                if (st == AnimatorController.CAnimType.AnimationByName)
                {
                     EditorGUILayout.PropertyField(AnimationStateName, true);
                }
                if (st == AnimatorController.CAnimType.AnimationByParameter)
                {
                    EditorGUILayout.PropertyField(ParameterType, true);
                    EditorGUILayout.PropertyField(ParameterName, true);
                    EditorGUILayout.PropertyField(TransitionValue, true);
                }

                EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                if (usingAdditionalSettings.boolValue)
                {
                    EditorGUILayout.PropertyField(AdditionalEvent, true);
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
