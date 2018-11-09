using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChildController : MonoBehaviour {
    public GameObject child;
    public Vector3 startLocation;
    public Vector3 endLocation;
    // Use this for initialization
	void Start () {
        startLocation = child.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (child.transform.position.x > endLocation.x && child.transform.position.z < endLocation.z)
        {
            child.transform.position = startLocation;
        }
	}
}
