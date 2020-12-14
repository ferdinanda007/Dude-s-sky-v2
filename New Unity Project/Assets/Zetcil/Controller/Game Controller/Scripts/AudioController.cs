using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class AudioController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Audio Setting")]
        public AudioSource TargetAudio;


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
                InvokeAudioController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeAudioController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeAudioController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeAudioController", 1, Interval);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayAudioLoop()
        {
            if (!TargetAudio.isPlaying)
            {
                TargetAudio.Play();
            }
        }

        public void PlayAudioOnce()
        {
            if (!TargetAudio.isPlaying)
            {
                TargetAudio.Play();
            }
        }

        public void PlayAudio()
        {
            TargetAudio.Play();
        }

        public void StopAudio()
        {
            TargetAudio.Stop();
        }

        public void PlayAudioWithDelay()
        {
            Invoke("ExecutePlayAudio", Delay);
        }

        public void StopAudioWithDelay()
        {
            Invoke("ExecuteStopAudio", Delay);
        }

        void InvokeAudioController()
        {
            TargetAudio.Play();
        }

        void ExecutePlayAudio()
        {
            TargetAudio.Stop();
        }

        void ExecuteStopAudio()
        {
            TargetAudio.Stop();
        }
    }
}
