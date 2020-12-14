/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script editor untuk var manager
 **************************************************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(MovingPanel)), CanEditMultipleObjects]
    public class MovingPanelEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            CanvasInitType,
            MainCanvasName,
            MainCanvas,
            MainPanel
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");

            CanvasInitType = serializedObject.FindProperty("CanvasInitType");
            MainCanvasName = serializedObject.FindProperty("MainCanvasName");
            MainCanvas = serializedObject.FindProperty("MainCanvas");
            MainPanel = serializedObject.FindProperty("MainPanel");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled, true);

            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(CanvasInitType, true);

                MovingPanel.CCanvasInitType opt = (MovingPanel.CCanvasInitType)CanvasInitType.enumValueIndex;

                switch (opt)
                {
                    case MovingPanel.CCanvasInitType.ByGameObject:
                        EditorGUILayout.PropertyField(MainCanvasName, true);
                        EditorGUILayout.PropertyField(MainCanvas, true);
                        EditorGUILayout.PropertyField(MainPanel, true);
                        break;
                    case MovingPanel.CCanvasInitType.ByName:
                        EditorGUILayout.PropertyField(MainCanvas, true);
                        EditorGUILayout.PropertyField(MainPanel, true);
                        break;
                }

            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
