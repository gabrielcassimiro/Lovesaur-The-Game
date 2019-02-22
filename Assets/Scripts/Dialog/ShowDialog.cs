using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialog : MonoBehaviour
{
    public GameObject boxDialog;
    public Text boxText;
    public string[] dialog;
    public GameObject noticeDialog;

    public int pointer;

    public bool canDialog;

    // Start is called before the first frame update
    void Start()
    {
        canDialog = false;
        pointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Dialog();
        if (Input.GetKey(KeyCode.C)) {
            boxDialog.SetActive(false);
            canDialog = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            noticeDialog.SetActive(true);
            canDialog = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canDialog)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                noticeDialog.SetActive(false);
                boxDialog.SetActive(true);
                boxText.text = dialog[pointer];
            }
        }
    }

   

    private void Dialog()
    {
        if (canDialog == true && Input.GetKeyDown(KeyCode.X))
        {
            pointer++;
            boxText.text = dialog[pointer];
        }
    }
}
