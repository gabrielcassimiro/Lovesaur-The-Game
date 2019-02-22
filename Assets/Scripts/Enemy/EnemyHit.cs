using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{

    public GameObject player;
    private Rigidbody2D rb2D;



    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb2D.AddForce(new Vector2(x, y));
            Destroy(gameObject);
        }
    }
}
