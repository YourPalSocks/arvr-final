using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneSwitchBlock : MonoBehaviour
{
    public int nextScene;

    private XRGrabInteractable me;

    private void Start()
    {
        me = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        if (me.interactorsSelecting.Count > 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
