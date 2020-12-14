using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class UILevel : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Main Settings")]
        public int DefaultLevelIndex;
        public Text LevelName;
        public List<LevelActivation> TargetLevel;

        [Header("Index Settings")]
        public bool usingIndex;
        public VarInteger VarIndex;

        // Start is called before the first frame update
        void Start()
        {
            SetActiveLevel();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SetActiveLevel()
        {
            for (int i = 0; i < TargetLevel.Count; i++)
            {
                TargetLevel[i].LevelObject.SetActive(false);
            }
            TargetLevel[DefaultLevelIndex].LevelObject.SetActive(true);
            LevelName.text = TargetLevel[DefaultLevelIndex].LevelName;
            if (usingIndex)
            {
                VarIndex.CurrentValue = DefaultLevelIndex + 1;
            }
        }

        public void NextLevel()
        {
            if (DefaultLevelIndex < TargetLevel.Count - 1)
            {
                DefaultLevelIndex++;
            }
            SetActiveLevel();
        }

        public void PrevLevel()
        {
            if (DefaultLevelIndex > 0)
            {
                DefaultLevelIndex--;
            }
            SetActiveLevel();
        }

    }
}
