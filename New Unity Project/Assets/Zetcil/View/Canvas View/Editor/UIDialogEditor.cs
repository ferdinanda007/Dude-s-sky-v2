using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UIDialog)), CanEditMultipleObjects]
    public class UIDialogEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           DialogType,
           DialogAbout,
           usingAboutTestKey,
           AboutTestKey,
           DialogOption,
           usingOptionTestKey,
           OptionTestKey,
           DialogLogin,
           usingLoginTestKey,
           LoginTestKey,
           DialogLicense,
           usingLicenseTestKey,
           LicenseTestKey,
           DialogNotification,
           usingNotificationKey,
           NotificationTestKey,
           DialogInformation,
           usingInformationTestKey,
           InformationTestKey,
           DialogWarning,
           usingWarningTestKey,
           WarningTestKey,
           DialogError,
           usingErrorTestKey,
           ErrorTestKey,
           DialogConfirmation,
           usingConfirmationTestKey,
           ConfirmTestKey,
           DialogQuit,
           usingQuitSettings,
           QuitKey
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            DialogType = serializedObject.FindProperty("DialogType");
            DialogAbout = serializedObject.FindProperty("DialogAbout");
            usingAboutTestKey = serializedObject.FindProperty("usingAboutTestKey");
            AboutTestKey = serializedObject.FindProperty("AboutTestKey");
            DialogOption = serializedObject.FindProperty("DialogOption");
            usingOptionTestKey = serializedObject.FindProperty("usingOptionTestKey");
            OptionTestKey = serializedObject.FindProperty("OptionTestKey");
            DialogLogin = serializedObject.FindProperty("DialogLogin");
            usingLoginTestKey = serializedObject.FindProperty("usingLoginTestKey");
            LoginTestKey = serializedObject.FindProperty("LoginTestKey");
            DialogLicense = serializedObject.FindProperty("DialogLicense");
            usingLicenseTestKey = serializedObject.FindProperty("usingLicenseTestKey");
            LicenseTestKey = serializedObject.FindProperty("LicenseTestKey");
            DialogNotification = serializedObject.FindProperty("DialogNotification");
            usingNotificationKey = serializedObject.FindProperty("usingNotificationKey");
            NotificationTestKey = serializedObject.FindProperty("NotificationTestKey");
            DialogInformation = serializedObject.FindProperty("DialogInformation");
            usingInformationTestKey = serializedObject.FindProperty("usingInformationTestKey");
            InformationTestKey = serializedObject.FindProperty("InformationTestKey");
            DialogWarning = serializedObject.FindProperty("DialogWarning");
            usingWarningTestKey = serializedObject.FindProperty("usingWarningTestKey");
            WarningTestKey = serializedObject.FindProperty("WarningTestKey");
            DialogError = serializedObject.FindProperty("DialogError");
            usingErrorTestKey = serializedObject.FindProperty("usingErrorTestKey");
            ErrorTestKey = serializedObject.FindProperty("ErrorTestKey");
            DialogConfirmation = serializedObject.FindProperty("DialogConfirmation");
            usingConfirmationTestKey = serializedObject.FindProperty("usingConfirmationTestKey");
            ConfirmTestKey = serializedObject.FindProperty("ConfirmTestKey");
            DialogQuit = serializedObject.FindProperty("DialogQuit");
            usingQuitSettings = serializedObject.FindProperty("usingQuitSettings");
            QuitKey = serializedObject.FindProperty("QuitKey");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(DialogType, true);
                EditorGUILayout.PropertyField(DialogAbout, true);
                EditorGUILayout.PropertyField(usingAboutTestKey, true);
                EditorGUILayout.PropertyField(AboutTestKey, true);
                EditorGUILayout.PropertyField(DialogOption, true);
                EditorGUILayout.PropertyField(usingOptionTestKey, true);
                EditorGUILayout.PropertyField(OptionTestKey, true);
                EditorGUILayout.PropertyField(DialogLogin, true);
                EditorGUILayout.PropertyField(usingLoginTestKey, true);
                EditorGUILayout.PropertyField(LoginTestKey, true);
                EditorGUILayout.PropertyField(DialogLicense, true);
                EditorGUILayout.PropertyField(usingLicenseTestKey, true);
                EditorGUILayout.PropertyField(LicenseTestKey, true);
                EditorGUILayout.PropertyField(DialogNotification, true);
                EditorGUILayout.PropertyField(usingNotificationKey, true);
                EditorGUILayout.PropertyField(NotificationTestKey, true);
                EditorGUILayout.PropertyField(DialogInformation, true);
                EditorGUILayout.PropertyField(usingInformationTestKey, true);
                EditorGUILayout.PropertyField(InformationTestKey, true);
                EditorGUILayout.PropertyField(DialogWarning, true);
                EditorGUILayout.PropertyField(usingWarningTestKey, true);
                EditorGUILayout.PropertyField(WarningTestKey, true);
                EditorGUILayout.PropertyField(DialogError, true);
                EditorGUILayout.PropertyField(usingErrorTestKey, true);
                EditorGUILayout.PropertyField(ErrorTestKey, true);
                EditorGUILayout.PropertyField(DialogConfirmation, true);
                EditorGUILayout.PropertyField(usingConfirmationTestKey, true);
                EditorGUILayout.PropertyField(ConfirmTestKey, true);
                EditorGUILayout.PropertyField(DialogQuit, true);
                EditorGUILayout.PropertyField(usingQuitSettings, true);
                EditorGUILayout.PropertyField(QuitKey, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}