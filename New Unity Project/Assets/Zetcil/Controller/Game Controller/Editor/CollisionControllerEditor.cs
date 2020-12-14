using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(CollisionController)), CanEditMultipleObjects]
    public class CollisionControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            CollisionType,
            usingRigidbody3D,
            TargetRigidbody,
            usingTriggerEnter,
            TriggerEnterTag,
            TriggerEnterEvent,

            usingDestroyTriggerEnter,
            DestroyTriggerEnter,
            DestroyTriggerEnterDelay,

            usingTriggerExit,
            TriggerExitTag,
            TriggerExitEvent,
            usingCollisionEnter,
            CollisionEnterTag,
            CollisionEnterEvent,

            usingDestroyCollisionEnter,
            DestroyCollisionEnter,
            DestroyCollisionEnterDelay,

            usingCollisionExit,
            CollisionExitTag,
            CollisionExitEvent
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            CollisionType = serializedObject.FindProperty("CollisionType");

            usingRigidbody3D = serializedObject.FindProperty("usingRigidbody3D");
            TargetRigidbody = serializedObject.FindProperty("TargetRigidbody");

            usingTriggerEnter = serializedObject.FindProperty("usingTriggerEnter");
            TriggerEnterTag = serializedObject.FindProperty("TriggerEnterTag");
            TriggerEnterEvent = serializedObject.FindProperty("TriggerEnterEvent");

            usingDestroyTriggerEnter = serializedObject.FindProperty("usingDestroyTriggerEnter");
            DestroyTriggerEnter = serializedObject.FindProperty("DestroyTriggerEnter");
            DestroyTriggerEnterDelay = serializedObject.FindProperty("DestroyTriggerEnterDelay");

            usingTriggerExit = serializedObject.FindProperty("usingTriggerExit");
            TriggerExitTag = serializedObject.FindProperty("TriggerExitTag");
            TriggerExitEvent = serializedObject.FindProperty("TriggerExitEvent");

            usingCollisionEnter = serializedObject.FindProperty("usingCollisionEnter");
            CollisionEnterTag = serializedObject.FindProperty("CollisionEnterTag");
            CollisionEnterEvent = serializedObject.FindProperty("CollisionEnterEvent");

            usingDestroyCollisionEnter = serializedObject.FindProperty("usingDestroyCollisionEnter");
            DestroyCollisionEnter = serializedObject.FindProperty("DestroyCollisionEnter");
            DestroyCollisionEnterDelay = serializedObject.FindProperty("DestroyCollisionEnterDelay");

            usingCollisionExit = serializedObject.FindProperty("usingCollisionExit");
            CollisionExitTag = serializedObject.FindProperty("CollisionExitTag");
            CollisionExitEvent = serializedObject.FindProperty("CollisionExitEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);
            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(CollisionType);

                EditorGUILayout.PropertyField(usingRigidbody3D);
                bool check2 = usingRigidbody3D.boolValue;
                usingRigidbody3D.boolValue = true;
                if (check2)
                {
                    EditorGUILayout.PropertyField(TargetRigidbody, true);
                    if (TargetRigidbody.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                if ((CollisionController.CCollisionType)CollisionType.enumValueIndex == CollisionController.CCollisionType.isTrigger)
                {
                    EditorGUILayout.PropertyField(usingTriggerEnter);
                    bool check3 = usingTriggerEnter.boolValue;

                    if (check3)
                    {
                        EditorGUILayout.PropertyField(TriggerEnterTag, true);
                        if (TriggerEnterTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(TriggerEnterEvent, true);

                        EditorGUILayout.PropertyField(usingDestroyTriggerEnter, true);
                        EditorGUILayout.PropertyField(DestroyTriggerEnter, true);
                        EditorGUILayout.PropertyField(DestroyTriggerEnterDelay, true);

                    }

                    EditorGUILayout.PropertyField(usingTriggerExit);
                    bool check4 = usingTriggerExit.boolValue;

                    if (check4)
                    {
                        EditorGUILayout.PropertyField(TriggerExitTag, true);
                        if (TriggerExitTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(TriggerExitEvent, true);
                    }
                }
                else if ((CollisionController.CCollisionType)CollisionType.enumValueIndex == CollisionController.CCollisionType.isCollision)
                {
                    EditorGUILayout.PropertyField(usingCollisionEnter);
                    bool check5 = usingCollisionEnter.boolValue;

                    if (check5)
                    {
                        EditorGUILayout.PropertyField(CollisionEnterTag, true);
                        if (CollisionEnterTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(CollisionEnterEvent, true);

                        EditorGUILayout.PropertyField(usingDestroyCollisionEnter, true);
                        EditorGUILayout.PropertyField(DestroyCollisionEnter, true);
                        EditorGUILayout.PropertyField(DestroyCollisionEnterDelay, true);

                    }

                    EditorGUILayout.PropertyField(usingCollisionExit);
                    bool check6 = usingCollisionExit.boolValue;

                    if (check6)
                    {
                        EditorGUILayout.PropertyField(CollisionExitTag, true);
                        if (CollisionExitTag.arraySize == 0)
                        {
                            EditorGUILayout.HelpBox("Array Tag(s) Null / None", MessageType.Error);
                        }

                        EditorGUILayout.PropertyField(CollisionExitEvent, true);
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