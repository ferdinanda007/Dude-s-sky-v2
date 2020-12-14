using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class TranslateController : MonoBehaviour
    {
        public enum COutputType { None, VarString, UIText, UITextMesh, InputField }
        
        [Space(10)]
        public bool isEnabled;

        [Header("Output Settings")]
        public COutputType OutputType;
        public VarString TargetVarString;
        public Text TargetUIText;
        public TextMesh TargetUITextMesh;
        public InputField TargetInputField;
        public string LanguageID;

        string FileName;
        string ConfigDirectory = "Config";
        string LanguageDirectory = "Languages";

        // Start is called before the first frame update
        void Start()
        {
            if (isEnabled)
            {
                LoadConfig();
                LoadLanguage();
            }
        }

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
                FileName = xmlnodelist.Item(0).InnerText.Trim() + ".xml";
            }
        }

        public void LoadLanguage()
        {
            string FullPathFile = GetDirectory(LanguageDirectory) + FileName;
            if (File.Exists(FullPathFile))
            {
                string tempxml = System.IO.File.ReadAllText(FullPathFile);

                XmlDocument xmldoc;
                XmlNodeList xmlnodelist;
                XmlNode xmlnode;
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);

                xmlnodelist = xmldoc.GetElementsByTagName(LanguageID);

                if (OutputType == COutputType.VarString)
                {
                    TargetVarString.CurrentValue = xmlnodelist.Item(0).InnerText.Trim();
                }
                else if (OutputType == COutputType.UIText)
                {
                    TargetUIText.text = xmlnodelist.Item(0).InnerText.Trim();
                }
                else if (OutputType == COutputType.UITextMesh)
                {
                    TargetUITextMesh.text = xmlnodelist.Item(0).InnerText.Trim();
                }
                else if (OutputType == COutputType.InputField)
                {
                    TargetInputField.text = xmlnodelist.Item(0).InnerText.Trim();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
