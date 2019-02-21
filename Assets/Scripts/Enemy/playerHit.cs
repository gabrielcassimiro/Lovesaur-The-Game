using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{
    public GameObject player;
    
    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(x, y);
        }
    }
}
