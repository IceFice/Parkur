using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float spawnX, spawnY, spawnZ; 
    // Start is called before the first frame update
    void Start()
    {
        spawnX = 108.9269f;
        spawnY = 7.68f;
        spawnZ = -19.755f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(spawnX, spawnY, spawnZ);
        }
    }
}
