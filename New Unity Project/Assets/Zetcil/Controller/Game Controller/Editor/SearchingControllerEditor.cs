using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SearchingController)), CanEditMultipleObjects]
    public class SearchingControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetController,
           TargetDestination,
           TargetTag,
           SearchingType,
           SearchingInterval,
           TargetObject,
           NearestIndex,
           NearestValue,
           FarthestIndex,
           FarthestValue
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetController = serializedObject.FindProperty("TargetController");
            TargetDestination = serializedObject.FindProperty("TargetDestination");
            TargetTag = serializedObject.FindProperty("TargetTag");
            SearchingType = serializedObject.FindProperty("SearchingType");
            SearchingInterval = serializedObject.FindProperty("SearchingInterval");
            TargetObject = serializedObject.FindProperty("TargetObject");
            NearestIndex = serializedObject.FindProperty("NearestIndex");
            NearestValue = serializedObject.FindProperty("NearestValue");
            FarthestIndex = serializedObject.FindProperty("FarthestIndex");
            FarthestValue = serializedObject.FindProperty("FarthestValue");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(TargetController, true);
                if (TargetController.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(TargetDestination, true);
                if (TargetDestination.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(TargetTag, true);
                EditorGUILayout.PropertyField(SearchingType, true);
                EditorGUILayout.PropertyField(SearchingInterval, true);
                EditorGUILayout.PropertyField(TargetObject, true);
                if (TargetObject.arraySize == 0)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(NearestIndex, true);
                EditorGUILayout.PropertyField(NearestValue, true);
                EditorGUILayout.PropertyField(FarthestIndex, true);
                EditorGUILayout.PropertyField(FarthestValue, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}