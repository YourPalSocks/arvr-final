using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class inTableBox : MonoBehaviour
{
    [HideInInspector]
    public float tableHeight = 0;

    private List<GameObject> stackedBlocks = new List<GameObject>();

    IEnumerator processBlocks()
    {
        // Do block processing
        for(;;)
        {
            float maxHeight = 0;
            foreach (GameObject block in stackedBlocks)
            {
                if (block.transform.position.y > maxHeight && block.GetComponent<XRGrabInteractable>().interactorsSelecting.Count <= 0)
                {
                    maxHeight = block.transform.position.y;
                }
            }
            // Update scoreboard
            tableHeight = maxHeight;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            stackedBlocks.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            stackedBlocks.Remove(other.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(processBlocks());
    }
}
