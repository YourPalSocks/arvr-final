using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class BlockBackpack : MonoBehaviour
{
    public XRController rController;
    public XRController lController;

    private InputActionReference gripRef;

    private Collider col;

    // Start is called before the first frame update
    void Start()
    {  
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(col.bounds.Contains(rController.transform.position))
        {
            Debug.Log("Entered!");
        }
    }
}
