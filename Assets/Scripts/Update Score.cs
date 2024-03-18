using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    private  TextMesh _title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetScore(GameObject tableBox)
    {
        _title.text = "Score: " + tableBox;
    }
}
