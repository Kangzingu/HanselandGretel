using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKinematic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
        //    collision.collider.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}