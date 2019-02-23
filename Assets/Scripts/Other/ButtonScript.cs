using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    
    public void ComecarJogo(){
        Rigidbody2D rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        GameObject.FindObjectOfType<PhysicsObject>().isPlaying = true;
    }

}
