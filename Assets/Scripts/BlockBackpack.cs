using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class BlockBackpack : MonoBehaviour
{
    public ActionBasedController rController;
    public ActionBasedController lController;

    public List<GameObject> blocks;

    private Collider col;

    private const float MAX_TIME = 50;
    private float curTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(curTime);

        if (curTime <= 0)
        {
            if (col.bounds.Contains(rController.transform.position) && rController.selectAction.action.inProgress)
            {
                Debug.Log("WHAT");
                SpawnAndGrab(rController);
                curTime = MAX_TIME;
            }

            if (col.bounds.Contains(lController.transform.position) && lController.selectAction.action.inProgress)
            {
                SpawnAndGrab(lController);
                curTime = MAX_TIME;
            }
        }
        else
            curTime -= Time.deltaTime;
    }

    void SpawnAndGrab(ActionBasedController c)
    {
        // Randomly pick a block from blocks
        int r = Random.Range(0, blocks.Count - 1);
        // Spawn that block
        GameObject spawned = Instantiate(blocks[r], c.transform.position, Quaternion.identity);
        // Force hand to grab block
        spawned.GetComponent<XRGrabInteractable>().interactionManager.ForceSelect(c.GetComponentInChildren<XRDirectInteractor>(), spawned.GetComponent<XRGrabInteractable>());
    }
}
