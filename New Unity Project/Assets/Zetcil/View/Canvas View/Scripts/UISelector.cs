using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class UISelector : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Selector Settings")]
        public SpriteRenderer TargetSelector;
        public VarBoolean SelectorStatus;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (TargetSelector != null)
                {
                    TargetSelector.enabled = SelectorStatus.CurrentValue;
                }
            }
        }
    }
}
