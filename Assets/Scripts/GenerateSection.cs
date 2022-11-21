using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class GenerateSection : MonoBehaviour
{
    public bool generate = true;
    public GameObject section;
    public GameObject api;
    public int zPos = ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (generate == true)
        {
            generate = false;
            StartCoroutine(Generate());
        }
    }

    IEnumerator Generate()
    {
        Instantiate(section, new Vector3(15, 0, zPos), Quaternion.identity);
        zPos += 60;
        
        StartCoroutine(api.GetComponent<ApiGetBlock>().getRequest(new Uri("http://localhost:5000/api/block?username=\"" + "test" + "\"")));
        yield return new WaitForSeconds(10);
        generate = true;
        
    }
}
