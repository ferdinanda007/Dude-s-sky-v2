using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SlideController)), CanEditMultipleObjects]
    public class SlideControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           SlideType,
           PrevKey,
           NextKey,
           Interval,
           usingSlideObject,
           SlideObject,
           CurrentIndex
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            SlideType = serializedObject.FindProperty("SlideType");
            PrevKey = serializedObject.FindProperty("PrevKey");
            NextKey = serializedObject.FindProperty("NextKey");
            Interval = serializedObject.FindProperty("Interval");
            usingSlideObject = serializedObject.FindProperty("usingSlideObject");
            SlideObject = serializedObject.FindProperty("SlideObject");
            CurrentIndex = serializedObject.FindProperty("CurrentIndex");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(SlideType, true);
                if ((SlideController.CSlideType) SlideType.enumValueIndex == SlideController.CSlideType.OnKeyboard)
                {
                    EditorGUILayout.PropertyField(PrevKey, true);
                    EditorGUILayout.PropertyField(NextKey, true);
                }
                if ((SlideController.CSlideType)SlideType.enumValueIndex == SlideController.CSlideType.OnInterval)
                {
                    EditorGUILayout.PropertyField(Interval, true);
                }
                EditorGUILayout.PropertyField(usingSlideObject, true);
                if (usingSlideObject.boolValue)
                {
                    EditorGUILayout.PropertyField(SlideObject, true);
                    
                }
                EditorGUILayout.PropertyField(CurrentIndex, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}