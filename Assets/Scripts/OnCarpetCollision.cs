using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCarpetCollision : MonoBehaviour
{
    public BoxCollider col;
    public inTableBox tablebox;
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
            // Check if update PlayerPrefs
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 1: // Normal Mode
                    if (PlayerPrefs.GetFloat("MaxHeight") < tablebox.tableHeight)
                    {
                        string mh = tablebox.tableHeight.ToString().Substring(0, tablebox.tableHeight.ToString().IndexOf('.') + 3);
                        PlayerPrefs.SetFloat("MaxHeight", float.Parse(mh));
                    }
                    break;

                case 2: //Ice Mode
                    if (PlayerPrefs.GetFloat("MaxIceHeight") < tablebox.tableHeight)
                    {
                        string mh = tablebox.tableHeight.ToString().Substring(0, tablebox.tableHeight.ToString().IndexOf('.') + 3);
                        PlayerPrefs.SetFloat("MaxIceHeight", float.Parse(mh));
                    }
                    break;
            }


            SceneManager.LoadScene(0);
        }
    }
}
