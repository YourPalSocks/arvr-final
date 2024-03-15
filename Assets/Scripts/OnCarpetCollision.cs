using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCarpetCollision : MonoBehaviour
{
    public BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    //Detect collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Debug.Log("I've been hit");
        }
    }
}
