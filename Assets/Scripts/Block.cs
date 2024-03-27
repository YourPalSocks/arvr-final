using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool stoppedInteracting = false;
    private float timer = 5f;

    public void Update()
    {
        if (stoppedInteracting)
        {
            if (timer <= 0)
            {
                stoppedInteracting = false;
                GetComponent<Rigidbody>().excludeLayers = 0;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            // Turn off the physics layer that touches the controllers
            GetComponent<Rigidbody>().excludeLayers = gameObject.layer;
            stoppedInteracting = true;
        }
    }
}
