using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraMovement : MonoBehaviour
{
    [Space(10)]
    public bool isEnabled;

    [Header("Camera Settings")]
    public Camera RTSCamera;

    [Header("Movement Settings")]
    public float ScrollSpeed = 15;
    public float ScrollEdge = 0.01f;
 
    float PanSpeed = 10;
    Vector2 ZoomRange = new Vector2(-5,5);
    float CurrentZoom = 0;
    float ZoomZpeed = 1;
    float ZoomRotation = 1;
 
    Vector3 InitPos;
    Vector3 InitRotation;
 
 
    void Start()
    {
        //Instantiate(Arrow, Vector3.zero, Quaternion.identity);

        RTSCamera.transform.parent = null;
        InitPos = RTSCamera.transform.position;
        InitRotation = RTSCamera.transform.eulerAngles;

    }

    void Update()
    {
        //PAN
        if (Input.GetKey("mouse 2"))
        {
            //(Input.mousePosition.x - Screen.width * 0.5)/(Screen.width * 0.5)

            RTSCamera.transform.Translate(Vector3.right * Time.deltaTime * PanSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
            RTSCamera.transform.Translate(Vector3.forward * Time.deltaTime * PanSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);

        }
        else
        {
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge))
            {
                RTSCamera.transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
            }
            else if (Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge)
            {
                RTSCamera.transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);
            }

            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge))
            {
                RTSCamera.transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
            }
            else if (Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge)
            {
                RTSCamera.transform.Translate(Vector3.forward * Time.deltaTime * -ScrollSpeed, Space.World);
            }
        }

        //ZOOM IN/OUT

        CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

        CurrentZoom = Mathf.Clamp(CurrentZoom, ZoomRange.x, ZoomRange.y);

        Vector3 tempPosition = RTSCamera.transform.position;
        tempPosition.y -= (RTSCamera.transform.position.y - (InitPos.y + CurrentZoom)) * 0.1f;
        RTSCamera.transform.position = tempPosition;

        Vector3 tempAngle = RTSCamera.transform.eulerAngles;
        tempAngle.x -= (RTSCamera.transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation)) * 0.1f;
        RTSCamera.transform.eulerAngles = tempAngle;

    }
}
