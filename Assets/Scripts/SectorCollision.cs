using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorCollision : MonoBehaviour
{
    public bool firstCollision = false;
    public GameObject section;
    public int zPos = 60;
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
            Instantiate(section, new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 30;
        }
    }
}
