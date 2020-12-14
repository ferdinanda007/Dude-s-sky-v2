using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{

    public class FindController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;
        
        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Target Object Settings")]
        [Separator]
        public VarObject TargetNameObject;

        [Header("GameObject Name Settings")]
        public bool usingObjectName;
        public string[] FindingObjectName;

        [Header("GameObject Tag Settings")]
        public bool usingObjectTag;
        [Tag] public string[] FindingObjectTag;
        GameObject[] findingObjectTag;

        [Header("Active Setting")]
        public bool usingSetActive;
        public bool ActiveStatus;

        [Header("Camera Setting")]
        public bool usingCamera;
        public bool CameraStatus;

        [Header("Video Setting")]
        public bool usingVideo;
        public bool VideoStatus;

        [Header("Audio Setting")]
        public bool usingAudio;
        public bool AudioStatus;

        [Header("Destroy Setting")]
        public bool usingSetDestroy;
        public bool DestroyStatus;

        [Header("True Event Settings")]
        [Separator]
        public bool usingTrueEvent;
        public UnityEvent TrueEvent;

        [Header("False Event Settings")]
        public bool usingFalseEvent;
        public UnityEvent FalseEvent;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        // Start is called before the first frame update
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeFindController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeFindController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeFindController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingDelay)
                    {
                        InvokeRepeating("InvokeFindController", 1, Interval);
                    }
                }
            }
        }

        public void InvokeFindController()
        {
            if (usingObjectName)
            {
                foreach (string tempname in FindingObjectName)
                {
                    TargetNameObject.CurrentValue = GameObject.Find(tempname);
                    if (TargetNameObject.CurrentValue != null)
                    {
                        if (usingSetActive)
                        {
                            TargetNameObject.CurrentValue.SetActive(ActiveStatus);
                        }
                        if (usingCamera)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<Camera>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<Camera>().enabled = CameraStatus;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = VideoStatus;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = CameraStatus;
                            }
                        }
                        if (usingVideo)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<Camera>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<Camera>().enabled = CameraStatus;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = VideoStatus;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = CameraStatus;
                            }
                        }
                        if (usingAudio)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<AudioSource>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioSource>().enabled = AudioStatus;
                            }
                        }
                        if (usingSetDestroy && DestroyStatus)
                        {
                            Destroy(TargetNameObject.CurrentValue);
                        }
                    }
                }
            }
            if (usingObjectTag)
            {
                foreach (string temptag in FindingObjectTag)
                {

                    findingObjectTag = GameObject.FindGameObjectsWithTag(temptag);

                    foreach (GameObject temp in findingObjectTag)
                    {
                        if (usingSetActive)
                        {
                            temp.SetActive(ActiveStatus);
                        }
                        if (usingCamera)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<Camera>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<Camera>().enabled = CameraStatus;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = CameraStatus;
                            }
                        }
                        if (usingVideo)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = VideoStatus;
                            }
                        }
                        if (usingAudio)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<AudioSource>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioSource>().enabled = AudioStatus;
                            }
                        }
                        if (usingSetDestroy && DestroyStatus)
                        {
                            Destroy(temp);
                        }
                    }
                }
            }
        }

        public void InvokeFindControllerTrue()
        {
            if (usingObjectName)
            {
                
                if (TargetNameObject.CurrentValue != null)
                {
                    if (usingSetActive)
                    {
                        TargetNameObject.CurrentValue.SetActive(true);
                    }
                    if (usingSetDestroy && DestroyStatus)
                    {
                        Destroy(TargetNameObject.CurrentValue);
                    }
                    if (usingCamera)
                    {
                        if (TargetNameObject.GetComponent<Camera>())
                        {
                            TargetNameObject.GetComponent<Camera>().enabled = true;
                        }
                        if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                        {
                            TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = true;
                        }
                    }
                    if (usingVideo)
                    {
                        if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                        {
                            TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = true;
                        }
                    }
                    if (usingAudio)
                    {
                        if (TargetNameObject.CurrentValue.GetComponent<AudioSource>())
                        {
                            TargetNameObject.CurrentValue.GetComponent<AudioSource>().enabled = true;
                        }
                    }
                    if (usingTrueEvent)
                    {
                        TrueEvent.Invoke();
                    }
                }
            }
            if (usingObjectTag)
            {
                foreach (string temptag in FindingObjectTag)
                {

                    findingObjectTag = GameObject.FindGameObjectsWithTag(temptag);

                    foreach (GameObject temp in findingObjectTag)
                    {
                        if (usingSetActive)
                        {
                            temp.SetActive(true);
                        }
                        if (usingSetDestroy && DestroyStatus)
                        {
                            Destroy(temp);
                        }
                        if (usingCamera)
                        {
                            if (TargetNameObject.GetComponent<Camera>())
                            {
                                TargetNameObject.GetComponent<Camera>().enabled = true;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = true;
                            }
                        }
                        if (usingVideo)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = true;
                            }
                        }
                        if (usingAudio)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<AudioSource>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioSource>().enabled = true;
                            }
                        }
                        if (usingTrueEvent)
                        {
                            TrueEvent.Invoke();
                        }
                    }
                }
            }
        }

        public void InvokeFindControllerFalse()
        {
            if (usingObjectName)
            {
                foreach (string tempname in FindingObjectName)
                {
                    TargetNameObject.CurrentValue = GameObject.Find(tempname);

                    if (TargetNameObject.CurrentValue != null)
                    {
                        if (usingSetActive)
                        {
                            TargetNameObject.CurrentValue.SetActive(false);
                        }
                        if (usingSetDestroy && DestroyStatus)
                        {
                            Destroy(TargetNameObject.CurrentValue);
                        }
                        if (usingCamera)
                        {
                            if (TargetNameObject.GetComponent<Camera>())
                            {
                                TargetNameObject.GetComponent<Camera>().enabled = false;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = false;
                            }
                        }
                        if (usingVideo)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = false;
                            }
                        }
                        if (usingAudio)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<AudioSource>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioSource>().enabled = false;
                            }
                        }
                        if (usingFalseEvent)
                        {
                            FalseEvent.Invoke();
                        }
                    }
                }

            }
            if (usingObjectTag)
            {
                foreach (string temptag in FindingObjectTag)
                {
                    findingObjectTag = GameObject.FindGameObjectsWithTag(temptag);

                    foreach (GameObject temp in findingObjectTag)
                    {
                        if (usingSetActive)
                        {
                            temp.SetActive(false);
                        }
                        if (usingSetDestroy && DestroyStatus)
                        {
                            Destroy(temp);
                        }
                        if (usingCamera)
                        {
                            if (TargetNameObject.GetComponent<Camera>())
                            {
                                TargetNameObject.GetComponent<Camera>().enabled = false;
                            }
                            if (TargetNameObject.CurrentValue.GetComponent<AudioListener>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioListener>().enabled = false;
                            }
                        }
                        if (usingVideo)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<VideoPlayer>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<VideoPlayer>().enabled = false;
                            }
                        }
                        if (usingAudio)
                        {
                            if (TargetNameObject.CurrentValue.GetComponent<AudioSource>())
                            {
                                TargetNameObject.CurrentValue.GetComponent<AudioSource>().enabled = false;
                            }
                        }
                        if (usingFalseEvent)
                        {
                            FalseEvent.Invoke();
                        }
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
