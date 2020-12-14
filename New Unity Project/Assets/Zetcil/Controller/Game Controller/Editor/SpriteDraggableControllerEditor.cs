using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SpriteDraggableController)), CanEditMultipleObjects]
    public class SpriteDraggableControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CollisionType,
           DragDirection,
           MainCamera,
           usingLockPosition,
           BeginPosition,
           SnapEndPosition,
           usingBeginDrag,
           BeginDragEvent,
           usingDrag,
           DragEvent,
           usingEndDrag,
           EndDragEvent,

           usingTriggerEnter,
           TriggerEnterTag,
           TriggerEnterEvent,
           usingTriggerStay,
           TriggerStayTag,
           TriggerStayEvent,
           usingTriggerExit,
           TriggerExitTag,
           TriggerExitEvent,

           usingCollisionEnter,
           CollisionEnterTag,
           CollisionEnterEvent,
           usingCollisionStay,
           CollisionStayTag,
           CollisionStayEvent,
           usingCollisionExit,
           CollisionExitTag,
           CollisionExitEvent
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CollisionType = serializedObject.FindProperty("CollisionType");
            DragDirection = serializedObject.FindProperty("DragDirection");
            MainCamera = serializedObject.FindProperty("MainCamera");
            usingLockPosition = serializedObject.FindProperty("usingLockPosition");
            BeginPosition = serializedObject.FindProperty("BeginPosition");
            SnapEndPosition = serializedObject.FindProperty("SnapEndPosition");
            usingBeginDrag = serializedObject.FindProperty("usingBeginDrag");
            BeginDragEvent = serializedObject.FindProperty("BeginDragEvent");
            usingDrag = serializedObject.FindProperty("usingDrag");
            DragEvent = serializedObject.FindProperty("DragEvent");
            usingEndDrag = serializedObject.FindProperty("usingEndDrag");
            EndDragEvent = serializedObject.FindProperty("EndDragEvent");
            
            usingTriggerEnter = serializedObject.FindProperty("usingTriggerEnter");
            TriggerEnterTag = serializedObject.FindProperty("TriggerEnterTag");
            TriggerEnterEvent = serializedObject.FindProperty("TriggerEnterEvent");
            usingTriggerStay = serializedObject.FindProperty("usingTriggerStay");
            TriggerStayTag = serializedObject.FindProperty("TriggerStayTag");
            TriggerStayEvent = serializedObject.FindProperty("TriggerStayEvent");
            usingTriggerExit = serializedObject.FindProperty("usingTriggerExit");
            TriggerExitTag = serializedObject.FindProperty("TriggerExitTag");
            TriggerExitEvent = serializedObject.FindProperty("TriggerExitEvent");
            
            usingCollisionEnter = serializedObject.FindProperty("usingCollisionEnter");
            CollisionEnterTag = serializedObject.FindProperty("CollisionEnterTag");
            CollisionEnterEvent = serializedObject.FindProperty("CollisionEnterEvent");
            usingCollisionStay = serializedObject.FindProperty("usingCollisionStay");
            CollisionStayTag = serializedObject.FindProperty("CollisionStayTag");
            CollisionStayEvent = serializedObject.FindProperty("CollisionStayEvent");
            usingCollisionExit = serializedObject.FindProperty("usingCollisionExit");
            CollisionExitTag = serializedObject.FindProperty("CollisionExitTag");
            CollisionExitEvent = serializedObject.FindProperty("CollisionExitEvent");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(CollisionType, true);
                EditorGUILayout.PropertyField(DragDirection, true);
                EditorGUILayout.PropertyField(MainCamera, true);
                if (MainCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(usingLockPosition, true);
                if (usingLockPosition.boolValue)
                {
                    EditorGUILayout.PropertyField(BeginPosition, true);
                    EditorGUILayout.PropertyField(SnapEndPosition, true);
                }
                if ((SpriteDraggableController.CCollisionType)CollisionType.enumValueIndex == SpriteDraggableController.CCollisionType.isTrigger)
                {
                    EditorGUILayout.PropertyField(usingTriggerEnter, true);
                    if (usingTriggerEnter.boolValue)
                    {
                        EditorGUILayout.PropertyField(TriggerEnterTag, true);
                        EditorGUILayout.PropertyField(TriggerEnterEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingTriggerStay, true);
                    if (usingTriggerStay.boolValue)
                    {
                        EditorGUILayout.PropertyField(TriggerStayTag, true);
                        EditorGUILayout.PropertyField(TriggerStayEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingTriggerExit, true);
                    if (usingTriggerExit.boolValue)
                    {
                        EditorGUILayout.PropertyField(TriggerExitTag, true);
                        EditorGUILayout.PropertyField(TriggerExitEvent, true);
                    }
                }
                else if ((SpriteDraggableController.CCollisionType)CollisionType.enumValueIndex == SpriteDraggableController.CCollisionType.isCollision)
                {
                    EditorGUILayout.PropertyField(usingCollisionEnter, true);
                    if (usingCollisionEnter.boolValue)
                    {
                        EditorGUILayout.PropertyField(CollisionEnterTag, true);
                        EditorGUILayout.PropertyField(CollisionEnterEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingCollisionStay, true);
                    if (usingCollisionStay.boolValue)
                    {
                        EditorGUILayout.PropertyField(CollisionStayTag, true);
                        EditorGUILayout.PropertyField(CollisionStayEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingCollisionExit, true);
                    if (usingCollisionExit.boolValue)
                    {
                        EditorGUILayout.PropertyField(CollisionExitTag, true);
                        EditorGUILayout.PropertyField(CollisionExitEvent, true);
                    }
                }

                EditorGUILayout.PropertyField(usingBeginDrag, true);
                if (usingBeginDrag.boolValue)
                {
                    EditorGUILayout.PropertyField(BeginDragEvent, true);
                }
                EditorGUILayout.PropertyField(usingDrag, true);
                if (usingDrag.boolValue)
                {
                    EditorGUILayout.PropertyField(DragEvent, true);
                }
                EditorGUILayout.PropertyField(usingEndDrag, true);
                if (usingEndDrag.boolValue)
                {
                    EditorGUILayout.PropertyField(EndDragEvent, true);
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