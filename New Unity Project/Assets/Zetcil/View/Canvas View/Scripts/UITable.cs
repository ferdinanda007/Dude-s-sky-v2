using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil {

    public class UITable : MonoBehaviour
    {
        public enum CTableDataLoad { None, ByDelay, ByInputKey, ByEvent }

        public bool isEnabled;

        [Header("Data Settings")]
        public VarJSON JSONData;

        [Header("Table Settings")]
        public GameObject TableViewport;
        public GameObject TableContent;
        public UITableRow TableRow;
        public float TableRowSize = 50;

        [Header("Load Data Settings")]
        public CTableDataLoad TableDataLoad;
        public float LoadDelay;
        [SearchableEnum] public KeyCode LoadKey;

        public int TotalColumns;

        public void ExecuteTableDataLoad()
        {
            TableContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0,
                TableContent.GetComponent<RectTransform>().rect.height + (TableRowSize * JSONData.JSONRoot.Count));
            for (int i=0; i < JSONData.JSONRoot.Count; i++)
            {
                GameObject temp = GameObject.Instantiate(TableRow.gameObject, TableContent.transform);

                int JSONColumn = temp.GetComponent<UITableRow>().DataColumns.Length;
                for (int j=0; j<JSONColumn; j++)
                {
                    string aData = JSONData.JSONRoot[i].JSONData[j].Value;
                    temp.GetComponent<UITableRow>().SetDataRow(i+1, j, aData);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (TableDataLoad == CTableDataLoad.ByDelay)
            {
                Invoke("ExecuteTableDataLoad", LoadDelay);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (TableDataLoad == CTableDataLoad.ByInputKey)
            {
                if (Input.GetKeyDown(LoadKey))
                {
                    ExecuteTableDataLoad();
                }
            }
        }
    }
}
