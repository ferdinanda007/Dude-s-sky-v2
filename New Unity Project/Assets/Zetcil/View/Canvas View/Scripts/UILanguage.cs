using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{

    public class UILanguage : MonoBehaviour
    {
        public enum CLanguageType { Indonesian, English, Arabic, Korean, Japanese, Chinese }

        [Space(10)]
        public bool isEnabled;
        public CLanguageType LanguageType;
        string CurrentLanguage;

        [Header("Flag Settings")]
        public GameObject IndonesianFlag;
        public GameObject EnglishFlag;
        public GameObject ArabicFlag;
        public GameObject KoreanFlag;
        public GameObject JapaneseFlag;
        public GameObject ChineseFlag;

        [Header("Operation Settings")]
        public GameObject IndonesianGameObject;
        public GameObject EnglishGameObject;
        public GameObject ArabicGameObject;
        public GameObject KoreanGameObject;
        public GameObject JapaneseGameObject;
        public GameObject ChineseGameObject;

        string ConfigDirectory = "Config";

        string GetDirectory(string aDirectoryName)
        {
            if (!Directory.Exists(Application.persistentDataPath + "/" + aDirectoryName + "/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + aDirectoryName + "/");
            }
            return Application.persistentDataPath + "/" + aDirectoryName + "/";
        }

        public void LoadConfig()
        {
            string FullPathFile = GetDirectory(ConfigDirectory) + "Language.xml";
            if (File.Exists(FullPathFile))
            {
                string tempxml = System.IO.File.ReadAllText(FullPathFile);

                XmlDocument xmldoc;
                XmlNodeList xmlnodelist;
                XmlNode xmlnode;
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);

                xmlnodelist = xmldoc.GetElementsByTagName("Language");
                CurrentLanguage = xmlnodelist.Item(0).InnerText.Trim();
            }
        }

        void LoadCurrentLanguage(string aLanguage)
        {
            if (aLanguage == "ARABIC") LanguageType = CLanguageType.Arabic;
            if (aLanguage == "INDONESIAN") LanguageType = CLanguageType.Indonesian;
            if (aLanguage == "ENGLISH") LanguageType = CLanguageType.English;
            if (aLanguage == "KOREAN") LanguageType = CLanguageType.Korean;
            if (aLanguage == "JAPANESE") LanguageType = CLanguageType.Japanese;
            if (aLanguage == "CHINESE") LanguageType = CLanguageType.Chinese;

            IndonesianFlag.SetActive(false);
            EnglishFlag.SetActive(false);
            ArabicFlag.SetActive(false);
            KoreanFlag.SetActive(false);
            JapaneseFlag.SetActive(false);
            ChineseFlag.SetActive(false);

            IndonesianGameObject.SetActive(false);
            EnglishGameObject.SetActive(false);
            ArabicGameObject.SetActive(false);
            KoreanGameObject.SetActive(false);
            JapaneseGameObject.SetActive(false);
            ChineseGameObject.SetActive(false);

            if (LanguageType == CLanguageType.Indonesian)
            {
                IndonesianGameObject.SetActive(true);
            }
            if (LanguageType == CLanguageType.English)
            {
                EnglishGameObject.SetActive(true);
            }
            if (LanguageType == CLanguageType.Arabic)
            {
                ArabicGameObject.SetActive(true);
            }
            if (LanguageType == CLanguageType.Korean)
            {
                KoreanGameObject.SetActive(true);
            }
            if (LanguageType == CLanguageType.Japanese)
            {
                JapaneseGameObject.SetActive(true);
            }
            if (LanguageType == CLanguageType.Chinese)
            {
                ChineseGameObject.SetActive(true);
            }

        }

        // Start is called before the first frame update
        void Start()
        {
            LoadConfig();
            LoadCurrentLanguage(CurrentLanguage);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
