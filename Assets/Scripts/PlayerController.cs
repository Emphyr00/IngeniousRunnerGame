using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float strifeSpeed = 3;
    public Rigidbody rb;
    public float jumpForce = 8f;
    private bool readyForAction = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > 11.0f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * strifeSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightAlt))
        {
            if (this.gameObject.transform.position.x < 19.0f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * strifeSpeed * -1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && readyForAction == true)
        {
            readyForAction = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S) && readyForAction == true) 
        {
            readyForAction = false;
            rb.GetComponent<CapsuleCollider>().height = 0.01f;
            Invoke("MakeReady", 1);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        readyForAction = true;
    }

    void MakeReady()
    {
        rb.GetComponent<CapsuleCollider>().height = 2f;
        readyForAction = true;
    }
}
