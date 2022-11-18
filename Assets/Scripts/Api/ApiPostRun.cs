using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class ApiPostRun : MonoBehaviour
{
    public string username;
    public int topField;
    public int bottomField;
    public int leftField;
    public int centerField;
    public int rightField;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getRequest(new Uri("http://localhost:5000/api/run")));
    }
    IEnumerator getRequest(System.Uri uri)
    {
        string json = "{ \"username\": \"" + username + "\", \"top_field\" : \"" + topField + "\", \"bottom_field\" : \"" + bottomField + "\", \"left_field\" : \"" + leftField + "\", \"center_field\" : \"" + centerField + "\", \"right_field\" : \"" + rightField + "\" }";
        var uwr = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

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
