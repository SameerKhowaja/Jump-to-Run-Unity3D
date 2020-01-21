using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text gameoverTXT;
    public Canvas canvas;

    void Start()
    {
        StartCoroutine(loadMENU());
    }

    IEnumerator loadMENU()
    {
        gameoverTXT.enabled = true;
        yield return new WaitForSeconds(1.5f);
        canvas.enabled = true;
    }
    
}
