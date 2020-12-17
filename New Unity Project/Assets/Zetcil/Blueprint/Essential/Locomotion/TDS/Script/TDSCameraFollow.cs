using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDSCameraFollow : MonoBehaviour
{
    [Space(10)]
    public bool isEnabled;

    [Header("Camera Settings")]
    public Camera CameraController;
    Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        Offset = CameraController.transform.position - transform.position;
        CameraController.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        CameraController.transform.position = transform.position + Offset;
    }
}
