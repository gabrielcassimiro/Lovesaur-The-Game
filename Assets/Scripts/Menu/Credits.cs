using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public string scene;
    public string scene2;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene(scene);
        }

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(scene2);
        }
    }
}
