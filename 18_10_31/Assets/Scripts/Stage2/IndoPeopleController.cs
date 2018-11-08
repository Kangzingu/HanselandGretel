using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoPeopleController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //person = this.GetComponent<GameObject>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("sdasd");
        if (collision.collider.tag == "MChild")
        {
            collision.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
