/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur perpindahan level
 **************************************************************************************************************/
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TechnomediaLabs;

namespace Zetcil
{

    public class SceneController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        public enum CLoadingType { ByEvent, ByClick, ByClickAndLoading, ByDelay, ByDelayAndLoading, ByCollision, ByCollisionAndLoading, ByKeyPress, ByKeyPressAndLoading }
        public enum CCollisionType { OnCollision, OnTrigger }

        [Header("Level Settings")]
        [ConditionalField("isEnabled")] public CLoadingType LoadingType;
        [ConditionalField("isEnabled")] public string NextSceneName;

        [Header("Delay Settings")]
        [ConditionalField("isEnabled")] public int WaitSecond = 10;
        [ConditionalField("isEnabled")] public bool WithLoadingScreen;
        [ConditionalField("isEnabled")] public int NextSceneIndex;

        [Header("Collision Settings")]
        [ConditionalField("isEnabled")] public CCollisionType CollisionType;
        [ConditionalField("isEnabled")] public string ObjectTag;

        [Header("Keypress Settings")]
        [SearchableEnum] public KeyCode KeyPress;

        [Header("Rigidbody Settings")]
        [ConditionalField("isEnabled")] public bool usingRigidbody2D;
        [ConditionalField("isEnabled")] public Rigidbody2D TargetRigidbody2D;
        [ConditionalField("isEnabled")] public bool usingRigidbody3D;
        [ConditionalField("isEnabled")] public Rigidbody TargetRigidbody3D;

        [Header("Variable Settings")]
        public bool usingVarString;
        public VarString VarScenename;

        public static string ZetLoadingScreen = "ZetLoadingScreen";

        // Use this for initialization
        void Start()
        {
            if (isEnabled)
            {
                if (usingVarString)
                {
                    NextSceneName = VarScenename.CurrentValue;
                    if (NextSceneName != "")
                    {
                        NextSceneIndex = SceneIndexFromName(NextSceneName);
                    }
                }

                if (LoadingType == CLoadingType.ByDelay)
                {
                    WithLoadingScreen = false;
                    Invoke("ExecGoToSceneByDelay", WaitSecond);
                }
                if (LoadingType == CLoadingType.ByDelayAndLoading)
                {
                    WithLoadingScreen = true;
                    Invoke("ExecGoToSceneByDelay", WaitSecond);
                }
                if (LoadingType == CLoadingType.ByClick)
                {
                    WithLoadingScreen = false;
                }
                if (LoadingType == CLoadingType.ByClickAndLoading)
                {
                    WithLoadingScreen = true;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (usingVarString)
            {
                NextSceneName = VarScenename.CurrentValue;
                if (NextSceneName != "")
                {
                    NextSceneIndex = SceneIndexFromName(NextSceneName);
                }
            }

            if (LoadingType == CLoadingType.ByKeyPress)
            {
                if (Input.GetKey(KeyPress))
                {
                    LoadSceneByEvent(NextSceneName);
                }
            }
            if (LoadingType == CLoadingType.ByKeyPressAndLoading)
            {
                if (Input.GetKey(KeyPress))
                {
                    LoadSceneByEventAndLoading(NextSceneName);
                }
            }
        }

        public void RestartScene()
        {
            if (isEnabled)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        public void LoadSceneByClick(VarString SceneName)
        {
            if (isEnabled)
            {
                SceneManager.LoadScene(SceneName.CurrentValue);
                Debug.Log("Save NextScene Index: " + SceneIndexFromName(SceneName.CurrentValue));
            }
        }

        public void LoadSceneByClick(string SceneName)
        {
            if (isEnabled)
            {
                SceneManager.LoadScene(SceneName);
                Debug.Log("Save NextScene Index: " + SceneIndexFromName(SceneName));
            }
        }

        public void LoadSceneByClickAndLoading(string SceneName)
        {
            if (isEnabled)
            {
                SaveLoadingName(SceneName);
                int SceneIndex = SceneIndexFromName(SceneName);
                //PlayerPrefs.SetInt(LoadingController.NextSceneIndex, SceneIndex);
                Debug.Log("Save NextScene Index: " + SceneIndex.ToString());
                LevelController.LoadScene(SceneIndex);
            }
        }

        public void LoadSceneByClickAndLoading(VarString SceneName)
        {
            if (isEnabled)
            {
                SaveLoadingName(SceneName.CurrentValue);
                int SceneIndex = SceneIndexFromName(SceneName.CurrentValue);
                //PlayerPrefs.SetInt(LoadingController.NextSceneIndex, SceneIndex);
                Debug.Log("Save NextScene Index: " + SceneIndex.ToString());
                LevelController.LoadScene(SceneIndex);
            }
        }

        string lastSceneName = "";
        int lastSceneIndex = 0;

        public void LoadSceneBy1Second(string SceneName)
        {
            if (isEnabled)
            {
                lastSceneName = SceneName;
                Invoke("InvokeLoadScene", 1);
            }
        }

        public void LoadSceneBy2Second(string SceneName)
        {
            if (isEnabled)
            {
                lastSceneName = SceneName;
                Invoke("InvokeLoadScene", 2);
            }
        }

        public void LoadSceneBy3Second(string SceneName)
        {
            if (isEnabled)
            {
                lastSceneName = SceneName;
                Invoke("InvokeLoadScene", 3);
            }
        }

        public void LoadSceneBy1SecondAndLoading(string SceneName)
        {
            if (isEnabled)
            {
                lastSceneName = SceneName;
                SaveLoadingName(SceneName);
                lastSceneIndex = SceneIndexFromName(SceneName);
                Invoke("InvokeLoadSceneLoading", 1);
            }
        }

        public void LoadSceneBy2SecondAndLoading(string SceneName)
        {
            if (isEnabled)
            {
                lastSceneName = SceneName;
                SaveLoadingName(SceneName);
                lastSceneIndex = SceneIndexFromName(SceneName);
                Invoke("InvokeLoadSceneLoading", 2);
            }
        }

        public void LoadSceneBy3SecondAndLoading(string SceneName)
        {
            if (isEnabled)
            {
                lastSceneName = SceneName;
                SaveLoadingName(SceneName);
                lastSceneIndex = SceneIndexFromName(SceneName);
                Invoke("InvokeLoadSceneLoading", 3);
            }
        }

        void InvokeLoadScene()
        {
            SceneManager.LoadScene(lastSceneName);
            Debug.Log("Save NextScene Index: " + SceneIndexFromName(lastSceneName));
        }

        void InvokeLoadSceneLoading()
        {
            Debug.Log("Save NextScene Index: " + lastSceneIndex.ToString());
            LevelController.LoadScene(lastSceneIndex);
        }

        public void LoadSceneByEvent(string SceneName)
        {
            if (isEnabled)
            {
                SceneManager.LoadScene(SceneName);
                Debug.Log("Save NextScene Index: " + SceneIndexFromName(SceneName));
            }
        }

        public void LoadSceneByEventAndLoading(string SceneName)
        {
            if (isEnabled)
            {
                SaveLoadingName(SceneName);
                int SceneIndex = SceneIndexFromName(SceneName);
                //PlayerPrefs.SetInt(LoadingController.NextSceneIndex, SceneIndex);
                Debug.Log("Save NextScene Index: " + SceneIndex.ToString());
                LevelController.LoadScene(SceneIndex);
            }
        }

        void ExecGoToSceneByDelay()
        {
            if (isEnabled)
            {
                if (WithLoadingScreen)
                {
                    LevelController.LoadScene(NextSceneIndex);
                }
                else
                {
                    SceneManager.LoadScene(NextSceneName);

                }
            }
        }

        void ExecGoToSceneByClick()
        {
            if (isEnabled)
            {
                if (WithLoadingScreen)
                {
                    LevelController.LoadScene(NextSceneIndex);
                }
                else
                {
                    SceneManager.LoadScene(NextSceneName);
                }
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (isEnabled)
            {
                if (LoadingType == CLoadingType.ByCollisionAndLoading)
                {
                    WithLoadingScreen = true;
                }

                if (LoadingType == CLoadingType.ByCollision || LoadingType == CLoadingType.ByCollisionAndLoading)
                {
                    if (CollisionType == CCollisionType.OnTrigger)
                    {
                        if (collider.gameObject.tag == ObjectTag)
                        {
                            if (WithLoadingScreen)
                            {
                                LevelController.LoadScene(NextSceneIndex);
                            }
                            else
                            {
                                SceneManager.LoadScene(NextSceneName);
                            }

                        }
                    }
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (isEnabled)
            {
                if (LoadingType == CLoadingType.ByCollisionAndLoading)
                {
                    WithLoadingScreen = true;
                }

                if (LoadingType == CLoadingType.ByCollision || LoadingType == CLoadingType.ByCollisionAndLoading)
                {
                    if (CollisionType == CCollisionType.OnCollision)
                    {
                        if (collision.gameObject.tag == ObjectTag)
                        {
                            if (WithLoadingScreen)
                            {
                                LevelController.LoadScene(NextSceneIndex);
                            }
                            else
                            {
                                SceneManager.LoadScene(NextSceneName);
                            }
                        }
                    }
                }
            }
        }

        public static string TempDirectory()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Temp/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Temp/");
            }
            return Application.persistentDataPath + "/Temp/";
        }

        public static void LoadScene(int scene_index)
        {
            SaveLoadingIndex(scene_index);
            //PlayerPrefs.SetInt(LoadingController.NextSceneIndex, scene_index);
            Debug.Log("Save NextScene Index: " + scene_index.ToString());
            SceneManager.LoadScene(ZetLoadingScreen);
        }

        private static string SceneNameFromIndex(int BuildIndex)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }

        private static int SceneIndexFromName(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string testedScreen = SceneNameFromIndex(i);
                //print("sceneIndexFromName: i: " + i + " sceneName = " + testedScreen);
                if (testedScreen == sceneName)
                    return i;
            }
            return -1;
        }

        public static void SaveLoadingIndex(int scene_index)
        {
            string scene_name = SceneNameFromIndex(scene_index);

            var sr = File.CreateText(TempDirectory() + "Loading.xml");
            sr.WriteLine("<DataCollection>");
            sr.WriteLine("<DataGroup>");

            sr.WriteLine("\t<SceneIndex>" + scene_index.ToString() + "</SceneIndex>");
            sr.WriteLine("\t<SceneName>" + scene_name.ToString() + "</SceneName>");

            sr.WriteLine("</DataGroup>");
            sr.WriteLine("</DataCollection>");
            sr.Close();
        }

        public static void SaveLoadingName(string scene_name)
        {
            int scene_index = SceneIndexFromName(scene_name);

            var sr = File.CreateText(TempDirectory() + "Loading.xml");
            sr.WriteLine("<DataCollection>");
            sr.WriteLine("<DataGroup>");

            sr.WriteLine("\t<SceneIndex>" + scene_index.ToString() + "</SceneIndex>");
            sr.WriteLine("\t<SceneName>" + scene_name.ToString() + "</SceneName>");

            sr.WriteLine("</DataGroup>");
            sr.WriteLine("</DataCollection>");
            sr.Close();
        }

    }

}