using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(LevelController)), CanEditMultipleObjects]
    public class LevelControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled_prop,
            LoadingType_prop,
            WaitSecond_prop,
            NextSceneName_prop,
            WithLoadingScreen_prop,
            NextSceneIndex_prop,
            CollisionType_prop,
            KeyPress_prop,
            ObjectTag_prop,
            usingRigidbody2D,
            TargetRigidbody2D,
            usingRigidbody3D,
            TargetRigidbody3D,
            usingVarString,
            VarScenename
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled_prop = serializedObject.FindProperty("isEnabled");
            LoadingType_prop = serializedObject.FindProperty("LoadingType");
            WaitSecond_prop = serializedObject.FindProperty("WaitSecond");
            NextSceneName_prop = serializedObject.FindProperty("NextSceneName");
            WithLoadingScreen_prop = serializedObject.FindProperty("WithLoadingScreen");
            NextSceneIndex_prop = serializedObject.FindProperty("NextSceneIndex");
            CollisionType_prop = serializedObject.FindProperty("CollisionType");
            KeyPress_prop = serializedObject.FindProperty("KeyPress");
            ObjectTag_prop = serializedObject.FindProperty("ObjectTag");
            usingRigidbody2D = serializedObject.FindProperty("usingRigidbody2D");
            TargetRigidbody2D = serializedObject.FindProperty("TargetRigidbody2D");
            usingRigidbody3D = serializedObject.FindProperty("usingRigidbody3D");
            TargetRigidbody3D = serializedObject.FindProperty("TargetRigidbody3D");

            usingVarString = serializedObject.FindProperty("usingVarString");
            VarScenename = serializedObject.FindProperty("VarScenename");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled_prop);

            bool check = isEnabled_prop.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(LoadingType_prop);
                LevelController.CLoadingType st = (LevelController.CLoadingType)LoadingType_prop.enumValueIndex;

                switch (st)
                {
                    case LevelController.CLoadingType.ByEvent:
                        break;
                    case LevelController.CLoadingType.ByClick:
                        break;
                    case LevelController.CLoadingType.ByClickAndLoading:
                        break;
                    case LevelController.CLoadingType.ByKeyPress:
                        EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                        EditorGUILayout.PropertyField(KeyPress_prop, new GUIContent("KeyPress"));
                        break;
                    case LevelController.CLoadingType.ByKeyPressAndLoading:
                        EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                        EditorGUILayout.PropertyField(KeyPress_prop, new GUIContent("KeyPress"));
                        break;
                    case LevelController.CLoadingType.ByDelay:
                        EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                        EditorGUILayout.PropertyField(WaitSecond_prop, new GUIContent("WaitSecond"));
                        break;
                    case LevelController.CLoadingType.ByDelayAndLoading:
                        EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                        EditorGUILayout.PropertyField(WaitSecond_prop, new GUIContent("WaitSecond"));
                        break;
                    case LevelController.CLoadingType.ByCollision:
                        EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                        EditorGUILayout.PropertyField(CollisionType_prop, new GUIContent("CollisionType"));
                        EditorGUILayout.PropertyField(ObjectTag_prop, new GUIContent("ObjectTag"));

                        EditorGUILayout.PropertyField(usingRigidbody2D, new GUIContent("using Rigidbody2D"));
                        EditorGUILayout.PropertyField(TargetRigidbody2D, new GUIContent("Target Rigidbody2D"));
                        EditorGUILayout.PropertyField(usingRigidbody3D, new GUIContent("using Rigidbody3D"));
                        EditorGUILayout.PropertyField(TargetRigidbody3D, new GUIContent("Target Rigidbody3D"));
                        break;
                    case LevelController.CLoadingType.ByCollisionAndLoading:
                        EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                        EditorGUILayout.PropertyField(CollisionType_prop, new GUIContent("CollisionType"));
                        EditorGUILayout.PropertyField(ObjectTag_prop, new GUIContent("ObjectTag"));

                        EditorGUILayout.PropertyField(usingRigidbody2D, new GUIContent("using Rigidbody2D"));
                        EditorGUILayout.PropertyField(TargetRigidbody2D, new GUIContent("Target Rigidbody2D"));
                        EditorGUILayout.PropertyField(usingRigidbody3D, new GUIContent("using Rigidbody3D"));
                        EditorGUILayout.PropertyField(TargetRigidbody3D, new GUIContent("Target Rigidbody3D"));
                        break;
                }

                EditorGUILayout.PropertyField(usingVarString, true);
                if (usingVarString.boolValue)
                {
                    EditorGUILayout.PropertyField(VarScenename, true);
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