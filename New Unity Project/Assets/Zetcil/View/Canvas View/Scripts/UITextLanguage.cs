using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class UITextLanguage : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;
        [ConditionalField("isEnabled")] public string LanguageID;

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
                if (GetComponent<Text>())
                {
                    GetComponent<Text>().text = xmlnodelist.Item(0).InnerText.Trim();
                }
                else if (GetComponent<InputField>())
                {
                    GetComponent<InputField>().text = xmlnodelist.Item(0).InnerText.Trim();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
