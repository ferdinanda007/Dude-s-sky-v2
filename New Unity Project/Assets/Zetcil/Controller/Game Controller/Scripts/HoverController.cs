using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class HoverController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Text Settings")]
        public VarString TextCaption;

        [Header("Material Settings")]
        public bool usingMaterialSettings;
        public MeshRenderer TargetMaterial;
        public Material NormalMaterial;
        public Material HighlightMaterial;
        bool isHover; 

        [Header("GUI Settings")]
        public bool usingGUISettings;
        public GUISkin gUISkin;
        public Vector2 gUISize;
        public Vector2 gUIOffset;

        // Start is called before the first frame update
        void Start()
        {
            isHover = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseExit()
        {
            TargetMaterial.GetComponent<Renderer>().material = NormalMaterial;
            isHover = false;
        }

        void OnMouseOver()
        {
            TargetMaterial.GetComponent<Renderer>().material = HighlightMaterial;
            isHover = true;
        }

        void OnGUI()
        {
            if (isHover)
            {
                if (usingGUISettings)
                {
                    GUI.skin = gUISkin;
                    GUI.Box(new Rect(1 + Input.mousePosition.x + gUIOffset.x, Screen.height - Input.mousePosition.y + gUIOffset.y, gUISize.x, gUISize.y), TextCaption.CurrentValue);
                }
            }
        }
    }
}
