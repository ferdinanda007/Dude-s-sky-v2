using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(NPCCollisionController)), CanEditMultipleObjects]
    public class NPCCollisionControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           usingRigidbody3D,
           TargetRigidbody,
           CollisionType,
           CanvasTalk,
           TalkType,
           TalkObject,
           KeyTalk,
           KeyObject,
           CamTalk,
           PlayerCamera,
           NPCCamera,
           CamObject,
           usingTriggerEnter,
           TriggerEnterTag,
           TalkOnEvent,
           KeyOnEvent,
           CamOnEvent,
           TriggerEnterEvent,
           usingTriggerExit,
           TriggerExitTag,
           TalkOffEvent,
           KeyOffEvent,
           CamOffEvent,
           TriggerExitEvent
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            usingRigidbody3D = serializedObject.FindProperty("usingRigidbody3D");
            TargetRigidbody = serializedObject.FindProperty("TargetRigidbody");
            CollisionType = serializedObject.FindProperty("CollisionType");
            CanvasTalk = serializedObject.FindProperty("CanvasTalk");
            TalkType = serializedObject.FindProperty("TalkType");
            TalkObject = serializedObject.FindProperty("TalkObject");
            KeyTalk = serializedObject.FindProperty("KeyTalk");
            KeyObject = serializedObject.FindProperty("KeyObject");
            CamTalk = serializedObject.FindProperty("CamTalk");
            PlayerCamera = serializedObject.FindProperty("PlayerCamera");
            NPCCamera = serializedObject.FindProperty("NPCCamera");
            CamObject = serializedObject.FindProperty("CamObject");
            usingTriggerEnter = serializedObject.FindProperty("usingTriggerEnter");
            TriggerEnterTag = serializedObject.FindProperty("TriggerEnterTag");
            TalkOnEvent = serializedObject.FindProperty("TalkOnEvent");
            KeyOnEvent = serializedObject.FindProperty("KeyOnEvent");
            CamOnEvent = serializedObject.FindProperty("CamOnEvent");
            TriggerEnterEvent = serializedObject.FindProperty("TriggerEnterEvent");
            usingTriggerExit = serializedObject.FindProperty("usingTriggerExit");
            TriggerExitTag = serializedObject.FindProperty("TriggerExitTag");
            TalkOffEvent = serializedObject.FindProperty("TalkOffEvent");
            KeyOffEvent = serializedObject.FindProperty("KeyOffEvent");
            CamOffEvent = serializedObject.FindProperty("CamOffEvent");
            TriggerExitEvent = serializedObject.FindProperty("TriggerExitEvent");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(usingRigidbody3D, true);
                if (usingRigidbody3D.boolValue)
                {
                    EditorGUILayout.PropertyField(TargetRigidbody, true);
                    if (TargetRigidbody.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }
                EditorGUILayout.PropertyField(CollisionType, true);
                EditorGUILayout.PropertyField(CanvasTalk, true);
                if (CanvasTalk.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(TalkObject, true);
                if (TalkObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(TalkType, true);
                if ((NPCCollisionController.CTalkType)TalkType.enumValueIndex == NPCCollisionController.CTalkType.Keytalk)
                {
                    EditorGUILayout.PropertyField(KeyTalk, true);
                    EditorGUILayout.PropertyField(KeyObject, true);
                    if (KeyObject.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }
                if ((NPCCollisionController.CTalkType)TalkType.enumValueIndex == NPCCollisionController.CTalkType.Camtalk)
                {
                    EditorGUILayout.PropertyField(PlayerCamera, true);
                    if (PlayerCamera.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                    EditorGUILayout.PropertyField(CamTalk, true);
                    EditorGUILayout.PropertyField(NPCCamera, true);
                    if (NPCCamera.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                    EditorGUILayout.PropertyField(CamObject, true);
                    if (CamObject.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                EditorGUILayout.PropertyField(usingTriggerEnter, true);
                if (usingTriggerEnter.boolValue)
                {
                    EditorGUILayout.PropertyField(TriggerEnterTag, true);
                    EditorGUILayout.PropertyField(TalkOnEvent, true);
                    EditorGUILayout.PropertyField(KeyOnEvent, true);
                    EditorGUILayout.PropertyField(CamOnEvent, true);
                    EditorGUILayout.PropertyField(TriggerEnterEvent, true);
                }
                EditorGUILayout.PropertyField(usingTriggerExit, true);
                if (usingTriggerExit.boolValue)
                {
                    EditorGUILayout.PropertyField(TriggerExitTag, true);
                    EditorGUILayout.PropertyField(TalkOffEvent, true);
                    EditorGUILayout.PropertyField(KeyOffEvent, true);
                    EditorGUILayout.PropertyField(CamOffEvent, true);
                    EditorGUILayout.PropertyField(TriggerExitEvent, true);
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