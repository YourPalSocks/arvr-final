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
    private GameObject nextBlock;

    private Collider col;

    private const float MAX_TIME = 5;
    private float curTime = 0;

    public HandPanel handPanel;


    void Start()
    {
        col = GetComponent<Collider>();
        SelectNextBlock();
    }

    void Update()
    {
        if (curTime <= 0)
        {
            if (col.bounds.Contains(rController.transform.position) && rController.selectAction.action.inProgress)
            {
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

    /// <summary>
    /// Spawns the next block and forces the player to hold it.
    /// </summary>
    /// <param name="c">The controller initiating the interaction</param>
    void SpawnAndGrab(ActionBasedController c)
    {
        // Spawn that block
        GameObject spawned = Instantiate(nextBlock, c.transform.position, Quaternion.identity);
        // Force hand to grab block
        spawned.GetComponent<XRGrabInteractable>().interactionManager.ForceSelect(c.GetComponentInChildren<XRDirectInteractor>(), spawned.GetComponent<XRGrabInteractable>());
        // Prep next block after spawning
        SelectNextBlock();
    }

    /// <summary>
    /// Selects a block from a list of blocks. Updates player gui.
    /// </summary>
    void SelectNextBlock()
    {
        // Select next block from block list
        int r = Random.Range(0, blocks.Count - 1);
        nextBlock = blocks[r];
        // Update hand panel with block info
        handPanel.UpdateHandPanel(nextBlock);
    }
}
