using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class ApiGetBlock : MonoBehaviour
{
    public string username;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getRequest(new Uri("http://localhost:5000/api/block?username=" + username)));
    }
    IEnumerator getRequest(System.Uri uri)
    {

        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
