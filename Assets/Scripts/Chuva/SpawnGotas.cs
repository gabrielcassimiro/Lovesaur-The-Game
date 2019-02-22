using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGotas : MonoBehaviour
{
    public GameObject gota;
    public float x1, x2, y;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawn());
        
    }
    IEnumerator spawn() {
        float spawnX = Random.Range(x1, x2);
        Instantiate(gota, new Vector3(spawnX, y, 0), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        
    }
}
