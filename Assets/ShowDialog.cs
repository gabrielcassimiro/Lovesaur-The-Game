using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    public GameObject boxDialog;
    public GameObject[] dialog;
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
            if (Input.GetKeyDown("z"))
            {
                noticeDialog.SetActive(false);
                boxDialog.SetActive(true);
                dialog[pointer].SetActive(true);
            }
        }
    }

    private void Dialog()
    {
        if (canDialog == true && Input.GetKeyUp("x"))
        {
            dialog[pointer].SetActive(false);
            pointer++;

            if (pointer >= dialog.Length)
            {
                boxDialog.SetActive(false);
                dialog[pointer].SetActive(false);
                canDialog = false;
            }
        }
    }
}
