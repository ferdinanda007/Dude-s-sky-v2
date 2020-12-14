/**************************************************************************************************************
 * Author   : Unity Community
 * Modifier : Rickman Roedavan
 * Version  : 2.12
 * Desc     : Pembuatan mekanisme singleton bisa dimodif untuk beberapa class
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : Singleton<GlobalManager>
{
    public bool isEnabled;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
