using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorCollision : MonoBehaviour
{
    public bool firstCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (firstCollision == false)
        {
            firstCollision = true;
            Debug.Log("first collision");
        }
    }
}