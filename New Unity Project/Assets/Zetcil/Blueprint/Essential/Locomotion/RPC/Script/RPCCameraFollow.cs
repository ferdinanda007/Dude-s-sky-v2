using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCCameraFollow : MonoBehaviour
{
    [Space(10)]
    public bool isEnabled;

    [Header("Camera Settings")]
    public Camera CameraController;

    [Header("Movement Settings")]
    public Vector3 specificVector;
    public float smoothSpeed;

    void Start()
    {
        CameraController.transform.parent = null;
    }

    void Update()
    {
        if (isEnabled)
        {
            if (CameraController.transform.position.y < transform.position.y)
            {
                specificVector = new Vector3(transform.position.x, transform.position.y - 2, CameraController.transform.position.z);
                CameraController.transform.position = Vector3.Lerp(CameraController.transform.position, specificVector, smoothSpeed * Time.deltaTime);
            }
            else if (CameraController.transform.position.y > transform.position.y)
            {
                specificVector = new Vector3(transform.position.x, transform.position.y + 2, CameraController.transform.position.z);
                CameraController.transform.position = Vector3.Lerp(CameraController.transform.position, specificVector, smoothSpeed * Time.deltaTime);
            }
            else
            {
                specificVector = new Vector3(transform.position.x, CameraController.transform.position.y, CameraController.transform.position.z);
                CameraController.transform.position = Vector3.Lerp(CameraController.transform.position, specificVector, smoothSpeed * Time.deltaTime);
            }
        }
    }
}
