using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FindController)), CanEditMultipleObjects]
    public class FindControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           InvokeType,
           usingObjectName,
           FindingObjectName,
           TargetNameObject,
           usingObjectTag,
           FindingObjectTag,
           usingSetActive,
           ActiveStatus,
           usingCamera,
           CameraStatus,
           usingAudio,
           AudioStatus,
           usingVideo,
           VideoStatus,
           usingSetDestroy,
           DestroyStatus,
           usingTrueEvent,
           TrueEvent,
           usingFalseEvent,
           FalseEvent,
            //--Invoke type (1)
            usingDelay,
            Delay,
            usingInterval,
            Interval
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            InvokeType = serializedObject.FindProperty("InvokeType");
            usingObjectName = serializedObject.FindProperty("usingObjectName");
            FindingObjectName = serializedObject.FindProperty("FindingObjectName");
            TargetNameObject = serializedObject.FindProperty("TargetNameObject");
            usingObjectTag = serializedObject.FindProperty("usingObjectTag");
            FindingObjectTag = serializedObject.FindProperty("FindingObjectTag");
            usingSetActive = serializedObject.FindProperty("usingSetActive");
            ActiveStatus = serializedObject.FindProperty("ActiveStatus");
            usingSetDestroy = serializedObject.FindProperty("usingSetDestroy");
            DestroyStatus = serializedObject.FindProperty("DestroyStatus");
            usingTrueEvent = serializedObject.FindProperty("usingTrueEvent");
            TrueEvent = serializedObject.FindProperty("TrueEvent");
            usingFalseEvent = serializedObject.FindProperty("usingFalseEvent");
            FalseEvent = serializedObject.FindProperty("FalseEvent");

            usingCamera = serializedObject.FindProperty("usingCamera");
            CameraStatus = serializedObject.FindProperty("CameraStatus");
            usingVideo = serializedObject.FindProperty("usingVideo");
            VideoStatus = serializedObject.FindProperty("VideoStatus");
            usingAudio = serializedObject.FindProperty("usingAudio");
            AudioStatus = serializedObject.FindProperty("AudioStatus");

            //--Invoke type (2)
            usingDelay = serializedObject.FindProperty("usingDelay");
            Delay = serializedObject.FindProperty("Delay");
            usingInterval = serializedObject.FindProperty("usingInterval");
            Interval = serializedObject.FindProperty("Interval");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(InvokeType, true);
                EditorGUILayout.PropertyField(TargetNameObject, true);
                if (TargetNameObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(usingObjectName, true);
                if (usingObjectName.boolValue)
                {
                    EditorGUILayout.PropertyField(FindingObjectName, true);
                }

                EditorGUILayout.PropertyField(usingObjectTag, true);
                if (usingObjectTag.boolValue)
                {
                    EditorGUILayout.PropertyField(FindingObjectTag, true);
                }
                EditorGUILayout.PropertyField(usingSetActive, true);
                if (usingSetActive.boolValue)
                {
                    EditorGUILayout.PropertyField(ActiveStatus, true);
                }
                EditorGUILayout.PropertyField(usingCamera, true);
                if (usingCamera.boolValue)
                {
                    EditorGUILayout.PropertyField(CameraStatus, true);
                }
                EditorGUILayout.PropertyField(usingVideo, true);
                if (usingVideo.boolValue)
                {
                    EditorGUILayout.PropertyField(VideoStatus, true);
                }
                EditorGUILayout.PropertyField(usingAudio, true);
                if (usingAudio.boolValue)
                {
                    EditorGUILayout.PropertyField(AudioStatus, true);
                }
                EditorGUILayout.PropertyField(usingSetDestroy, true);
                if (usingSetDestroy.boolValue)
                {
                    EditorGUILayout.PropertyField(DestroyStatus, true);
                }
                EditorGUILayout.PropertyField(usingTrueEvent, true);
                if (usingTrueEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(TrueEvent, true);
                }
                EditorGUILayout.PropertyField(usingFalseEvent, true);
                if (usingFalseEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(FalseEvent, true);
                }

                //--Invoke type (3)
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnDelay)
                {
                    EditorGUILayout.PropertyField(usingDelay, true);
                    if (usingDelay.boolValue)
                    {
                        EditorGUILayout.PropertyField(Delay, true);
                    }
                }
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnInterval)
                {
                    EditorGUILayout.PropertyField(usingInterval, true);
                    if (usingInterval.boolValue)
                    {
                        EditorGUILayout.PropertyField(Interval, true);
                        Interval.floatValue = 1;
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