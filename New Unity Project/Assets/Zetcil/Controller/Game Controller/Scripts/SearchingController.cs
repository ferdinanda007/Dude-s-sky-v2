using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class SearchingController : MonoBehaviour
    {
        public enum CSearchingType { ByNearest, ByFarthest }

        [System.Serializable]
        public class CTargetObject
        {
            public GameObject VisualObject;
            public float CurrentDistance;
        }

        [Space(10)]
        public bool isEnabled;

        [Header("Player Settings")]
        public CharacterController TargetController;
        public VarObject TargetDestination;

        [Header("Searching Settings")]
        [Tag] public string TargetTag;
        public CSearchingType SearchingType;
        public float SearchingInterval;

        [Header("Searching Status")]
        public List<CTargetObject> TargetObject;
        [ReadOnly] public int NearestIndex;
        [ReadOnly] public float NearestValue = 100;
        [ReadOnly] public int FarthestIndex;
        [ReadOnly] public float FarthestValue = 0;

        GameObject[] tempTarget;

        // Start is called before the first frame update
        void Start()
        {
            if (isEnabled)
            {
                InvokeRepeating("SearchingTarget", 1, SearchingInterval);
            }
        }

        static int SortByDistance(Vector3 g1, Vector3 g2, Vector3 player)
        {
            float dist1 = Vector3.Distance(g1, player);
            float dist2 = Vector3.Distance(g2, player);
            return dist1.CompareTo(dist2);
        }

        public void SearchingTarget()
        {
            tempTarget = GameObject.FindGameObjectsWithTag(TargetTag);

            for (int i=0; i<tempTarget.Length; i++)
            {
                bool objectExist = false;
                for (int j = 0; j < TargetObject.Count; j++)
                {
                    if (tempTarget[i].name == TargetObject[j].VisualObject.name)
                    {
                        TargetObject[j].CurrentDistance = Vector3.Distance(TargetController.transform.position, tempTarget[i].transform.position);
                        if (TargetObject[j].CurrentDistance < NearestValue)
                        {
                            NearestIndex = i;
                            NearestValue = TargetObject[j].CurrentDistance;
                        }
                        if (TargetObject[j].CurrentDistance > FarthestValue)
                        {
                            FarthestIndex = i;
                            FarthestValue = TargetObject[j].CurrentDistance;
                        }
                        objectExist = true;
                    }
                }
                if (!objectExist)
                {
                    CTargetObject newObject = new CTargetObject();
                    newObject.VisualObject = tempTarget[i];
                    newObject.CurrentDistance = Vector3.Distance(TargetController.transform.position, tempTarget[i].transform.position);
                    TargetObject.Add(newObject);
                } 

            }

            if (tempTarget.Length > 0)
            {
                if (SearchingType == CSearchingType.ByNearest)
                {
                    TargetDestination.CurrentValue = tempTarget[NearestIndex];
                }
                else if (SearchingType == CSearchingType.ByFarthest)
                {
                    TargetDestination.CurrentValue = tempTarget[FarthestIndex];
                }
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
