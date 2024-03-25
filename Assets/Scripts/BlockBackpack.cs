using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class BlockBackpack : MonoBehaviour
{
    public ActionBasedController rController;
    public ActionBasedController lController;
    public WristPanel wristPanel;

    public List<GameObject> blocks;

    [HideInInspector]
    public GameObject nextBlock;

    private AudioSource sfx;
    private Collider col;
    private const float MAX_TIME = 2;
    private float curTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        sfx = GetComponent<AudioSource>();
        GetNextBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime <= 0)
        {
            if (col.bounds.Contains(rController.transform.position) && rController.selectAction.action.inProgress
                && rController.GetComponentInChildren<XRDirectInteractor>().interactablesSelected.Count == 0)
            {
                SpawnAndGrab(rController);
                curTime = MAX_TIME;
            }

            if (col.bounds.Contains(lController.transform.position) && lController.selectAction.action.inProgress
                && lController.GetComponentInChildren<XRDirectInteractor>().interactablesSelected.Count == 0)
            {
                SpawnAndGrab(lController);
                curTime = MAX_TIME;
            }
        }
        else
            curTime -= Time.deltaTime;
    }

    void GetNextBlock()
    {
        // Randomly pick a block from blocks
        int r = Random.Range(0, blocks.Count - 1);
        nextBlock = blocks[r];
        // Update the wrist panel
        wristPanel.SpawnNextBlock(nextBlock);
    }

    void SpawnAndGrab(ActionBasedController c)
    {
        // Spawn that block
        GameObject spawned = Instantiate(nextBlock, c.transform.position, Quaternion.identity);
        // Force hand to grab block
        spawned.GetComponent<XRGrabInteractable>().interactionManager.ForceSelect(c.GetComponentInChildren<XRDirectInteractor>(), spawned.GetComponent<XRGrabInteractable>());
        // Get next block
        GetNextBlock();
        // Adjust and Play sound
        sfx.pitch = Random.Range(0.5f, 1.5f);
        sfx.Play();
    }
}
