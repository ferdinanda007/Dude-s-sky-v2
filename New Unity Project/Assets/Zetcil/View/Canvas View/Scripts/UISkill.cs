using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class UISkill : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Action Settings")]
        public VarBoolean ActionStatus;

        [Header("Button Settings")]
        public Button SkillButton;

        [Header("Shortcut Settings")]
        public bool usingShortcut;
        [SearchableEnum] public KeyCode Shortcut;

        [Header("Cooldown Settings")]
        public bool usingCooldown;
        public int CooldownTimer;
        public Text CooldownText;
        bool isCooldown = false;

        [Header("Mana Settings")]
        public bool usingMana;
        public VarMana TargetMana;
        public float ManaCost;

        float CurrentTimer = 0.0f;
        int seconds = 0;
        int offset;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (usingShortcut)
            {
                if (Input.GetKey(Shortcut))
                {
                    ExecuteSkill();
                }
            }
            if (isCooldown)
            {
                CurrentTimer += Time.deltaTime;
                seconds = (int) Mathf.Round(CurrentTimer % 60);
                offset = CooldownTimer - seconds;
                CooldownText.text = offset.ToString();
                if (offset <= 0)
                {
                    isCooldown = false;
                    CooldownText.gameObject.SetActive(false);
                    SkillButton.interactable = true;
                    ActionStatus.SetCurrentValue(false);
                }
            }
        }

        public void TestDebugSkill(string avalue)
        {
            Debug.Log(avalue);
        }

        public void ExecuteSkill()
        {
            if (usingMana)
            {
                if (TargetMana.CurrentValue > ManaCost)
                {
                    if (!isCooldown)
                    {
                        isCooldown = true;
                        TargetMana.SubtractFromCurrentValue(ManaCost);
                        ActionStatus.SetCurrentValue(true);
                        if (usingCooldown)
                        {
                            CurrentTimer = 0;
                            SkillButton.interactable = false;
                            CooldownText.gameObject.SetActive(true);
                            CooldownText.text = CooldownTimer.ToString();
                        }
                        else
                        {
                            isCooldown = false;
                        }
                    }
                }
            } else if (!isCooldown)
            {
                isCooldown = true;
                if (usingCooldown)
                {
                    CurrentTimer = 0;
                    SkillButton.interactable = false;
                    ActionStatus.SetCurrentValue(true);
                    CooldownText.gameObject.SetActive(true);
                    CooldownText.text = CooldownTimer.ToString();
                } else
                {
                    isCooldown = false;
                }
            }
        }

    }
}
