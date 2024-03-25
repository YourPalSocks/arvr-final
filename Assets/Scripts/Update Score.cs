using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshPro _title;
    public inTableBox tablebox;
    // Start is called before the first frame update
    void Start()
    {
        _title.text = "Height: 0m";
    }

    // Update is called once per frame
    void Update()
    {
        string mh = tablebox.tableHeight.ToString();
        if (mh.IndexOf('.') > 0)
        {
            mh = mh.Substring(0, mh.IndexOf('.') + 3);
            _title.text = "Height: " + mh + 'm';
        }
    }

}
