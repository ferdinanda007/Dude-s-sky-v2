using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{

    public class CanvasWorld : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Main Settings")]
        public Canvas TargetCanvas;
        [Tag] public string CameraTag;

        // Start is called before the first frame update
        void Start()
        {
            GameObject TargetCamera = GameObject.FindGameObjectWithTag(CameraTag);
            TargetCanvas.worldCamera = TargetCamera.GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
