using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.Events;

namespace Zetcil
{

    public class VarLanguage : MonoBehaviour
    {
        public enum COperationType { None, Initialize, Runtime }
        public enum CLanguageType { Indonesian, English, Arabic, Korean, Japanese, Chinese }

        [Space(10)]
        public bool isEnabled;

        [Header("Operation Settings")]
        public COperationType OperationType;

        [Header("Language Settings")]
        public CLanguageType LanguageType;

        [Header("Arabic Settings")]
        public bool usingArabic;
        public UnityEvent ArabicEvent;

        [Header("Indonesian Settings")]
        public bool usingIndonesia;
        public UnityEvent IndonesiaEvent;

        [Header("English Settings")]
        public bool usingEnglish;
        public UnityEvent EnglishEvent;

        [Header("Japanese Settings")]
        public bool usingJapanese;
        public UnityEvent JapaneseEvent;

        [Header("Korean Settings")]
        public bool usingKorean;
        public UnityEvent KoreanEvent;

        [Header("Chinese Settings")]
        public bool usingChinese;
        public UnityEvent ChineseEvent;

        string ConfigDirectory = "Config";
        string LanguageDirectory = "Languages";
        string CornerDirectory = "Corner";

        string LanguageFilename; 

        TextAsset languageAsset;

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
                LanguageFilename = xmlnodelist.Item(0).InnerText.Trim() + ".xml";
            }
        }

        public string GetLanguageDialog(string DialogID)
        {
            LoadConfig();

            string result = "";
            string FullPathFile = GetDirectory(LanguageDirectory) + LanguageFilename;

            if (File.Exists(FullPathFile))
            {
                string tempxml = System.IO.File.ReadAllText(FullPathFile);

                XmlDocument xmldoc;
                XmlNodeList xmlnodelist;
                XmlNode xmlnode;
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);

                xmlnodelist = xmldoc.GetElementsByTagName(DialogID);
                result = xmlnodelist.Item(0).InnerText.Trim();
            }

            return result;
        }

        public string GetCornerDialog(string DialogID)
        {
            LoadConfig();

            string result = "";
            string FullPathFile = GetDirectory(CornerDirectory) + LanguageFilename;

            if (File.Exists(FullPathFile))
            {
                string tempxml = System.IO.File.ReadAllText(FullPathFile);

                XmlDocument xmldoc;
                XmlNodeList xmlnodelist;
                XmlNode xmlnode;
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);

                xmlnodelist = xmldoc.GetElementsByTagName(DialogID);
                result = xmlnodelist.Item(0).InnerText.Trim();
            }

            return result;
        }

        // Start is called before the first frame update
        void Awake()
        {
            if (isEnabled)
            {
                if (OperationType == COperationType.Initialize)
                {
                    SaveFile();
                    InitializeLanguage();
                }
                if (OperationType == COperationType.Runtime)
                {
                    LoadFile();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public CLanguageType GetLanguageType()
        {
            return LanguageType;
        }

        public void SetArabicLanguage()
        {
            LanguageType = CLanguageType.Arabic;
            SaveFile();
        }

        public void SetIndonesiaLanguage()
        {
            LanguageType = CLanguageType.Indonesian;
            SaveFile();
        }

        public void SetEnglishLanguage()
        {
            LanguageType = CLanguageType.English;
            SaveFile();
        }

        public void SetJapaneseLanguage()
        {
            LanguageType = CLanguageType.Japanese;
            SaveFile();
        }

        public void SetKoreanLanguage()
        {
            LanguageType = CLanguageType.Korean;
            SaveFile();
        }

        public void SetChineseLanguage()
        {
            LanguageType = CLanguageType.Chinese;
            SaveFile();
        }

        void LoadCurrentLanguage(string aLanguage)
        {
            if (aLanguage == "ARABIC") LanguageType = CLanguageType.Arabic;
            if (aLanguage == "INDONESIAN") LanguageType = CLanguageType.Indonesian;
            if (aLanguage == "ENGLISH") LanguageType = CLanguageType.English;
            if (aLanguage == "KOREAN") LanguageType = CLanguageType.Korean;
            if (aLanguage == "JAPANESE") LanguageType = CLanguageType.Japanese;
            if (aLanguage == "CHINESE") LanguageType = CLanguageType.Chinese;

            if (usingArabic) ArabicEvent.Invoke();
            if (usingIndonesia) IndonesiaEvent.Invoke();
            if (usingEnglish) EnglishEvent.Invoke();
            if (usingKorean) KoreanEvent.Invoke();
            if (usingJapanese) JapaneseEvent.Invoke();
            if (usingChinese) ChineseEvent.Invoke();
        }
        string SaveCurrentLanguage()
        {
            string result = "";
            if (LanguageType == CLanguageType.Arabic) result = "ARABIC";
            if (LanguageType == CLanguageType.Indonesian) result = "INDONESIAN";
            if (LanguageType == CLanguageType.English) result = "ENGLISH";
            if (LanguageType == CLanguageType.Korean) result = "KOREAN";
            if (LanguageType == CLanguageType.Japanese) result = "JAPANESE";
            if (LanguageType == CLanguageType.Chinese) result = "CHINESE";
            return result;
        }

        string GetDirectory(string aDirectoryName)
        {
            if (!Directory.Exists(Application.persistentDataPath + "/" + aDirectoryName + "/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + aDirectoryName + "/");
            }
            return Application.persistentDataPath + "/" + aDirectoryName + "/";
        }

        public void InitializeLanguage()
        {
            languageAsset = (TextAsset)Resources.Load(LanguageDirectory + "/English", typeof(TextAsset));
            SaveLanguageFile("English", languageAsset.ToString());

            languageAsset = (TextAsset)Resources.Load(LanguageDirectory + "/Indonesian", typeof(TextAsset));
            SaveLanguageFile("Indonesian", languageAsset.ToString());

            languageAsset = (TextAsset)Resources.Load(LanguageDirectory + "/Arabic", typeof(TextAsset));
            SaveLanguageFile("Arabic", languageAsset.ToString());

            languageAsset = (TextAsset)Resources.Load(LanguageDirectory + "/Korean", typeof(TextAsset));
            SaveLanguageFile("Korean", languageAsset.ToString());

            languageAsset = (TextAsset)Resources.Load(LanguageDirectory + "/Japanese", typeof(TextAsset));
            SaveLanguageFile("Japanese", languageAsset.ToString());

            languageAsset = (TextAsset)Resources.Load(LanguageDirectory+"/Chinese", typeof(TextAsset));
            SaveLanguageFile("Chinese", languageAsset.ToString());
        }

        public void SaveLanguageFile(string aLanguageID, string aLanguageData)
        {
            string DirName = GetDirectory(LanguageDirectory);
            var sr = File.CreateText(DirName + aLanguageID + ".xml");
            sr.WriteLine(aLanguageData);
            sr.Close();
        }

        public void SaveFile()
        {
            string header = "<LanguageSettings>\n";
            string footer = "</LanguageSettings>";
            string result = "";

            string opentag = "\t<" + "Language" + " Version=\"1.00\" >\n";
            string contenttag = "\t\t" + SaveCurrentLanguage() + "\n";
            string closetag = "\t</" + "Language" + ">\n";

            result = opentag + contenttag + closetag;
            result = header + result + footer;

            string DirName = GetDirectory(ConfigDirectory);
            var sr = File.CreateText(DirName + "Language.xml");
            sr.WriteLine(result);
            sr.Close();
        }

        public void LoadFile()
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
                LoadCurrentLanguage(xmlnodelist.Item(0).InnerText.Trim());
            }
        }
    }
}
