using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGota : MonoBehaviour
{
    public Transform Respawn;

    private void Awake() {
        Respawn = GameObject.Find("Respawn").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.transform.position = Respawn.position;
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Line") || collision.CompareTag("Ground")) {
            Destroy(this.gameObject);
        }
    }
}
