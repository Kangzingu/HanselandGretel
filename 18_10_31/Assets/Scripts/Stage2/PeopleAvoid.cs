using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAvoid : MonoBehaviour {
    Collider person;
    Animator animator;
	// Use this for initialization
	void Start () {
        person = GetComponent<Collider>();
        animator = GetComponent<Animator>();
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            animator.SetTrigger("Lay");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
