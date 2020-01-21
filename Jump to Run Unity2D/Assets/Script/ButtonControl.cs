using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public AudioSource click;

    public void MainMenu_BTN()
    {
        click.Play();
        SceneManager.LoadScene("main");
    }

    public void Restart_BTN()
    {
        click.Play();
        SceneManager.LoadScene("lvl01");
    }

}
