using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inTableBox : MonoBehaviour
{
    [HideInInspector]
    public int tableTouchCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            tableTouchCount++;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            tableTouchCount--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tableTouchCount);
    }
}
