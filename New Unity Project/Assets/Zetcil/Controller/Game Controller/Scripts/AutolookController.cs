using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class AutolookController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("TargetObject Settings")]
        public GameObject TargetObject;

        [Header("Autolook Settings")]
        public bool usingAutolook;
        public float MinimalRange;
        [Tag] public List<string> TargetTag;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }

        public void ExecuteAutolook()
        {
            if (usingAutolook)
            {
                for (int i = 0; i < TargetTag.Count; i++)
                {
                    GameObject[] temp = GameObject.FindGameObjectsWithTag(TargetTag[i]);
                    for (int j = 0; j < temp.Length; j++)
                    {
                        float distance = Vector3.Distance(TargetObject.transform.position, temp[j].transform.position);
                        if (distance < MinimalRange)
                        {
                            TargetObject.transform.LookAt(new Vector3(temp[j].transform.position.x,
                                                                      TargetObject.transform.position.y,
                                                                      temp[j].transform.position.z));
                        }
                    }
                }
            }
        }
    }
}
