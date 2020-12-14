using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml;

namespace Zetcil
{
    public class LoadingController : MonoBehaviour
    {

        public static string NextSceneIndex = "NextSceneIndex";
        static int scene_index;
        Slider loadbar;

        public Slider LoadingBar;

        [Header("Force Settings")]
        public bool enabledForceLoad;

        public static string LoadingDirectory()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Loading/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Loading/");
            }
            return Application.persistentDataPath + "/Loading/";
        }

        public static void LoadXML()
        {
            string xmlfile = LoadingDirectory() + "Loading.xml";
            if (File.Exists(xmlfile))
            {
                string xmlfile_result = System.IO.File.ReadAllText(xmlfile);

                XmlDocument xmldoc;
                XmlNodeList xmlnodelist;
                XmlNode xmlnode;
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(xmlfile_result);

                xmlnodelist = xmldoc.GetElementsByTagName("DataGroup");
                xmlnode = xmlnodelist.Item(0);
                XmlNode currentNode = xmlnode.FirstChild;
                scene_index = int.Parse(currentNode.InnerText);
            }
        }

        // Use this for initialization
        void Start()
        {
            Invoke("LoadingScreen", 1);
        }

        void LoadingScreen()
        {
            //scene_index = PlayerPrefs.GetInt(LoadingController.NextSceneIndex);
            LoadXML();
            if (scene_index != 0)
            {
                StartCoroutine(LoadNewScene());
                Debug.Log("Execute: Start CoRoutine");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (enabledForceLoad)
            {
                if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Mouse0))
                {
                    ForceLoadNewScene();
                }
            }
        }

        void ForceLoadNewScene()
        {
            SceneManager.LoadScene(scene_index);
        }

        IEnumerator LoadNewScene()
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(scene_index);
            Debug.Log("Async: " + async.isDone.ToString());

            while (!async.isDone)
            {
                LoadingBar.value = ((async.progress / 0.9f) * 100);
                Debug.Log("Async: " + async.progress.ToString());
                yield return null;
            }

        }

    }
}