using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITableRow : MonoBehaviour
{
    public Text NumberColumns;
    public Text[] DataColumns;

    public void SetDataRow(int aNumber, int aColumn, string aValue)
    {
        if (aColumn < 0) aColumn = 0;
        //if (aColumn > DataColumns.Length) aColumn = DataColumns.Length - 1;
        NumberColumns.text = aNumber.ToString();
        DataColumns[aColumn].text = aValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
