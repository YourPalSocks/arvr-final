using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;


public class WristPanel : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject panel;

    // Update is called once per frame
    public void SpawnNextBlock(GameObject block)
    {
        if (panel == null)
        {
            panel = transform.GetChild(0).GetChild(0).gameObject;
        }
        // Destroy previous block on panel
        for(int i = 0; i < panel.transform.childCount; i++)
        {
            Destroy(panel.transform.GetChild(i).gameObject);
        }
        // Spawn the object as is and attach it to the panel
        GameObject nextBlock = Instantiate(block);
        // Set transform
        nextBlock.transform.parent = panel.transform;
        nextBlock.transform.localPosition = new Vector3(0, 0, -0.5f);
        nextBlock.transform.localScale = new Vector3(20f, 20f, 20f);
        nextBlock.transform.rotation = panel.transform.rotation;
        // Disable/Delete all the physics components
        nextBlock.GetComponent<Collider>().enabled = false;
        Destroy(nextBlock.GetComponent<XRGrabInteractable>());
        Destroy(nextBlock.GetComponent<XRGeneralGrabTransformer>());
        Destroy(nextBlock.GetComponent<Rigidbody>());
    }
}
