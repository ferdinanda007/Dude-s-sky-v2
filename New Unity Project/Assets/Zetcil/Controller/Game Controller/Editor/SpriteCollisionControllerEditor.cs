using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SpriteCollisionController)), CanEditMultipleObjects]
    public class SpriteCollisionControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CollisionType,
           usingRigidbody2D,
           TargetRigidbody2D,
           usingTriggerEnter2D,
           TriggerEnter2DTag,
           TriggerEnter2DEvent,
           usingDestroyTriggerEnter2D,
           DestroyTriggerEnter2D,
           DestroyTriggerEnter2DDelay,
           usingTriggerExit2D,
           TriggerExit2DTag,
           TriggerExit2DEvent,
           usingCollisionEnter2D,
           CollisionEnter2DTag,
           CollisionEnter2DEvent,
           usingDestroyCollisionEnter2D,
           DestroyCollisionEnter2D,
           DestroyCollisionEnter2DDelay,
           usingCollisionExit2D,
           CollisionExit2DTag,
           CollisionExit2DEvent
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CollisionType = serializedObject.FindProperty("CollisionType");
            usingRigidbody2D = serializedObject.FindProperty("usingRigidbody2D");
            TargetRigidbody2D = serializedObject.FindProperty("TargetRigidbody2D");
            usingTriggerEnter2D = serializedObject.FindProperty("usingTriggerEnter2D");
            TriggerEnter2DTag = serializedObject.FindProperty("TriggerEnter2DTag");
            TriggerEnter2DEvent = serializedObject.FindProperty("TriggerEnter2DEvent");
            usingDestroyTriggerEnter2D = serializedObject.FindProperty("usingDestroyTriggerEnter2D");
            DestroyTriggerEnter2D = serializedObject.FindProperty("DestroyTriggerEnter2D");
            DestroyTriggerEnter2DDelay = serializedObject.FindProperty("DestroyTriggerEnter2DDelay");
            usingTriggerExit2D = serializedObject.FindProperty("usingTriggerExit2D");
            TriggerExit2DTag = serializedObject.FindProperty("TriggerExit2DTag");
            TriggerExit2DEvent = serializedObject.FindProperty("TriggerExit2DEvent");
            usingCollisionEnter2D = serializedObject.FindProperty("usingCollisionEnter2D");
            CollisionEnter2DTag = serializedObject.FindProperty("CollisionEnter2DTag");
            CollisionEnter2DEvent = serializedObject.FindProperty("CollisionEnter2DEvent");
            usingDestroyCollisionEnter2D = serializedObject.FindProperty("usingDestroyCollisionEnter2D");
            DestroyCollisionEnter2D = serializedObject.FindProperty("DestroyCollisionEnter2D");
            DestroyCollisionEnter2DDelay = serializedObject.FindProperty("DestroyCollisionEnter2DDelay");
            usingCollisionExit2D = serializedObject.FindProperty("usingCollisionExit2D");
            CollisionExit2DTag = serializedObject.FindProperty("CollisionExit2DTag");
            CollisionExit2DEvent = serializedObject.FindProperty("CollisionExit2DEvent");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(CollisionType, true);
                EditorGUILayout.PropertyField(usingRigidbody2D, true);
                if (usingRigidbody2D.boolValue)
                {
                    EditorGUILayout.PropertyField(TargetRigidbody2D, true);
                    if (TargetRigidbody2D.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                if ((SpriteCollisionController.CCollisionType)CollisionType.enumValueIndex == SpriteCollisionController.CCollisionType.isTrigger)
                {
                    EditorGUILayout.PropertyField(usingTriggerEnter2D, true);
                    if (usingTriggerEnter2D.boolValue)
                    {
                        EditorGUILayout.PropertyField(TriggerEnter2DTag, true);
                        if (TriggerEnter2DTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }
                        EditorGUILayout.PropertyField(TriggerEnter2DEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingDestroyTriggerEnter2D, true);
                    if (usingDestroyTriggerEnter2D.boolValue)
                    {
                        EditorGUILayout.PropertyField(DestroyTriggerEnter2D, true);
                        EditorGUILayout.PropertyField(DestroyTriggerEnter2DDelay, true);
                    }
                    EditorGUILayout.PropertyField(usingTriggerExit2D, true);
                    if (usingTriggerExit2D.boolValue)
                    {
                        EditorGUILayout.PropertyField(TriggerExit2DTag, true);
                        if (TriggerExit2DTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }
                        EditorGUILayout.PropertyField(TriggerExit2DEvent, true);
                    }
                }
                else if ((SpriteCollisionController.CCollisionType)CollisionType.enumValueIndex == SpriteCollisionController.CCollisionType.isCollision)
                {
                    EditorGUILayout.PropertyField(usingCollisionEnter2D, true);
                    if (usingCollisionEnter2D.boolValue)
                    {
                        EditorGUILayout.PropertyField(CollisionEnter2DTag, true);
                        if (CollisionEnter2DTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }
                        EditorGUILayout.PropertyField(CollisionEnter2DEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingDestroyCollisionEnter2D, true);
                    if (usingDestroyCollisionEnter2D.boolValue)
                    {
                        EditorGUILayout.PropertyField(DestroyCollisionEnter2D, true);
                        EditorGUILayout.PropertyField(DestroyCollisionEnter2DDelay, true);
                    }
                    EditorGUILayout.PropertyField(usingCollisionExit2D, true);
                    if (usingCollisionExit2D.boolValue)
                    {
                        EditorGUILayout.PropertyField(CollisionExit2DTag, true);
                        if (CollisionExit2DTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }
                        EditorGUILayout.PropertyField(CollisionExit2DEvent, true);
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