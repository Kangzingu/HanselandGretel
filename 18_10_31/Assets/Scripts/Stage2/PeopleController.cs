using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : MonoBehaviour {
    //public GameObject person;
    public Vector3 startLocation;
    public Vector3 endLocation;
	// Use this for initialization
	void Start () {
        //person = this.GetComponent<GameObject>();
        startLocation = this.transform.position;
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "SubwayPeopleEndPoint")
        {
            this.transform.position = startLocation;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
