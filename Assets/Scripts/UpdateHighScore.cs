using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHighScore : MonoBehaviour
{

    public string type;
    void Start()
    {
        TextMeshPro m_tmp = GetComponent<TextMeshPro>();
        // Set high score text on load
        string prefaceText = m_tmp.text.Substring(0, m_tmp.text.IndexOf(':') + 1);
        m_tmp.text = prefaceText + ' ' + PlayerPrefs.GetFloat(type).ToString() + "m";
    }
}
