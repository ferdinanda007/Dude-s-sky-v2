using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Zetcil
{
    public class UIDialog : MonoBehaviour
    {
        public enum CDialogType { About, Option, Login, License, Notification, Information, Warning, Error, Confirmation, Quit }

        [Space(10)]
        public bool isEnabled;

        [System.Serializable]
        public class CAboutDialog
        {
            [Header("Main Settings")]
            public GameObject DialogGroup;

            [Header("Dialog Settings")]
            public GameObject DialogObject;

            [Header("Button Settings")]
            public CDialogButton ButtonOK;
        }

        [System.Serializable]
        public class COptionDialog
        {
            [Header("Main Settings")]
            public GameObject DialogGroup;

            [Header("Dialog Settings")]
            public GameObject DialogObject;

            [Header("Button Settings")]
            public CDialogButton ButtonOK;
        }

        [System.Serializable]
        public class CNotificationDialog
        {
            [Header("Main Settings")]
            public GameObject DialogGroup;

            [Header("Dialog Settings")]
            public GameObject DialogObject;
            public Text UIDialogTitle;
            public Text UIDialogText;
            public string DialogTitle;
            public string DialogText;

            [Header("Button Settings")]
            public CDialogButton CloseButton;
        }

        [System.Serializable]
        public class CDialogButton
        {
            public Button TargetButton;
            public string CaptionButton;
            public bool usingButtonEvent;
            public UnityEvent ButtonEvent;
        }

        [System.Serializable]
        public class CInputDialog
        {
            [Header("Main Settings")]
            public GameObject DialogGroup;

            [Header("Dialog Settings")]
            public GameObject DialogObject;
            public Text UIDialogTitle;
            public Text UIDialogText;
            public string DialogTitle;
            public string DialogText;

            [Header("Input Settings")]
            public InputField FieldText1;
            public InputField FieldText2;
            public InputField FieldText3;

            [Header("Button Settings")]
            public CDialogButton ButtonOK;
        }

        [System.Serializable]
        public class CSingleDialog
        {
            [Header("Main Settings")]
            public GameObject DialogGroup;

            [Header("Dialog Settings")]
            public GameObject DialogObject;
            public Text UIDialogTitle;
            public Text UIDialogText;
            public string DialogTitle;
            public string DialogText;

            [Header("Button Settings")]
            public CDialogButton ButtonOK;
        }

        [System.Serializable] 
        public class CDualDialog
        {
            [Header("Main Settings")]
            public GameObject DialogGroup;

            [Header("Dialog Settings")]
            public GameObject DialogObject;
            public Text UIDialogTitle;
            public Text UIDialogText;
            public string DialogTitle;
            public string DialogText;

            [Header("Buttons Settings")]
            public CDialogButton ButtonYes;
            public CDialogButton ButtonNo;
        }


        [Header("Main Dialog Settings")]
        public CDialogType DialogType;

        [Header("About Settings")]
        public CAboutDialog DialogAbout;
        public bool usingAboutTestKey;
        [SearchableEnum] public KeyCode AboutTestKey;

        [Header("Option Settings")]
        public COptionDialog DialogOption;
        public bool usingOptionTestKey;
        [SearchableEnum] public KeyCode OptionTestKey;

        [Header("Login Settings")]
        public List<CSingleDialog> DialogLogin;
        public bool usingLoginTestKey;
        [SearchableEnum] public KeyCode LoginTestKey;
        [Space(10)]

        [Header("License Settings")]
        public CInputDialog DialogLicense;
        public bool usingLicenseTestKey;
        [SearchableEnum] public KeyCode LicenseTestKey;
        [Space(10)]

        [Header("Notification Settings")]
        public List<CNotificationDialog> DialogNotification;
        public bool usingNotificationKey;
        [SearchableEnum] public KeyCode NotificationTestKey;
        [Space(10)]

        [Header("Information Settings")]
        public List<CSingleDialog> DialogInformation;
        public bool usingInformationTestKey;
        [SearchableEnum] public KeyCode InformationTestKey;
        [Space(10)]

        [Header("Warning Settings")]
        public List<CSingleDialog> DialogWarning;
        public bool usingWarningTestKey;
        [SearchableEnum] public KeyCode WarningTestKey;
        [Space(10)]

        [Header("Error Settings")]
        public List<CSingleDialog> DialogError;
        public bool usingErrorTestKey;
        [SearchableEnum] public KeyCode ErrorTestKey;
        [Space(10)]

        [Header("Confirmation Settings")]
        public List<CDualDialog> DialogConfirmation;
        public bool usingConfirmationTestKey;
        [SearchableEnum] public KeyCode ConfirmTestKey;
        [Space(10)]

        [Header("Quit Settings")]
        public CDualDialog DialogQuit;
        public bool usingQuitSettings;
        [SearchableEnum] public KeyCode QuitKey;
        [Space(10)]

        int CurrentIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            HideDialog();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(QuitKey) && usingQuitSettings)
            {
                PrepareDialogQuit();
                ShowDialog(0);
            }
            else if (Input.GetKey(ConfirmTestKey) && usingConfirmationTestKey)
            {
                PrepareDialogConfirmation();
                ShowDialog(0);
            }
            else if (Input.GetKey(ErrorTestKey) && usingErrorTestKey)
            {
                PrepareDialogError();
                ShowDialog(0);
            }
            else if (Input.GetKey(WarningTestKey) && usingWarningTestKey)
            {
                PrepareDialogWarning();
                ShowDialog(0);
            }
            else if (Input.GetKey(InformationTestKey) && usingInformationTestKey)
            {
                PrepareDialogInformation();
                ShowDialog(0);
            }
            else if (Input.GetKey(NotificationTestKey) && usingNotificationKey)
            {
                PrepareDialogNotification();
                ShowDialog(0);
            }
            else if (Input.GetKey(LoginTestKey) && usingLoginTestKey)
            {
                PrepareDialogLogin();
                ShowDialog(0);
            }
            else if (Input.GetKey(LicenseTestKey) && usingLicenseTestKey)
            {
                PrepareDialogLicense();
                ShowDialog(0);
            }
            else if (Input.GetKey(AboutTestKey) && usingAboutTestKey)
            {
                PrepareDialogAbout();
                ShowDialog(0);
            }
            else if (Input.GetKey(OptionTestKey) && usingOptionTestKey)
            {
                PrepareDialogOption();
                ShowDialog(0);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                DialogAbout.DialogGroup.SetActive(false);
                DialogAbout.DialogObject.SetActive(false);
                DialogLicense.DialogGroup.SetActive(false);
                DialogLicense.DialogObject.SetActive(false);
            }
        }

        public void PrepareDialogType(CDialogType aDialogType)
        {
            DialogType = aDialogType;
        }

        public void PrepareDialogOption()
        {
            PrepareDialogType(CDialogType.Option);
        }

        public void PrepareDialogLicense()
        {
            PrepareDialogType(CDialogType.License);
        }

        public void PrepareDialogAbout()
        {
            PrepareDialogType(CDialogType.About);
        }

        public void PrepareDialogQuit()
        {
            PrepareDialogType(CDialogType.Quit);
        }

        public void PrepareDialogError()
        {
            PrepareDialogType(CDialogType.Error);
        }

        public void PrepareDialogWarning()
        {
            PrepareDialogType(CDialogType.Warning);
        }

        public void PrepareDialogInformation()
        {
            PrepareDialogType(CDialogType.Information);
        }

        public void PrepareDialogConfirmation()
        {
            PrepareDialogType(CDialogType.Confirmation);
        }

        public void PrepareDialogLogin()
        {
            PrepareDialogType(CDialogType.Login);
        }

        public void PrepareDialogNotification()
        {
            PrepareDialogType(CDialogType.Notification);
        }

        public void ShowDialog(int aIndex)
        {
            CurrentIndex = 0;
            if (DialogType == CDialogType.Quit)
            {
                DialogQuit.UIDialogTitle.text = DialogQuit.DialogTitle;
                DialogQuit.UIDialogText.text = DialogQuit.DialogText;
                DialogQuit.ButtonYes.TargetButton.GetComponentInChildren<Text>().text = DialogQuit.ButtonYes.CaptionButton;
                DialogQuit.DialogGroup.SetActive(true);
                DialogQuit.DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Confirmation)
            {
                DialogConfirmation[aIndex].UIDialogTitle.text = DialogConfirmation[aIndex].DialogTitle;
                DialogConfirmation[aIndex].UIDialogText.text = DialogConfirmation[aIndex].DialogText;
                DialogConfirmation[aIndex].ButtonYes.TargetButton.GetComponentInChildren<Text>().text = DialogConfirmation[aIndex].ButtonYes.CaptionButton;
                DialogConfirmation[aIndex].ButtonNo.TargetButton.GetComponentInChildren<Text>().text = DialogConfirmation[aIndex].ButtonNo.CaptionButton;
                DialogConfirmation[aIndex].DialogGroup.SetActive(true);
                DialogConfirmation[aIndex].DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Error)
            {
                DialogError[aIndex].UIDialogTitle.text = DialogError[aIndex].DialogTitle;
                DialogError[aIndex].UIDialogText.text = DialogError[aIndex].DialogText;
                DialogError[aIndex].ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogError[aIndex].ButtonOK.CaptionButton;
                DialogError[aIndex].DialogGroup.SetActive(true);
                DialogError[aIndex].DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Warning)
            {
                DialogWarning[aIndex].UIDialogTitle.text = DialogWarning[aIndex].DialogTitle;
                DialogWarning[aIndex].UIDialogText.text = DialogWarning[aIndex].DialogText;
                DialogWarning[aIndex].ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogWarning[aIndex].ButtonOK.CaptionButton;
                DialogWarning[aIndex].DialogGroup.SetActive(true);
                DialogWarning[aIndex].DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Information)
            {
                DialogInformation[aIndex].UIDialogTitle.text = DialogInformation[aIndex].DialogTitle;
                DialogInformation[aIndex].UIDialogText.text = DialogInformation[aIndex].DialogText;
                DialogInformation[aIndex].ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogInformation[aIndex].ButtonOK.CaptionButton;
                DialogInformation[aIndex].DialogGroup.SetActive(true);
                DialogInformation[aIndex].DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Notification)
            {
                DialogNotification[aIndex].UIDialogTitle.text = DialogInformation[aIndex].DialogTitle;
                DialogNotification[aIndex].UIDialogText.text = DialogInformation[aIndex].DialogText;
                DialogNotification[aIndex].CloseButton.TargetButton.GetComponentInChildren<Text>().text = DialogNotification[aIndex].CloseButton.CaptionButton;
                DialogNotification[aIndex].DialogGroup.SetActive(true);
                DialogNotification[aIndex].DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Login)
            {
                DialogLogin[aIndex].UIDialogTitle.text = DialogLogin[aIndex].DialogTitle;
                DialogLogin[aIndex].UIDialogText.text = DialogLogin[aIndex].DialogText;
                DialogLogin[aIndex].ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogLogin[aIndex].ButtonOK.CaptionButton;
                DialogLogin[aIndex].DialogGroup.SetActive(true);
                DialogLogin[aIndex].DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.License)
            {
                DialogLicense.UIDialogTitle.text = DialogLicense.DialogTitle;
                DialogLicense.UIDialogText.text = DialogLicense.DialogText;
                DialogLicense.ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogLicense.ButtonOK.CaptionButton;
                DialogLicense.DialogGroup.SetActive(true);
                DialogLicense.DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.About)
            {
                DialogAbout.ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogAbout.ButtonOK.CaptionButton;
                DialogAbout.DialogGroup.SetActive(true);
                DialogAbout.DialogObject.SetActive(true);
            }
            if (DialogType == CDialogType.Option)
            {
                DialogOption.ButtonOK.TargetButton.GetComponentInChildren<Text>().text = DialogOption.ButtonOK.CaptionButton;
                DialogOption.DialogGroup.SetActive(true);
                DialogOption.DialogObject.SetActive(true);
            }
        }
        public void HideDialog()
        {
            if (DialogType == CDialogType.Quit)
            {
                DialogQuit.DialogGroup.SetActive(false);
                DialogQuit.DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Confirmation)
            {
                DialogConfirmation[CurrentIndex].DialogGroup.SetActive(false);
                DialogConfirmation[CurrentIndex].DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Error)
            {
                DialogError[CurrentIndex].DialogGroup.SetActive(false);
                DialogError[CurrentIndex].DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Warning)
            {
                DialogWarning[CurrentIndex].DialogGroup.SetActive(false);
                DialogWarning[CurrentIndex].DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Information)
            {
                DialogInformation[CurrentIndex].DialogGroup.SetActive(false);
                DialogInformation[CurrentIndex].DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Notification)
            {
                DialogNotification[CurrentIndex].DialogGroup.SetActive(false);
                DialogNotification[CurrentIndex].DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Login)
            {
                DialogLogin[CurrentIndex].DialogGroup.SetActive(false);
                DialogLogin[CurrentIndex].DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.License)
            {
                DialogLicense.DialogGroup.SetActive(false);
                DialogLicense.DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.About)
            {
                 DialogAbout.DialogGroup.SetActive(false);
                 DialogAbout.DialogObject.SetActive(false);
            }
            if (DialogType == CDialogType.Option)
            {
                DialogOption.DialogGroup.SetActive(false);
                DialogOption.DialogObject.SetActive(false);
            }
        }
        public void ExecuteOKEvent()
        {
            if (DialogType == CDialogType.Error)
            {
                DialogError[CurrentIndex].ButtonOK.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Warning)
            {
                DialogWarning[CurrentIndex].ButtonOK.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Information)
            {
                DialogInformation[CurrentIndex].ButtonOK.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Notification)
            {
                DialogNotification[CurrentIndex].CloseButton.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Login)
            {
                DialogLogin[CurrentIndex].ButtonOK.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.License)
            {
                DialogLicense.ButtonOK.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.About)
            {
                DialogAbout.ButtonOK.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Option)
            {
                DialogOption.ButtonOK.ButtonEvent.Invoke();
            }
        }
        public void ExecuteYesEvent()
        {
            if (DialogType == CDialogType.Quit)
            {
                DialogQuit.ButtonYes.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Confirmation)
            {
                DialogConfirmation[CurrentIndex].ButtonYes.ButtonEvent.Invoke();
            }
        }
        public void ExecuteNoEvent()
        {
            if (DialogType == CDialogType.Quit)
            {
                DialogQuit.ButtonNo.ButtonEvent.Invoke();
            }
            if (DialogType == CDialogType.Confirmation)
            {
                DialogConfirmation[CurrentIndex].ButtonNo.ButtonEvent.Invoke();
            }
        }

        public void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            Debug.Log("Application Quit Execute");
        }

        public void LicenseGenerateMachineID()
        {
            DialogLicense.FieldText1.text = SystemInfo.deviceName;
            DialogLicense.FieldText2.text = SystemInfo.deviceUniqueIdentifier;
        }
    }
}
