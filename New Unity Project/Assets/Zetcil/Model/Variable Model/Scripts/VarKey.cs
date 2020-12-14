using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

public class VarKey : MonoBehaviour
{

    [Space(10)]
    public bool isEnabled;

    [SearchableEnum] public KeyCode InputKeyDown;
    public UnityEvent KeyDownEvent;

    [Space(10)]
    [SearchableEnum] public KeyCode InputKey;
    public UnityEvent KeyEvent;

    [Space(10)]
    [SearchableEnum] public KeyCode InputKeyUp;
    public UnityEvent KeyUpEvent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputKeyDown))
        {
            KeyDownEvent.Invoke();
        }
        if (Input.GetKey(InputKey))
        {
            KeyEvent.Invoke();
        }
        if (Input.GetKeyUp(InputKeyUp))
        {
            KeyUpEvent.Invoke();
        }
    }
}
