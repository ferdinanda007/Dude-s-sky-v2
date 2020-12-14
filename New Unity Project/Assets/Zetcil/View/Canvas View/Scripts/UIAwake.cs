using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAwake : MonoBehaviour
{
    public enum CAwakeType { Hide, Show }
    public CAwakeType AwakeType;

    // Start is called before the first frame update
    void Awake()
    {
        if (AwakeType == CAwakeType.Hide)
        {
            gameObject.SetActive(false);
        }
        if (AwakeType == CAwakeType.Show)
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
