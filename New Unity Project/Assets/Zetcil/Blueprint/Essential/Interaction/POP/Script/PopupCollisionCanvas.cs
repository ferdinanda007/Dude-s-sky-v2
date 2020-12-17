using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class PopupCollisionCanvas : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Canvas Settings")]
        public Canvas TargetCanvas;
        public Camera TargetCamera;

        // Start is called before the first frame update
        void Start()
        {
            TargetCanvas.worldCamera = TargetCamera;
            Debug.Log("PopupCollisionCanvas.TargetCamera using " + TargetCamera.name + ".");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
