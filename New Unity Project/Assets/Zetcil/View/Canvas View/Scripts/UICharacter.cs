using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class UICharacter : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Main Settings")]
        public int DefaultCharacterIndex;
        public Text CharacterName;
        public List<CharacterActivation> TargetCharacter;

        [Header("Index Settings")]
        public bool usingIndex;
        public VarInteger VarIndex;

        [Header("Audio Settings")]
        public bool usingAudio;
        public List<AudioSource> TargetAudio;

        // Start is called before the first frame update
        void Start()
        {
            SetActiveCharacter();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SetActiveCharacter()
        {
            for (int i = 0; i < TargetCharacter.Count; i++)
            {
                TargetCharacter[i].CharacterObject.SetActive(false);
            }
            TargetCharacter[DefaultCharacterIndex].CharacterObject.SetActive(true);
            CharacterName.text = TargetCharacter[DefaultCharacterIndex].CharacterName;
            if (usingIndex)
            {
                VarIndex.CurrentValue = DefaultCharacterIndex + 1;
            }
            if (usingAudio)
            {
                AllAudioStop();
                TargetAudio[DefaultCharacterIndex].Play();
            }
        }

        public void NextCharacter()
        {
            if (DefaultCharacterIndex < TargetCharacter.Count - 1)
            {
                DefaultCharacterIndex++;
            }
            SetActiveCharacter();
        }

        public void AllAudioStop()
        {
            if (usingAudio)
            {
                for (int i=0;i < TargetAudio.Count; i++)
                {
                    TargetAudio[i].Stop();
                }
            }
        }

        public void PrevCharacter()
        {
            if (DefaultCharacterIndex > 0)
            {
                DefaultCharacterIndex--;
            }
            SetActiveCharacter();
        }

    }
}
