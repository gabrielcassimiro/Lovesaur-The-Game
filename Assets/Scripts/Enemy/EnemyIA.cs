using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{

    [Range(1, 10)] public float speed = 5f;

    public bool GroundTrue = false;
    public bool runLeft = true;

    public Transform groundDetection;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D raycast = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if(!raycast.collider){
                if(runLeft){
            transform.eulerAngles = new Vector3(0,180,0);                
                runLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                runLeft = true;
            }
        }
    }
}
