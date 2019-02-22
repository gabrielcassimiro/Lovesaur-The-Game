using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    public void btScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void btQuit()
    {
        Application.Quit();
    }
}
