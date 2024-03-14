using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPanel : MonoBehaviour
{

    private MeshFilter blockPos;

    void Start()
    {
        blockPos = transform.GetChild(1).GetComponent<MeshFilter>();
    }
    
    /// <summary>
    /// Updates the wrist panel's mesh to the next block's mesh.
    /// </summary>
    /// <param name="block">The next block the backpack will spawn</param>
    public void UpdateHandPanel(GameObject block)
    {
        // Copy the 
        blockPos.mesh = block.GetComponent<MeshFilter>().mesh;
    }
}
