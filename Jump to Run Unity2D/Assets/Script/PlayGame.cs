using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public Canvas canvas;
    public AudioSource click;

    public void PlayBTN_Clicks()
    {
        StartCoroutine(waitThenLoadScene());
    }

    public void InstructionBTN_Clicks()
    {
        click.Play();
        canvas.enabled = true;
    }

    public void BackBTN_Clicks()
    {
        click.Play();
        canvas.enabled = false;
    }


    IEnumerator waitThenLoadScene()
    {
        click.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
