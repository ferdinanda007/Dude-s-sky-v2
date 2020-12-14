using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(RaycastController)), CanEditMultipleObjects]
    public class RaycastControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            TargetCamera,
            TargetObject,
            ClickType,
            ObjectSelection,
            ObjectName,
            ObjectTag,
            usingOnHitEvent,
            OnHitEvent,
            usingOffHitEvent,
            OffHitEvent,
            SelectedObjectType,
            SelectedObjectTag,
            SelectedObjectName
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetCamera = serializedObject.FindProperty("TargetCamera");
            TargetObject = serializedObject.FindProperty("TargetObject");
            ClickType = serializedObject.FindProperty("ClickType");
            ObjectSelection = serializedObject.FindProperty("ObjectSelection");
            ObjectName = serializedObject.FindProperty("ObjectName");
            ObjectTag = serializedObject.FindProperty("ObjectTag");
            usingOnHitEvent = serializedObject.FindProperty("usingOnHitEvent");
            OnHitEvent = serializedObject.FindProperty("OnHitEvent");
            usingOffHitEvent = serializedObject.FindProperty("usingOffHitEvent");
            OffHitEvent = serializedObject.FindProperty("OffHitEvent");
            SelectedObjectType = serializedObject.FindProperty("SelectedObjectType");
            SelectedObjectTag = serializedObject.FindProperty("SelectedObjectTag");
            SelectedObjectName = serializedObject.FindProperty("SelectedObjectName");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TargetObject, true);
                if (TargetObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(TargetCamera, true);
                if (TargetCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(ClickType, true);
                EditorGUILayout.PropertyField(ObjectSelection, true);

                RaycastController.CFilterSelection st = (RaycastController.CFilterSelection) ObjectSelection.enumValueIndex;

                if (st == RaycastController.CFilterSelection.ByName)
                {
                    EditorGUILayout.PropertyField(ObjectName, true);
                }
                if (st == RaycastController.CFilterSelection.ByTag)
                {
                    EditorGUILayout.PropertyField(ObjectTag, true);
                }
                EditorGUILayout.PropertyField(usingOnHitEvent, true);
                if (usingOnHitEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(OnHitEvent, true);
                }
                EditorGUILayout.PropertyField(usingOffHitEvent, true);
                if (usingOffHitEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(OffHitEvent, true);
                }
                EditorGUILayout.PropertyField(SelectedObjectType, true);
                EditorGUILayout.PropertyField(SelectedObjectTag, true);
                EditorGUILayout.PropertyField(SelectedObjectName, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }

}