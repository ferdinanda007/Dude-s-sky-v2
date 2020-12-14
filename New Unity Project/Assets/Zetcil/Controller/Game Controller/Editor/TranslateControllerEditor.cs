using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(TranslateController)), CanEditMultipleObjects]
    public class TranslateControllerEditorEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           OutputType,
           TargetVarString,
           TargetUIText,
           TargetUITextMesh,
           TargetInputField,
           LanguageID
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            OutputType = serializedObject.FindProperty("OutputType");
            TargetVarString = serializedObject.FindProperty("TargetVarString");
            TargetUIText = serializedObject.FindProperty("TargetUIText");
            TargetUITextMesh = serializedObject.FindProperty("TargetUITextMesh");
            TargetInputField = serializedObject.FindProperty("TargetInputField");
            LanguageID = serializedObject.FindProperty("LanguageID");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(OutputType, true);
                if ((TranslateController.COutputType) OutputType.enumValueIndex == TranslateController.COutputType.VarString)
                {
                    EditorGUILayout.PropertyField(TargetVarString, true);
                    if (TargetVarString.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }
                if ((TranslateController.COutputType)OutputType.enumValueIndex == TranslateController.COutputType.UIText)
                {
                    EditorGUILayout.PropertyField(TargetUIText, true);
                    if (TargetUIText.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }
                if ((TranslateController.COutputType)OutputType.enumValueIndex == TranslateController.COutputType.UITextMesh)
                {
                    EditorGUILayout.PropertyField(TargetUITextMesh, true);
                    if (TargetUITextMesh.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }
                if ((TranslateController.COutputType)OutputType.enumValueIndex == TranslateController.COutputType.InputField)
                {
                    EditorGUILayout.PropertyField(TargetInputField, true);
                    if (TargetInputField.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }
                EditorGUILayout.PropertyField(LanguageID, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}